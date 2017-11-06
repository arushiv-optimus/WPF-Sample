using System.ComponentModel;

namespace AlarmMappinDemoMVVM.Model
{
    public class Jacques :INotifyPropertyChanged
    {
        private int tag;
        private string tagStatus;
        private string tagName;

        public int Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
                OnPropertyChanged("Tag");
            }
        }
        public string TagStatus
        {
            get
            {
                return tagStatus;
            }
            set
            {
                tagStatus = value;
                OnPropertyChanged("TagStatus");
            }
        }
        public string TagName
        {
            get
            {
                return tagName;
            }
            set
            {
                tagName = value;
                OnPropertyChanged("TagName");
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
