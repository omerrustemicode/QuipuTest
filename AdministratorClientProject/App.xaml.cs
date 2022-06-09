using AdministratorClientProject.ViewModel;
using AdministratorClientProject.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdministratorClientProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginView window = new LoginView();
            LoginViewModel viewModel = new LoginViewModel();

            window.DataContext = viewModel;
            window.Show();


        }
    }
}
