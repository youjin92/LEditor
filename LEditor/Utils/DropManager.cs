using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LEditor.Utils
{
    public class DropManager : Singleton<DropManager>
    {
        public bool isDragged = false;

        public Player DragedPlayer = new Player { Name = "" };
        public Player DropedPlayer = new Player { Name = "" };

        public PlayerPosition DragedPosition = PlayerPosition.None;
        public PlayerPosition DropedPosition = PlayerPosition.None;

        public void Move(IEventAggregator _eventAggregator)
        {
            FireRemovePlayerEvent(_eventAggregator, DragedPosition, DragedPlayer);
            FireAddPlayerEvent(_eventAggregator, DropedPosition, DragedPlayer);
            isDragged = false;
        }

        public void Copy(IEventAggregator _eventAggregator)
        {
            FireAddPlayerEvent(_eventAggregator, DropedPosition, DragedPlayer);
            isDragged = false;
        }

        public void Change(IEventAggregator _eventAggregator)
        {
            FireRemovePlayerEvent(_eventAggregator, DragedPosition, DragedPlayer);
            FireRemovePlayerEvent(_eventAggregator, DropedPosition, DropedPlayer);
            FireAddPlayerEvent(_eventAggregator, DragedPosition, DropedPlayer);
            FireAddPlayerEvent(_eventAggregator, DropedPosition, DragedPlayer);
            isDragged = false;
        }

        private void FireRemovePlayerEvent(IEventAggregator _eventAggregator, PlayerPosition RemovePosition, Player player)
        {
            player.State = RemovePosition;
            switch (RemovePosition)
            {
                case PlayerPosition.Wait:
                    _eventAggregator.GetEvent<RemovePlayerInWaitViewEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.Selected:
                    _eventAggregator.GetEvent<RemovePlayerInSelectViewEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftTop:
                    _eventAggregator.GetEvent<RemovePlayerInLeftTopEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftJug:
                    _eventAggregator.GetEvent<RemovePlayerInLeftJungleEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftMid:
                    _eventAggregator.GetEvent<RemovePlayerInLeftMidEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftAd:
                    _eventAggregator.GetEvent<RemovePlayerInLeftADEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftSupport:
                    _eventAggregator.GetEvent<RemovePlayerInLeftSupportEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightTop:
                    _eventAggregator.GetEvent<RemovePlayerInRightTopEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightJug:
                    _eventAggregator.GetEvent<RemovePlayerInRightJungleEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightMid:
                    _eventAggregator.GetEvent<RemovePlayerInRightMidEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightAd:
                    _eventAggregator.GetEvent<RemovePlayerInRightADEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightSupport:
                    _eventAggregator.GetEvent<RemovePlayerInRightSupportEvent>().Publish(new EventParam(_Item: player));
                    break;
                default:
                    break;
            }
        }

        private void FireAddPlayerEvent(IEventAggregator _eventAggregator, PlayerPosition AddPosition, Player player)
        {
            player.State = AddPosition;
            switch (AddPosition)
            {
                case PlayerPosition.Wait:
                    _eventAggregator.GetEvent<AddPlayerInWaitViewEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.Selected:
                    _eventAggregator.GetEvent<AddPlayerInSelectViewEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftTop:
                    _eventAggregator.GetEvent<AddPlayerInLeftTopEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftJug:
                    _eventAggregator.GetEvent<AddPlayerInLeftJungleEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftMid:
                    _eventAggregator.GetEvent<AddPlayerInLeftMidEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftAd:
                    _eventAggregator.GetEvent<AddPlayerInLeftADEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.LeftSupport:
                    _eventAggregator.GetEvent<AddPlayerInLeftSupportEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightTop:
                    _eventAggregator.GetEvent<AddPlayerInRightTopEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightJug:
                    _eventAggregator.GetEvent<AddPlayerInRightJungleEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightMid:
                    _eventAggregator.GetEvent<AddPlayerInRightMidEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightAd:
                    _eventAggregator.GetEvent<AddPlayerInRightADEvent>().Publish(new EventParam(_Item: player));
                    break;
                case PlayerPosition.RightSupport:
                    _eventAggregator.GetEvent<AddPlayerInRightSupportEvent>().Publish(new EventParam(_Item: player));
                    break;
                default:
                    break;
            }
        }

        public void SetDraggedPlayer(Player player)
        {
            if (!isDragged)
            {
                DragedPlayer = player;
                isDragged = true;
            }
             
        }

        public void SetDroppedPlayer(Player player)
        {
            DropedPlayer = player;
        }
    }
}
