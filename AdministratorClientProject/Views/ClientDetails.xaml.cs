using AdministratorClientProject.Models;
using AdministratorClientProject.ViewModel;
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

namespace AdministratorClientProject.Views
{
    /// <summary>
    /// Interaction logic for ClientDetails.xaml
    /// </summary>
    public partial class ClientDetails : Window
    {

        public ClientDetails()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
        
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
