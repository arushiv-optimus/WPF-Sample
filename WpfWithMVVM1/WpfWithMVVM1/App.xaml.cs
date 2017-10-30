using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfWithMVVM1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WpfWithMVVM1.MainWindow window = new MainWindow();
            UserViewModel.UserViewModel VM = new UserViewModel.UserViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }
}
