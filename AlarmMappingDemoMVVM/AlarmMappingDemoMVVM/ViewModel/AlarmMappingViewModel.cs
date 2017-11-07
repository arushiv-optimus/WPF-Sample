
using AlarmMappinDemoMVVM.Model;
using AlarmMappingDemoMVVM.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AlarmMappingDemoMVVM.ViewModel
{
    /// <summary>
    /// A ViewModel For AlarmMappingView.
    /// </summary>
    public class AlarmMappingViewModel :INotifyPropertyChanged
    {
        #region field

        private IList<Avigilon> avigilonList;
        public IList<Avigilon> AvigilonList
        {
            get { return avigilonList; }
            set { avigilonList = value; }
        }

        private IList<Jacques> jacquesList;
        public IList<Jacques> JacquesList
        {
            get { return jacquesList; }
            set { jacquesList = value; }
        }

        private string alarmName;
        public string AlarmName
        {
            get { return alarmName; }
            set { alarmName = value; OnPropertyChanged("AlarmName"); }
        }

        private string siteName;
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; OnPropertyChanged("SiteName");
            }
        }

        private string selectedTag;
        public string SelectedTag
        {
            get { return selectedTag; }
            set { selectedTag = value; OnPropertyChanged("SelectedTag"); }
        }

        #region selectedItem

        private Avigilon selectedGridAvigilon;
        public Avigilon SelectedGridAvigilon
        {
            get
            {
                return selectedGridAvigilon;
            }
            set
            {
                selectedGridAvigilon = value;
                OnPropertyChanged("SelectedGridAvigilon");
            }
        }

        private Jacques selectedGridJacques;
        public Jacques SelectedGridJacques
        {
            get
            {
                return selectedGridJacques;
            }
            set
            {
                selectedGridJacques = value;
                OnPropertyChanged("SelectedGridJacques");
            }
        }

        #endregion

        public ICommand SaveCommand { get; set; }
        public ICommand MoveCommand { get; set; }
        public ICommand AvigilonSelectionCommand { get; set; }
        public ICommand JacquesSelectionCommand { get; set; }

        /// <summary>
        ///ObservableCollection is dynamic collection of objects of a given type.
        ///When an object is added to or removed from an observable collection, the UI is automatically updated.
        /// </summary>
        public ObservableCollection<AlarmsMapping> alarmMappingList { get; set; }
        
        #endregion


        /// <summary>
        /// ViewModel Constructor
        /// </summary>
        public AlarmMappingViewModel()
        {
            Avigilon();
            Jacques();
            alarmMappingList = new ObservableCollection<AlarmsMapping>();

            SaveCommand = new CustomCommand(SaveAndNext, CanSaveAndNext);
            MoveCommand = new CustomCommand(MoveNext, CanMoveNext);
            AvigilonSelectionCommand = new CustomCommand(AvigilonSelection, CanAvigilonSelection);
            JacquesSelectionCommand = new CustomCommand(JacquesSelection, CanJacquesSelection);

        }

        #region Commands

        /// <summary>
        /// SaveCommand Execute Method
        /// </summary>
        private void SaveAndNext(object sender)
        {
            MessageBox.Show("Current configuration has been saved", "Avigilon Jacques Gateways Admin Tool", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanSaveAndNext(object obj)
        {
            return true;
        }

        /// <summary>
        /// MoveCommand Execute Method
        /// </summary>
        private void MoveNext(object obj)
        {

            AlarmsMapping();
        }
        private bool CanMoveNext(object obj)
        {
            return true;
        }

        /// <summary>
        /// AvigilonSelectionCommand Execute Method
        /// </summary>
        private void AvigilonSelection(object sender)
        {
            AlarmName = selectedGridAvigilon.Alarm;
            SiteName = selectedGridAvigilon.Site;

        }
        private bool CanAvigilonSelection(object obj)
        {
            return true;
        }

        /// <summary>
        /// JacquesSelectionCommand Execute Method
        /// </summary>
        private void JacquesSelection(object sender)
        {
            SelectedTag = selectedGridJacques.Tag.ToString();

        }
        private bool CanJacquesSelection(object obj)
        {
            return true;
        }


        #endregion

        #region list

        /// <summary>
        /// add iteams in alarmMappingList
        /// </summary>
        public void AlarmsMapping()
        {          
            alarmMappingList.Add(
                new AlarmsMapping { AvigilonAlarm = AlarmName, AvigilonSite = SiteName, JacqueTags = SelectedTag
                });          
        }

        /// <summary>
        /// method to bind gridAvigilon
        /// </summary>
        public void Avigilon()
        {
            avigilonList = new List<Avigilon>
            {
                new Avigilon{Alarm = "JacquesTimeIssue",Site="ACC_6.0.0.24_4"},
                new Avigilon{Alarm = "JacquesTime",Site="ACC_6.0.0.30_1"},
                new Avigilon{Alarm = "JacquesIssue",Site="ACC_6.0.0.1_1"}
            };
        }

        /// <summary>
        /// method to bind gridJacques
        /// </summary>
        public void Jacques()
        {
            jacquesList = new List<Jacques>
            {
                new Jacques{Tag = 100 , TagStatus = "Online", TagName = "Slave1" },
                new Jacques{ Tag = 168, TagStatus = "Online", TagName = "WinHitTester"  },
                new Jacques{Tag = 121, TagStatus = "Online", TagName = "Slave1"  },
                new Jacques{ Tag = 111, TagStatus = "Online", TagName = "IPM-350"  },
                new Jacques{ Tag = 168, TagStatus = "Online", TagName = "WinHitTester" },
                new Jacques{Tag = 100 , TagStatus = "Online", TagName = "Slave1" },
                new Jacques{ Tag = 168, TagStatus = "Online", TagName = "WinHitTester"  },
                new Jacques{Tag = 121, TagStatus = "Online", TagName = "Slave1"  }
                  };
        }
        #endregion

        #region INotifyPropertyChanged 


        /// <summary>
        /// Notifies clients that a property value has changed.Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
