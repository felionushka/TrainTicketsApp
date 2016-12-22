using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
	class ReturnTicketViewModel : ObservableObject
	{
		private string _surnameText;

		private string _surname;
		private  RelayCommand _searchTicketCommand;

		private string _refund;

		private AggregationItem _selectedTicket;

		private RelayCommand _returnTicketCommand;

		public ReturnTicketViewModel(string surname)
		{
			_surname = surname;
			SoldTickets = new ObservableCollection<TICKET_SALE>();
			Tickets = new ObservableCollection<TICKET>();
			StartStation = new ObservableCollection<STATION>();
			EndStation = new ObservableCollection<STATION>();
			Train = new ObservableCollection<TRAIN>();
			Carriage = new ObservableCollection<CARRIAGE>();
			Place = new ObservableCollection<PLACE>();
			Client = new ObservableCollection<CLIENT>();
			ResultCollection = new ObservableCollection<AggregationItem>();
		}

		public ObservableCollection<TICKET_SALE> SoldTickets { get; set; }
		public ObservableCollection<TICKET> Tickets { get; set; }
		public ObservableCollection<CLIENT> Client { get; set; }

		public ObservableCollection<STATION> StartStation { get; set; }
		public ObservableCollection<STATION> EndStation { get; set; }

		public ObservableCollection<TRAIN> Train { get; set; }

		public ObservableCollection<CARRIAGE> Carriage { get; set; }
		public ObservableCollection<PLACE> Place { get; set; }

		public ObservableCollection<AggregationItem> ResultCollection { get; set; }

		public string Refund
		{
			get
			{
				return _refund;
			}
			set
			{
				Set(ref _refund, value);
			}
		}

		public string SurnameText
		{
			get
			{
				return _surnameText;
			}
			set
			{
				Set(ref _surnameText, value);
			}
		}

		public AggregationItem SelectedTicket
		{
			get
			{
				return _selectedTicket;
			}
			set
			{
				Set(ref _selectedTicket, value);
			}
		}

		public RelayCommand SearchTicketCommand
		{
			get
			{
				return _searchTicketCommand ?? (_searchTicketCommand = new RelayCommand(SearchTicket));
			}
		}

		public RelayCommand ReturnTicketCommand
		{
			get
			{
				return _returnTicketCommand ?? (_returnTicketCommand = new RelayCommand(ReturnTicket));
			}
		}

		private void ReturnTicket()
		{
			if (SelectedTicket == null)
			{
				return;
			}

			bool ticketChanged = false;
			bool ticketDeleted = false;

			using (var context = new TrainContext())
			{
				var ticket = context.TICKETs.SingleOrDefault(t => t.ID == SelectedTicket.Ticket.ID);
				if (ticket != null)
				{
					ticket.STATE = true;
					ticketChanged = true;
				}

				var ticketSaleToDelete = context.TICKET_SALE.SingleOrDefault(t => t.ID == SelectedTicket.SoldTickset.ID);

				if (ticketSaleToDelete != null)
				{
					context.TICKET_SALE.Remove(ticketSaleToDelete);
					ticketDeleted = true;
				}

				if (ticket != null)
				{
					decimal? x = ticket.PRICE;
					decimal a = x.GetValueOrDefault();
					decimal b = 0.85m;
					Refund = "Вам буде повернено " + Decimal.Multiply(a, b) + " грн";
				}

				context.SaveChanges();
			}

			if (ticketDeleted && ticketChanged)
			{
				ResultCollection.Remove(SelectedTicket);
			}
		}

		public void SearchTicket()
		{
			SoldTickets.Clear();
			Tickets.Clear();
			Client.Clear();
			ResultCollection.Clear();

			using (var context = new TrainContext())
			{
				var client = context.CLIENTs.SingleOrDefault(c => c.SURNAME == SurnameText);

				var soldTickets = context.TICKET_SALE.Where(c => c.ID_CLIENT == client.ID).ToList();

				foreach (TICKET_SALE soldTicket in soldTickets)
				{
					var ticket = context.TICKETs.SingleOrDefault(c => c.ID == soldTicket.ID_TICKET);
					var place = context.PLACEs.SingleOrDefault(c => c.ID == ticket.ID_PLACE);
					var carriage = context.CARRIAGEs.SingleOrDefault(c => c.ID == place.ID_CARRIAGE);
					var train = context.TRAINS.SingleOrDefault(c => c.ID == ticket.ID_TRAIN);
					var startStation = context.STATIONs.SingleOrDefault(c => c.ID == train.ID_START_STATION);
					var endStation = context.STATIONs.SingleOrDefault(c => c.ID == train.ID_END_STATION);

					ResultCollection.Add(
						new AggregationItem
						{
							Ticket = ticket,
							Train = train,
							Carriage = carriage,
							Place = place,
							EndStation = endStation,
							StartStation = startStation,
							Client = client,
							SoldTickset = soldTicket
						});
				}
			}
			
		}
	}
}
