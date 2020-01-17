using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlgogeoMvvm
{
    /// <summary>
    /// Gère une commande pour le mvvm
    /// </summary>
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<Object> executeMethod;

        public Predicate<Object> canExecutePredicate;

        /// <summary>
        /// Create a command with can execute predicate
        /// </summary>
        /// <param name="executeMethod">method to execute</param>
        /// <param name="canExecutePredicate">predicate to use</param>
        public DelegateCommand(Action<Object> executeMethod, Predicate<Object> canExecutePredicate)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("Execute method cannot be null!");

            if (canExecutePredicate == null)
                throw new ArgumentNullException("Can execute predicate cannot be null!");

            this.executeMethod = executeMethod;
            this.canExecutePredicate = canExecutePredicate;
        }

        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Create a command without CanExecute predicate
        /// </summary>
        /// <param name="executeMethod">method to execute</param>
        public DelegateCommand(Action<Object> executeMethod) : this(executeMethod, (x) => true)
        {
        }

        public bool CanExecute(object parameter)
        {
            return canExecutePredicate(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
