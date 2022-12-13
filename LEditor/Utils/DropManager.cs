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
    public static class DropManager
    {
        public static void AddDropedPlayerAndFireUpdateEvent(DragEventArgs _args, ObservableCollection<Player> _WaitUsers, IEventAggregator _eventAggregator, PlayerPosition _DropedPosition)
        {
            var Player = _args.Data.GetData("Player") as Player;

            if (!_WaitUsers.Contains(Player))
                _WaitUsers.Add(Player);

            _eventAggregator.GetEvent<UpdatePlayerEvent>().Publish(new EventParam(_Item: Player, _dropedPos: _DropedPosition));
        }

        public static void RemoveDropedPlayer(EventParam obj, PlayerPosition CheckPosition, ObservableCollection<Player> _WaitUsers)
        {
            var CheckPlayer = obj.Item as Player;
            var DropedPos = (PlayerPosition)obj.DropedPosition;

            if (DropedPos != CheckPosition &&
                _WaitUsers.Contains(CheckPlayer))
                _WaitUsers.Remove(CheckPlayer);
        }
    }
}
