using System.Windows;
using TrainTicketsApp.Model;
using TrainTicketsApp.ViewModel;

namespace TrainTicketsApp.View
{
	/// <summary>
	/// Interaction logic for AddingNewTicketWindow.xaml
	/// </summary>
	public partial class AddingNewTicketWindow : Window
	{
		public AddingNewTicketWindow(AggregationItem item)
		{
			InitializeComponent();
			DataContext = new AddingNewTicketViewModel(item);
		}
	}
}
