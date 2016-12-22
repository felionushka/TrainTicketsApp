using System.Windows;
using TrainTicketsApp.ViewModel;

namespace TrainTicketsApp.View
{
	/// <summary>
	/// Interaction logic for MainSearchTicketWindow.xaml
	/// </summary>
	public partial class MainSearchTicketWindow : Window
	{
		public MainSearchTicketWindow(string name)
		{
			InitializeComponent();

			DataContext = new MainSearchTicketViewModel(name);

			((MainSearchTicketViewModel)DataContext).ShowReturningTicketWindow += (sender, surname) =>
			{
				new ReturningTicketWindow(surname).ShowDialog();
			};

			((MainSearchTicketViewModel)DataContext).ShowAddingTicketWindow += (sender, item) =>
			{
				new AddingNewTicketWindow(item).ShowDialog();
			};
		}
	}
}
