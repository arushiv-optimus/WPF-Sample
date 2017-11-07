using System.ComponentModel;

namespace AlarmMappinDemoMVVM.Model
{
    /// <summary>
    /// This is a Model for Avigilon.
    /// </summary>
    public class Avigilon : INotifyPropertyChanged
    {
        private string alarm;
        private string site;

        public string Alarm
        {
            get
            {
                return alarm;
            }
            set
            {
                alarm = value;
                OnPropertyChanged("Alarm");
            }
        }
        public string Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
                OnPropertyChanged("Site");
            }
        }


        #region INotifyPropertyChanged 

        /// <summary>
        ///  Notifies clients that a property value has changed.Occurs when a property value changes.
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
