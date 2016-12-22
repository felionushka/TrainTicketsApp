using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
	class AddingNewTicketViewModel : ObservableObject
	{
		private string _nameText;

		private string _surnameText;

		private string _passportText;

		private readonly AggregationItem aggregationItem;

		private RelayCommand _createTicketCommand;

		private string _sumToPay;

		public AddingNewTicketViewModel (AggregationItem allItems )
		{
			aggregationItem = allItems;
			Client=new ObservableCollection<CLIENT>();
			SoldTickets=new ObservableCollection<TICKET_SALE>();
			Ticket=new ObservableCollection<TICKET>();
			StartStation = new ObservableCollection<STATION>();
			EndStation = new ObservableCollection<STATION>();
			Train = new ObservableCollection<TRAIN>();
			Carriage = new ObservableCollection<CARRIAGE>();
			Place = new ObservableCollection<PLACE>();
			ResultCollection = new ObservableCollection<AggregationItem>();
			Cashier = new ObservableCollection<CASHIER>();
			

		}
		public ObservableCollection<CASHIER> Cashier { get; private set; } 
		public ObservableCollection<CLIENT> Client { get; private set; }
		public ObservableCollection<TICKET_SALE> SoldTickets { get; set; }
		public ObservableCollection<TICKET> Ticket { get; set; }
		public ObservableCollection<STATION> StartStation { get; set; }
		public ObservableCollection<STATION> EndStation { get; set; }
		public ObservableCollection<TRAIN> Train { get; set; }
		public ObservableCollection<CARRIAGE> Carriage { get; set; }
		public ObservableCollection<PLACE> Place { get; set; }

		public ObservableCollection<AggregationItem> ResultCollection { get; set; }

		public string NameText
		{
			get
			{
				return _nameText;
			}
			set
			{
				Set(ref _nameText, value);
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

		public string PassportText
		{
			get
			{
				return _passportText;
			}
			set
			{
				Set(ref _passportText, value);
			}
		}

		public string SumToPay
		{
			get
			{
				return _sumToPay;
			}
			set
			{
				Set(ref _sumToPay, value);
			}
		}

		public RelayCommand CreateTicketCommand
		{
			get
			{
				return _createTicketCommand ?? (_createTicketCommand = new RelayCommand(CreateTicket));
			}
		}

		public void CreateTicket()
		{
			Client.Clear();
			SoldTickets.Clear();
			Ticket.Clear();
			//ResultCollection.Clear();

			using (var context = new TrainContext())
			{
				var clients = context.Set<CLIENT>();
				clients.Add(new CLIENT
				{
					NAME = NameText,
					SURNAME = SurnameText,
					PASSPORT_NUMBER = PassportText
				});
				context.SaveChanges();
				var client = context.CLIENTs.SingleOrDefault(c => c.SURNAME == SurnameText);
				var cashier = context.CASHIERs.SingleOrDefault(c => c.ID == 1);
				var soldTickets = context.Set<TICKET_SALE>();
				var ticket = context.TICKETs.SingleOrDefault(c => c.ID == aggregationItem.Ticket.ID);
				if (client != null && cashier != null && ticket!=null)
				{
					soldTickets.Add(new TICKET_SALE
					{
						ID_CLIENT = client.ID,
						ID_TICKET = aggregationItem.Ticket.ID,
						SELL_DATE = DateTime.Today,
						ID_CASHIER = cashier.ID
					});
					ticket.STATE = false;

					SumToPay = "Квиток успішно оформлений. \nДо сплати " + ticket.PRICE + " грн.";
				}
				

				context.SaveChanges();
			}
		}
	}
	}
