using LEditor.AppConfig;
using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Utils;
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

namespace LEditor.ViewModels
{
    public class WaitPlayerViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public string Title { get; set; } = "Wait Player";
        public ObservableCollection<Player> WaitUsers { get; set; } = AppInstance.Instance.WaitUsers;


        public WaitPlayerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<UpdatePlayerEvent>().Subscribe(UpdateItemList);

        }

        private void UpdateItemList(EventParam obj) => DropManager.RemoveDropedPlayer(obj, PlayerPosition.Wait, WaitUsers);

        #region Command

        public ICommand DropCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>(e => DropManager.AddDropedPlayerAndFireUpdateEvent(e, WaitUsers, _eventAggregator, PlayerPosition.Wait));
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
