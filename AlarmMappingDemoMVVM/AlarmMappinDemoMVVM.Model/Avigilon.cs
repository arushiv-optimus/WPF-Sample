using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AlarmMappinDemoMVVM.Model
{
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
