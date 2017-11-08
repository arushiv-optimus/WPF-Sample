using System;
using System.Windows.Input;

namespace AlarmMappingDemoMVVM.Utility
{
    /// <summary>
    ///  CustomCommand class implemented ICommand Interface
    /// </summary>
    public class CustomCommand : ICommand
    {
        /// <summary>
        /// Action is a generic delegates present in System namespace. it takes one or more input parameters and return Void.
        /// </summary>
        private Action<object> execute;

        /// <summary>
        /// predicates are the comparison delegates which take only one argument and retuen bool.
        /// </summary>
        private Predicate<object> canExecute;

        /// <summary>
        /// CustomCommand Constructor
        /// </summary>
        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {          
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///  check if canExecute is null return true else return canExecute with a parameter of predicate.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            bool b = canExecute == null ? true : canExecute(parameter);
            return b;
        }

        /// <summary>
        /// Execute method will be called to execute somting on view model. Used to executing code basically.
        /// </summary>
        public void Execute(object parameter)
        {
            //Function or Method i want to execute
            execute(parameter);
        }
    }
}
