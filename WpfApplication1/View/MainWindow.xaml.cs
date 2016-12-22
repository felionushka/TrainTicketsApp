using System.Windows;

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			DataContext = new ViewModel.ViewModel();

	        ((ViewModel.ViewModel) DataContext).ShowAnotherWindow += (sender, args) =>
	        {
		        new AnotherWindow(args).ShowDialog();
	        };
        }

    }
}
