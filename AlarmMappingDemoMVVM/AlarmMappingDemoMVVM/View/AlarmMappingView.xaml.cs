using AlarmMappinDemoMVVM.Model;
using System.Windows;
using System.Windows.Controls;

namespace AlarmMappingDemoMVVM.View
{
    /// <summary>
    /// Interaction logic for AlarmMappingView.xaml
    /// </summary>
    public partial class AlarmMappingView : Window
    {
        ViewModel.AlarmMappingViewModel viewModel = new ViewModel.AlarmMappingViewModel();

        public AlarmMappingView()
        {
            InitializeComponent();
          
        }


        private void gridAvigilon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Avigilon gridAvigilonSelection = gridAvigilon.SelectedItem as Avigilon;
            viewModel.AvigilonSelect(gridAvigilonSelection);
        }

        private void gridJacques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Jacques gridJacquesSelection = gridJacques.SelectedItem as Jacques;
            viewModel.JacquesSelect(gridJacquesSelection);
        }

        private void MoveNext_Click(object sender, RoutedEventArgs e)
        {
            gridAlarmsMapping.ItemsSource = viewModel.getAvigilonModel();
        }

        private void SaveAndNext_Click(object sender, RoutedEventArgs e)
        {

            viewModel.SaveAlarmsmappingGrid();

        }

    }
}
