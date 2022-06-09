//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdministratorClientProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Administrator : INotifyPropertyChanged
    {
        private int admId;
        [Required]
        private string name;
        [Required]
        private string surname;
        [Required]
        private int phoneNumber;
        [Required]
        private string emailAddress;
        [Required]
        private string password;

        [Required]
        public int AdmId { get => admId; set { admId = value; OnPropertyChanged(nameof(admId)); } }
        [Required]
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(name)); } }
        [Required]
        public string Surname { get => surname; set { surname = value; OnPropertyChanged(nameof(surname)); } }
        [Required]
        public int PhoneNumber { get => phoneNumber; set { phoneNumber = value; OnPropertyChanged(nameof(phoneNumber)); } }
        [Required]
        public string EmailAddress { get => emailAddress; set { emailAddress = value; OnPropertyChanged(nameof(emailAddress)); } }

        [Required(ErrorMessage = "Please enter password.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$")]
        [StringLength(maximumLength: 35, ErrorMessage = "Minimum 8 and maximum 35 characters.", MinimumLength = 8)]
        public string Password { get => password; set { password = value; OnPropertyChanged(nameof(password)); } }


        //Records
        private ObservableCollection<Administrator> _userRecords;
        public ObservableCollection<Administrator> UserRecords
        {
            get
            {
                return _userRecords;
            }
            set
            {
                _userRecords = value;
                OnPropertyChanged("UserRecords");
            }
        }

        private void ClientModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("UserRecords");
        }
        //

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
