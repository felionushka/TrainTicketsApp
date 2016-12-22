using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.Model;
using WpfApplication1.ViewModel;

namespace WpfApplication1.View
{
	/// <summary>
	/// Interaction logic for AddingNewTicketWindow.xaml
	/// </summary>
	public partial class AddingNewTicketWindow : Window
	{
		public AddingNewTicketWindow(AggregationItem allItems)
		{
			InitializeComponent();
			DataContext = new AddingNewTicketViewModel(allItems);
		}
	}
}
