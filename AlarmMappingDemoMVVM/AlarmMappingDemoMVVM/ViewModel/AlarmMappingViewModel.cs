
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

        private Avigilon selectedGridAvigilon = null;
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

        private AlarmsMapping selectedGridAlarmMapping;
        public AlarmsMapping SelectedGridAlarmMapping
        {
            get
            {
                return selectedGridAlarmMapping;
            }
            set
            {
                selectedGridAlarmMapping = value;
                OnPropertyChanged("SelectedGridAlarmMapping");
            }
        }

        #endregion

        public ICommand SaveCommand { get; set; }
        public ICommand MoveCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand AvigilonSelectionCommand { get; set; }
        public ICommand JacquesSelectionCommand { get; set; }
        public ICommand AlarmMappingSelectionCommand { get; set; }

        /// <summary>
        ///ObservableCollection is dynamic collection of objects of a given type.
        ///When an object is added to or removed from an observable collection, the UI is automatically updated.
        /// </summary>
        public ObservableCollection<AlarmsMapping> alarmMappingList { get; set; }

        #endregion
        #region Button Visibility
        public bool isEnabledMove = false;

        public bool IsEnabledMove
        {

            get { return isEnabledMove; }

            set
            {
                isEnabledMove = value;
                OnPropertyChanged("IsEnabledMove");
            }
        }

        public bool isEnabledClear = false;

        public bool IsEnabledClear
        {

            get { return isEnabledClear; }

            set
            {
                isEnabledClear = value;
                OnPropertyChanged("IsEnabledClear");
            }
        }
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
            ClearCommand = new CustomCommand(ClearMapping, CanClearMapping);
            AvigilonSelectionCommand = new CustomCommand(AvigilonSelection, CanAvigilonSelection);
            JacquesSelectionCommand = new CustomCommand(JacquesSelection, CanJacquesSelection);
            AlarmMappingSelectionCommand = new CustomCommand(AlarmMappingSelection, CanAlarmMappingSelection);

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
            if (string.IsNullOrEmpty(alarmName)|| string.IsNullOrEmpty(siteName)|| string.IsNullOrEmpty(SelectedTag))
            {
                if (string.IsNullOrEmpty(SelectedTag))
                MessageBox.Show("Jacques Tag Is Not Selected", "Avigilon Jacques Gateways Admin Tool", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                MessageBox.Show("Aligilon Alarm & Site Are Not Selected", "Avigilon Jacques Gateways Admin Tool", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AlarmsMapping();
                AlarmName = null;
                SiteName = null;
                SelectedTag = null;
            }

        }
        private bool CanMoveNext(object obj)
        {
            return true;
        }

        /// <summary>
        /// ClearCommand Execute Method
        /// </summary>
        private void ClearMapping(object obj)
        {
            if (alarmMappingList.Count >= 1)
            {
                if (SelectedGridAlarmMapping != null)
                {
                    alarmMappingList.Remove(SelectedGridAlarmMapping);
                    SelectedGridAlarmMapping = null;
                }
            }
           // alarmMappingList.RemoveAt(alarmMappingList.Count - 1);
        }
        private bool CanClearMapping(object obj)
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
            IsEnabledMove = true;
        }
        private bool CanJacquesSelection(object obj)
        {
            return true;
        }


        /// <summary>
        /// AlarmMappingSelectionCommand Execute Method
        /// </summary>
        private void AlarmMappingSelection(object sender)
        {
           

            IsEnabledClear = true;
        }
        private bool CanAlarmMappingSelection(object obj)
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
