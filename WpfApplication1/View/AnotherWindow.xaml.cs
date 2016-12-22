using System.Windows;
using WpfApplication1.ViewModel;

namespace WpfApplication1.View
{
	/// <summary>
	/// Interaction logic for AnotherWindow.xaml
	/// </summary>
	public partial class AnotherWindow : Window
	{
		public AnotherWindow(string name)
		{
			InitializeComponent();

			DataContext = new AnotherViewModel(name);

			((AnotherViewModel)DataContext).ShowReturningTicketWindow += (sender, args) =>
			{
				new ReturningTicketWindow(args).ShowDialog();
			};

			((AnotherViewModel)DataContext).ShowAddingTicketWindow += (sender, items) =>
			{
				new AddingNewTicketWindow(items).ShowDialog();
			};
		}
	}
}
