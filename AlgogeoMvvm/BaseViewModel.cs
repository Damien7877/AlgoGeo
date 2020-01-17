using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AlgogeoMvvm
{
    /// <summary>
    /// Permet de gérer un viewModel 
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;
            if(memberExpression != null)
                OnPropertyChanged(memberExpression.Member.Name);
        }



        public BaseViewModel()
        {
        }
    }
}
