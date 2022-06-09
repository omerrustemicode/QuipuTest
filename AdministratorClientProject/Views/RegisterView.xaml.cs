using AdministratorClientProject.ViewModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace AdministratorClientProject.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window,CloseWindow
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
           
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

   
    }
}
