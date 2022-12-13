using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Usercontrols;
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
    public class PlayerSettingViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly PlayerPosition playerPosition;

        public Player TopPlayer { get; set; } = new Player { Name = "" };
        public Player JunglePlayer { get; set; } = new Player { Name = "" };
        public Player MidPlayer { get; set; } = new Player { Name = "" };
        public Player AdPlayer { get; set; } = new Player { Name = "" };
        public Player SupportPlayer { get; set; } = new Player { Name = "" };

        public PlayerSettingViewModel(IEventAggregator eventAggregator, PlayerPosition _PlayerPosition)
        {
            _eventAggregator = eventAggregator;

            playerPosition = _PlayerPosition;

            _eventAggregator.GetEvent<UpdatePlayerEvent>().Subscribe(UpdateItemList);
        }

        private void UpdateItemList(EventParam obj)
        {
            var CheckPlayer = obj.Item as Player;
            var DropedPos = obj.DropedPosition;
            var DropedInGamePosition = obj.InGamePosition;

            if (DropedPos != playerPosition &&
                IsContain(CheckPlayer))
                InitPlayer((FindInGamePostion(CheckPlayer))[0]);

            if (DropedPos == playerPosition)
            {
                if (Count(CheckPlayer) > 1)
                {
                    List<InGamePosition> RemoveList = FindInGamePostion(CheckPlayer);
                    foreach (var item in RemoveList)
                    {
                        if (item != DropedInGamePosition)
                            InitPlayer(item);
                    }

                }
            }
                
        }


        private int Count(Player CheckPlayer)
        {
            return FindInGamePostion(CheckPlayer).Count;
        }

        private bool IsContain(Player CheckPlayer)
        {
            return FindInGamePostion(CheckPlayer).Count > 0;
        }

        private void InitPlayer(InGamePosition _InGamePosition, Player player = null)
        {
            Player InitPlayer = player;
            if (player == null || string.IsNullOrEmpty(player.Name))
                InitPlayer = new Player { Name = "" };

            switch (_InGamePosition)
            {
                case InGamePosition.None:
                    break;
                case InGamePosition.Top:
                    TopPlayer = InitPlayer;
                    break;
                case InGamePosition.Jungle:
                    JunglePlayer = InitPlayer;
                    break;
                case InGamePosition.Mid:
                    MidPlayer = InitPlayer;
                    break;
                case InGamePosition.AD:
                    AdPlayer = InitPlayer;
                    break;
                case InGamePosition.Support:
                    SupportPlayer = InitPlayer;
                    break;
                default:
                    break;
            }
        }

        private List<InGamePosition> FindInGamePostion(Player CheckPlayer)
        {
            List<InGamePosition> List = new List<InGamePosition>();

            if (TopPlayer.Equals(CheckPlayer))
                List.Add(InGamePosition.Top);
            if (JunglePlayer.Equals(CheckPlayer))
                List.Add(InGamePosition.Jungle);
            if (MidPlayer.Equals(CheckPlayer))
                List.Add(InGamePosition.Mid);
            if (AdPlayer.Equals(CheckPlayer))
                List.Add(InGamePosition.AD);
            if (SupportPlayer.Equals(CheckPlayer))
                List.Add(InGamePosition.Support);

            return List;
        }

        #region Command

        public ICommand DropCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>((e) =>
                {
                    var dropedPlayer = e.Data.GetData("Player") as Player;

                    PlayerControl playerControl = e.Source as PlayerControl;
                    playerControl.Player = dropedPlayer;
                    InGamePosition DropedInGamePosition = InGamePosition.None;

                    if (playerControl.Name == "Top")
                        DropedInGamePosition = InGamePosition.Top;
                    else if (playerControl.Name == "Jungle")
                        DropedInGamePosition = InGamePosition.Jungle;
                    else if (playerControl.Name == "Mid")
                        DropedInGamePosition = InGamePosition.Mid;
                    else if (playerControl.Name == "AD")
                        DropedInGamePosition = InGamePosition.AD;
                    else if (playerControl.Name == "Support")
                        DropedInGamePosition = InGamePosition.Support;

                    InitPlayer(DropedInGamePosition, dropedPlayer);

                    _eventAggregator.GetEvent<UpdatePlayerEvent>().Publish(new EventParam(_Item: dropedPlayer, _dropedPos: playerPosition,_InGamePosition: DropedInGamePosition));
                });
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
