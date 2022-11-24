using LEditor.Utils;
using Microsoft.Xaml.Behaviors;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LEditor.Behaviors
{
    public class ButtonClickBehavior : Behavior<FrameworkElement>
    {
        private CommandBinding command_;

        public static RoutedUICommand CustomCommand { get; set; } = new RoutedUICommand();

        public ExecutedRoutedEventHandler Executed { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            command_ = new CommandBinding(CustomCommand, ConfirmExecuted, ConfirmCanExecute);
            AssociatedObject.CommandBindings.Add(command_);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.CommandBindings.Remove(command_);
            command_ = null;
        }

        private void ConfirmExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var viewModel = AssociatedObject.DataContext as BaseViewModel;

            if (viewModel != null)
            {
                viewModel.Executed(target, e);
            }
        }

        private void ConfirmCanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            var viewModel = AssociatedObject.DataContext as BaseViewModel;

            if (viewModel != null)
            {
                viewModel.CanExecute(target, e);
            }
        }
    }


}
