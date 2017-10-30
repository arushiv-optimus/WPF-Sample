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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is : {this.DescriptionText.Text.ToUpper()}");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeldCheckBox.IsChecked = false;
            this.AssemblyCheckBox.IsChecked = false;
            this.PlasmaCheckBox.IsChecked = false;
            this.LaserCheckBox.IsChecked = false;
            this.PurchaseCheckBox.IsChecked = false;
            this.LatheCheckBox.IsChecked = false;
            this.DrillCheckBox.IsChecked = false;
            this.FoldCheckBox.IsChecked = false;
            this.RollCheckBox.IsChecked = false;
            this.SawCheckBox.IsChecked = false;

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            LengthText.Text += ((CheckBox)sender).Content +"," ;
        }

        private void PurchaseInfoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            var text = value.Content.ToString();
            NoteText.Text = value.Content.ToString();

            }catch(Exception ex)
            { }


        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
           DescriptionText.Text = "";

           WeldCheckBox.IsChecked = false;
           AssemblyCheckBox.IsChecked = false;
           PlasmaCheckBox.IsChecked = false;
           LaserCheckBox.IsChecked = false;
           PurchaseCheckBox.IsChecked = false;
           LatheCheckBox.IsChecked = false;
           DrillCheckBox.IsChecked = false;
           FoldCheckBox.IsChecked = false;
           RollCheckBox.IsChecked = false;
           SawCheckBox.IsChecked = false;

           LengthText.Text = "";

           NoteText.Text = "";
        }
    }
}
