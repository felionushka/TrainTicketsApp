using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TrainTicketsApp.Model;

namespace TrainTicketsApp.ViewModel
{
	class AddingNewTicketViewModel : ObservableObject
	{
		private string _nameText;

		private string _surnameText;

		private string _passportText;

		private readonly AggregationItem _aggregationItem;

		private RelayCommand _createTicketCommand;

		private string _sumToPay;

		public AddingNewTicketViewModel(AggregationItem allItems)
		{
			_aggregationItem = allItems;

			ResultCollection = new ObservableCollection<AggregationItem>();
		}

		public ObservableCollection<AggregationItem> ResultCollection { get; private set; }

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

		private void CreateTicket()
		{
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
				var ticket = context.TICKETs.SingleOrDefault(c => c.ID == _aggregationItem.Ticket.ID);
				if (client != null && cashier != null && ticket != null)
				{
					soldTickets.Add(new TICKET_SALE
					{
						ID_CLIENT = client.ID,
						ID_TICKET = _aggregationItem.Ticket.ID,
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
