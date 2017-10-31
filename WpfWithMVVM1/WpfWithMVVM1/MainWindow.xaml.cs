
using System.Windows;


namespace WpfWithMVVM1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UserViewModels VM = new UserViewModels();
            DataContext = VM;
            Show();
            InitializeComponent();
        }
    }
}
