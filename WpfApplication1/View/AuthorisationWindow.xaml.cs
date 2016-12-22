using System.Windows;

namespace TrainTicketsApp.View
{
    /// <summary>
    /// Interaction logic for AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        public AuthorisationWindow()
        {
            InitializeComponent();
			DataContext = new ViewModel.AuthorizationViewModel();

	        ((ViewModel.AuthorizationViewModel) DataContext).ShowAnotherWindow += (sender, args) =>
	        {
		        new MainSearchTicketWindow(args).ShowDialog();
	        };
        }

    }
}
