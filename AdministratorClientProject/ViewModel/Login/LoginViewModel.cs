using AdministratorClientProject.Models;
using AdministratorClientProject.Repository;
using AdministratorClientProject.ViewModel.Login;
using AdministratorClientProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdministratorClientProject.ViewModel
{
    public class LoginViewModel : Login.ViewModelBase
    {
        QuipuDbEntities _db;
        public LoginViewModel()
        {
            _db = new QuipuDbEntities();
        }
        #region CurrentClient
        Administrator _currentAdministrator;
        public Administrator CurrentClient
        {
            get
            {
                if (_currentAdministrator == null)
                    _currentAdministrator = new Administrator();
                return _currentAdministrator;
            }
            set
            {
                _currentAdministrator = value;
                OnPropertyChanged("CurrentClient");
            }
        }
        #endregion
        #region CheckLogin
        public void CheckLogin()
        {
            var user = _db.Administrators.Where(i => i.EmailAddress == this.CurrentClient.EmailAddress && i.Password == this.CurrentClient.Password.ToString()).FirstOrDefault();

            if (user == null)
            {
                MessageBox.Show("Unable to Login, incorrect credentials.");

            }
            else if (this.CurrentClient.EmailAddress == user.EmailAddress || this.CurrentClient.Password.ToString() == user.Password)
            {
                ClientDetails cd = new ClientDetails();
                cd.Show();
                App.Current.MainWindow.Hide();
            }
            else
            {
                MessageBox.Show("Unable to Login, incorrect credentials ??.");
            }
        }
        private ICommand showLoginCommand;
        public ICommand ShowLoginCommand
        {
            get
            {
                if (this.showLoginCommand == null)
                {
                    this.showLoginCommand = new Command(i => this.CheckLogin(), null);
                }
                return this.showLoginCommand;
            }
        }
        #endregion
        #region CloseLoginForm
        private ICommand _closeLoginForm;
        public ICommand CloseLoginForm
        {
            get
            {
                if (_closeLoginForm == null)
                    _closeLoginForm = new Command(ExecuteCloseLoginForm);
                return _closeLoginForm;
            }
        }
        private void ExecuteCloseLoginForm(object obj)
        {
            Application.Current.Shutdown();
        }
        #endregion

    }
}
