using System.ComponentModel;

namespace AlarmMappinDemoMVVM.Model
{
    public class AlarmsMapping : INotifyPropertyChanged
    {
        private string avigilonAlarm;
        private string avigilonSite;
        private string jacqueTags;

        public string AvigilonAlarm
        {
            get
            {
                return avigilonAlarm;
            }
            set
            {
                avigilonAlarm = value;
                OnPropertyChanged("AvigilonAlarm");
            }
        }
        public string AvigilonSite
        {
            get
            {
                return avigilonSite;
            }
            set
            {
                avigilonSite = value;
                OnPropertyChanged("AvigilonSite");
            }
        }
        public string JacqueTags
        {
            get
            {
                return jacqueTags;
            }
            set
            {
                jacqueTags = value;
                OnPropertyChanged("JacqueTags");
            }
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
