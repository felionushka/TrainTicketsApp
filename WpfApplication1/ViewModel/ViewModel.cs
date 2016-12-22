using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApplication1.Model;

namespace WpfApplication1.ViewModel
{
    public enum CarriageType
    {
        [Description("Купе")]
        Coupe,
        [Description("Люкс")]
        Lux,
        [Description("Плацкарт")]
        Econom
    };

    public sealed class ViewModel : ObservableObject
    {
        private string _loginText;
	    private string _passwordText;

	    private string _namesurname;
        private RelayCommand _loginCommand;

        private bool _isErrorMessageVisible;
		private string _startCityText;
	    private string _endCityText;
	    private string _dateText;
        private object _selectedItem;

	    public ViewModel()
	    {
	    }

	    public event EventHandler<string> ShowAnotherWindow;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); }
        }

        public string LoginText
	    {
		    get
		    {
			    return _loginText;
		    }
		    set
		    {
			    Set(ref _loginText, value);
				LoginCommand.RaiseCanExecuteChanged();
		    }
	    }

	    public string PasswordText
	    {
		    get { return _passwordText; }
		    set
		    {
			    Set(ref _passwordText, value);
				LoginCommand.RaiseCanExecuteChanged();
		    }
	    }

	   

	    public bool IsErrorMessageVisible
	    {
		    get { return _isErrorMessageVisible; }
		    set { Set(ref _isErrorMessageVisible, value); }
	    }

        public RelayCommand LoginCommand
	    {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(Login, CanLogin)); }
	    }

	    private bool CanLogin()
	    {
		    return !string.IsNullOrWhiteSpace(LoginText) && !string.IsNullOrWhiteSpace(PasswordText);
	    }

	    private void Login()
	    {
	        IsErrorMessageVisible = false;

	        using (var context = new TrainContext())
	        {
	            CASHIER user = context.CASHIERs.SingleOrDefault(c => c.LOGIN == LoginText && c.PASSWORD == PasswordText);

	            if (user != null)
	            {
		            _namesurname = "\n" +user.NAME +" " + user.sURNAME;
	                OnShowAnotherWindow(_namesurname);
	            }
	            else
	            {
	                IsErrorMessageVisible = true;
	            }
	        }

	    }

	    private void OnShowAnotherWindow(string e)
	    {
		    var handler = ShowAnotherWindow;
		    if (handler != null) handler(this, e);
	    }

    }
}
