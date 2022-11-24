﻿using LEditor.Common;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace LEditor.ViewModels
{
    public class PlayerMirrorViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<Player> RightItemList { get; set; } = new ObservableCollection<Player>();

        public PlayerMirrorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<GoToWaitViewEvent>().Subscribe(RemoveItemList);
            _eventAggregator.GetEvent<GoToRightViewEvent>().Subscribe(AddItemList);
            _eventAggregator.GetEvent<GoToSelectViewEvent>().Subscribe(RemoveItemList);
        }

        private void RemoveItemList(EventParam obj)
        {
            if (RightItemList.Contains(obj.Item as Player))
                RightItemList.Remove(obj.Item as Player);
        }

        private void AddItemList(EventParam obj)
        {
            RightItemList.Add(obj.Item as Player);
        }

        public override void Executed(object target, ExecutedRoutedEventArgs e)
        {
            if (e.OriginalSource is Button button &&
                button.DataContext is Player player)
            {
                switch (button.Name)
                {
                    case ButtonDirection.LeftButton:
                    case ButtonDirection.RightButton:
                        {
                            player.State = PlayerState.Wait;
                            _eventAggregator.GetEvent<GoToWaitViewEvent>().Publish(new EventParam(_Item: player));
                            break;
                        }
                    case ButtonDirection.DownButton:
                        {
                            player.State = PlayerState.None;
                            _eventAggregator.GetEvent<GoToSelectViewEvent>().Publish(new EventParam(_Item: player));
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        #region Command

        public ICommand MouseMoveCommand
        {
            get
            {
                return new DelegateCommand<MouseEventArgs>((e) =>
                {
                    DataGridHelper.MouseMove(e);
                });
            }
        }
        #endregion
    }
}
