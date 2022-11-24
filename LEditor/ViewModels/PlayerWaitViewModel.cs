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
    public class PlayerWaitViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<Player> WaitItemList { get; set; } = new ObservableCollection<Player>();

        public PlayerWaitViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<GoToWaitViewEvent>().Subscribe(AddWaitItemList);
            _eventAggregator.GetEvent<GoToLeftViewEvent>().Subscribe(RemoveWaitItemList);
            _eventAggregator.GetEvent<GoToRightViewEvent>().Subscribe(RemoveWaitItemList);
            _eventAggregator.GetEvent<GoToSelectViewEvent>().Subscribe(RemoveWaitItemList);
        }

        private void AddWaitItemList(EventParam obj)
        {
            WaitItemList.Add(obj.Item as Player);
        }

        private void RemoveWaitItemList(EventParam obj)
        {
            if(WaitItemList.Contains(obj.Item as Player))
                WaitItemList.Remove(obj.Item as Player);
        }

        public override void Executed(object target, ExecutedRoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && 
                button.DataContext is Player player)
            {
                switch (button.Name)
                {
                    case ButtonDirection.LeftButton:
                        {
                            player.State = PlayerState.LeftTeam;
                            _eventAggregator.GetEvent<GoToLeftViewEvent>().Publish(new EventParam(_Item: player));
                            break;
                        }
                    case ButtonDirection.RightButton:
                        {
                            player.State = PlayerState.RightTeam;
                            _eventAggregator.GetEvent<GoToRightViewEvent>().Publish(new EventParam(_Item: player));
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
        public override void CanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
