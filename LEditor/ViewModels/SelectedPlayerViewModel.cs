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
using LEditor.Common;
using LEditor.Services;
using LEditor.AppConfig;
using LEditor.Usercontrols;

namespace LEditor.ViewModels
{
    public class SelectedPlayerViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApplicationCommands _applicationCommands;
        public PlayerControl CurrentPlayerControl = null;

        public ObservableCollection<Player> WaitUsers { get; set; } = new ObservableCollection<Player>();

        public SelectedPlayerViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;

            _applicationCommands.RandomTeamMatchingCommand.RegisterCommand(InitSelectedUsers);

            _eventAggregator.GetEvent<RemovePlayerInSelectViewEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInSelectViewEvent>().Subscribe(AddPlayer);

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
                    DropManager.Instance.DropedPosition = PlayerPosition.Selected;
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
                        DropManager.Instance.DragedPosition = PlayerPosition.Selected;
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

        public ICommand InitSelectedUsers
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {
                    AppInstance.Instance.RandomTeamMatchingUsers = WaitUsers;
                    AppInstance.Instance.TeamMatchingLogic();
                });
            }
        }
        #endregion
    }


}
