using AdministratorClientProject.Models;
using AdministratorClientProject.Repository;
using AdministratorClientProject.ViewModel.Register;
using AdministratorClientProject.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace AdministratorClientProject.ViewModel.Register
{
   
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private ICommand _saveCommand;
        private RegisterRepository _repository;
        private Administrator _userEntity;
        public Command _command;
        public QuipuDbEntities UserEntities { get; set; }
        public Administrator UserRecord { get; set; }
        public RegisterView RegisterView { get; set; }
        public CloseWindow view;
      
        QuipuDbEntities _db;
        public RegisterViewModel()
        {
            _db = new QuipuDbEntities();
            UserRecord = new Administrator();
            _repository = new RegisterRepository();
            _userEntity = new Administrator();
            

        }
 
        #region CurrentClient
        Administrator _userRecords;
        public Administrator UserRecords
        {
            get
            {
                if (_userRecords == null)
                    _userRecords = new Administrator();
                return _userRecords;
            }
            set
            {
                _userRecords = value;
                OnPropertyChanged("UserRecords");
            }
        }
        #endregion
        public ICommand SaveCommand //Save Command for Add/Edit
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new Command(param => RegisterUser(), null);

                return _saveCommand;
            }
        }

        #region SaveData

        public void RegisterUser()
        {
            if (UserRecord != null)
            {
                //_userEntity.AdmId = UserRecord.AdmId;
                _userEntity.Name = UserRecord.Name;
                _userEntity.Surname = UserRecord.Surname;
                _userEntity.PhoneNumber = (int)UserRecord.PhoneNumber;
                _userEntity.EmailAddress = UserRecord.EmailAddress;
                _userEntity.Password = UserRecord.Password;

                try
                {
                    if (UserRecord.AdmId <= 0)
                    {
                        _repository.AddUser(_userEntity);
                        MessageBox.Show("New record successfully saved.");
                        App.Current.MainWindow.Show();
                        
                    }
                    else
                    {

                        MessageBox.Show("User Exist");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. "+ ex.InnerException);
                }
            }
        }// End EditAdd Client Method


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
