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

        public int MaxCount { get; set; } = AppInstance.Instance.WaitUsers.Count;

        public WaitPlayerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<RemovePlayerInWaitViewEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInWaitViewEvent>().Subscribe(AddPlayer);
        }

        private void AddPlayer(EventParam obj)
        {
            var player = obj.Item as Player;

            if (!WaitUsers.Contains(player))
                WaitUsers.Add(player);
        }

        private void RemovePlayer(EventParam obj)
        {
            var player = obj.Item as Player;

            if (WaitUsers.Contains(player))
                WaitUsers.Remove(player);
        }


        #region Command

        public ICommand DropCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>((e) =>
                {
                    //Move
                    DropManager.Instance.DropedPosition = PlayerPosition.Wait;
                    DropManager.Instance.Move(_eventAggregator);
                });
            }
        }

        public ICommand DragEnterCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>((e) =>
                {
                    var DragedPlayer = e.Data.GetData("Player") as Player;

                    if (DragedPlayer != null && !DropManager.Instance.isDragged)
                    {
                        DropManager.Instance.SetDraggedPlayer(DragedPlayer);
                        DropManager.Instance.DragedPosition = PlayerPosition.Wait;
                    }
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
