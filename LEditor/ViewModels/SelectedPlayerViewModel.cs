using LEditor.Events;
using LEditor.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LEditor.Utils;
using LEditor.Behaviors;
using LEditor.Common;

namespace LEditor.ViewModels
{
    public class SelectedPlayerViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<Player> WaitUsers { get; set; } = new ObservableCollection<Player>();

        public SelectedPlayerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<UpdatePlayerEvent>().Subscribe(UpdateItemList);
        }

        private void UpdateItemList(EventParam obj) => DropManager.RemoveDropedPlayer(obj, PlayerPosition.Selected, WaitUsers);

        #region Command

        public ICommand DropCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>(e => DropManager.AddDropedPlayerAndFireUpdateEvent(e, WaitUsers, _eventAggregator, PlayerPosition.Selected));
            }
        }

        public ICommand DragEnterCommand
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {

                });
            }
        }

        public ICommand DragLeaveCommand
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {

                });
            }
        }
        #endregion
    }


}
