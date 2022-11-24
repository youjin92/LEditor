using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LEditor.Utils
{
    public class BaseViewModel : BindableBase
    {
        public virtual void Executed(object target, ExecutedRoutedEventArgs e)
        {

        }
        public virtual void CanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
