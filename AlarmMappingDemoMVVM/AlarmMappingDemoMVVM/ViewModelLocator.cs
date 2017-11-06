using AlarmMappingDemoMVVM.ViewModel;


namespace AlarmMappingDemoMVVM
{
    class ViewModelLocator
    {
        private static AlarmMappingViewModel alarmMappingViewModel
            = new AlarmMappingViewModel();

        public static AlarmMappingViewModel AlarmMappingViewModel
        {
            get
            {
                return alarmMappingViewModel;
            }
        }
    }
}
