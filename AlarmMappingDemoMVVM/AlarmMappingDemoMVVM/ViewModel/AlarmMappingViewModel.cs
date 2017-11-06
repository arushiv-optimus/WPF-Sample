
using AlarmMappinDemoMVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AlarmMappingDemoMVVM.ViewModel
{
    public class AlarmMappingViewModel : INotifyPropertyChanged
    {

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
            set { alarmName = value; }
        }

        private string siteName;
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }

        private string selectedTag;
        public string SelectedTag
        {
            get { return selectedTag; }
            set { selectedTag = value; }
        }

        // ViewModel Constructor

        public AlarmMappingViewModel()
        {
            Avigilon();
            Jacques();
        }

        /// <summary>
        ///ObservableCollection is dynamic collection of objects of a given type.
        ///When an object is added to or removed from an observable collection, the UI is automatically updated.
        /// </summary>
        /// <returns></returns>

        public ObservableCollection<AlarmsMapping> alarmMappingList = new ObservableCollection<AlarmsMapping>();

        // method that return ObservableCollection and bind gridAlarmsMapping
        public ObservableCollection<AlarmsMapping> getAvigilonModel()
        {
            // add iteams in alarmMappingList
            alarmMappingList.Add(new AlarmsMapping() { AvigilonAlarm = AlarmName, AvigilonSite = SiteName, JacqueTags = SelectedTag });
            return alarmMappingList;
        }


        // method to bind gridAvigilon
        public void Avigilon()
        {
            // add iteams in avigilonList
            avigilonList = new List<Avigilon>
            {
                new Avigilon{Alarm = "JacquesTimeIssue",Site="ACC_6.0.0.24_4"},
                new Avigilon{Alarm = "JacquesTime",Site="ACC_6.0.0.30_1"},
                new Avigilon{Alarm = "JacquesIssue",Site="ACC_6.0.0.1_1"}
            };
        }

        //method to bind gridJacques
        public void Jacques()
        {
            // add iteams in jacquesList
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

        //Method to get selected row items from grid Jacques
        public void JacquesSelect(Jacques gridJacquesSelection)
        {

            SelectedTag = gridJacquesSelection.Tag.ToString();
        }

        //Method to get selected row items from grid Avigilon
        public void AvigilonSelect(Avigilon gridAvigilonSelection)
        {
            AlarmName = gridAvigilonSelection.Alarm;
            SiteName = gridAvigilonSelection.Site;
        }

        public void SaveAlarmsmappingGrid()
        {
            MessageBox.Show("Current configuration has been saved", "Avigilon Jacques Gateways Admin Tool", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        ///  Notifies clients that a property value has changed.
        /// </summary>
        
        #region INotifyPropertyChanged 

        /// <summary>
        ///  Occurs when a property value changes.
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
