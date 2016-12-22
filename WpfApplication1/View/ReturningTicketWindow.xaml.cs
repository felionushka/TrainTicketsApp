using System.Windows;
using TrainTicketsApp.ViewModel;

namespace TrainTicketsApp.View
{
	/// <summary>
	/// Interaction logic for ReturningTicketWindow.xaml
	/// </summary>
	public partial class ReturningTicketWindow : Window
	{
		public ReturningTicketWindow(string surname)
		{
			InitializeComponent();

			DataContext = new ReturnTicketViewModel(surname);
		}
	}
}
