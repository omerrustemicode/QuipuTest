using AdministratorClientProject.Models;
using AdministratorClientProject.Repository;
using AdministratorClientProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AdministratorClientProject.ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        #region init
        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ClientRepository _repository;
        private Client _clientEntity;
        public Client ClientRecord { get; set; }
        public Command _command;
        public QuipuDbEntities ClientEntities { get; set; }
        public ClientDetails clientDetails { get; set; }
        #endregion

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        private ObservableCollection<Client> _1stClientDetail;

        public ObservableCollection<Client> listClientDetail
        {
            get { return _1stClientDetail; }
            set { _1stClientDetail = value; OnPropertyChanged(nameof(listClientDetail)); }
        }
        #endregion

        QuipuDbEntities quipuDbEntities;
        public static DataGrid dataGrid;
        public ClientViewModel()
        {
            quipuDbEntities = new QuipuDbEntities();
            loadClients();
            _clientEntity = new Client();
            _repository = new ClientRepository();
            ClientRecord = new Client();
           
        }
        #region All Commands
        // Reset Command
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new Command(param => ResetData(), null);

                return _resetCommand;
            }
        } //
        // Delete Client method
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new Command(param => DeleteClient((int)param), null);

                return _deleteCommand;
            }
        }
        
        public ICommand EditCommand//Edit Method 
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new Command(param => EditData((int)param), null);

                return _editCommand;
            }
        }
        
        public ICommand SaveCommand //Save Command for Add/Edit
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new Command(param => SaveData(), null);

                return _saveCommand;
            }
        }
        #endregion

        #region DeleteClient
        public void DeleteClient(int id)
        {
            if (MessageBox.Show("Confirm delete of this record?", "Client", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    _repository.RemoveClient(id);
                    MessageBox.Show("Record successfully deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    loadClients();
                }
            }
        }// End Delete Client method
        #endregion

        #region EditData
        public void EditData(int id)
        {
            var model = _repository.Get(id);
            ClientRecord.PartyId = (int)model.PartyId;
            ClientRecord.FullName = model.FullName;
            ClientRecord.PartyCode = (int)model.PartyCode;
            ClientRecord.TaxCode = (int)model.TaxCode;
            ClientRecord.CountryCode = model.CountryCode;
            //ClientRecord.RegistrationDate = DateTime.Now;
            ClientRecord.ClientType = model.ClientType;
        } // End EditData
        #endregion

        #region SaveData
        public void SaveData()
        {
            if (ClientRecord != null)
            {
                _clientEntity.FullName = ClientRecord.FullName;
                _clientEntity.PartyCode = (int)ClientRecord.PartyCode;
                _clientEntity.TaxCode = (int)ClientRecord.TaxCode;
                _clientEntity.CountryCode = ClientRecord.CountryCode;
                _clientEntity.RegistrationDate = DateTime.Now;
                _clientEntity.ClientType = ClientRecord.ClientType;

                try
                {
                    if (ClientRecord.PartyId <= 0)
                    {
                        _repository.AddClient(_clientEntity);
                        MessageBox.Show("New record successfully saved.");
                        
                    }
                    else
                    {
                        _clientEntity.PartyId = ClientRecord.PartyId;
                        _repository.EditClient(_clientEntity);
                        MessageBox.Show("Record successfully updated.");
               
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    this.loadClients();
                    ResetData();
                }
            }
        }// End EditAdd Client Method
        #endregion

        #region LoadClients
        private void loadClients() //Read Client Details
        {
            listClientDetail = new ObservableCollection<Client>(quipuDbEntities.Clients);
        }
        #endregion
        
        #region ResetData
        public void ResetData()
        {
            ClientRecord.FullName = string.Empty;
            ClientRecord.PartyId = 0;
            ClientRecord.PartyCode = 0;
            ClientRecord.TaxCode = 0;
            ClientRecord.CountryCode = string.Empty;
            ClientRecord.ClientType = string.Empty;
        }
        #endregion
    }

}
