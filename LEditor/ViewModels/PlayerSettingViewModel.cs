using LEditor.AppConfig;
using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Services;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LEditor.ViewModels
{
    public class PlayerSettingViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApplicationCommands _applicationCommands;
        private readonly PlayerPosition playerPosition;
        
        public Brush BackgroundColor { get; set; }

        public int TotalMMR
        {
            get
            {
                switch (playerPosition)
                {
                    case PlayerPosition.LeftTeam:
                        return AppInstance.Instance.LeftTeamTotalMMR;
                    case PlayerPosition.RightTeam:
                        return AppInstance.Instance.RightTeamTotalMMR;
                }
                return 0;
            }
        }

        public int AverageMMR
        {
            get
            {
                if (Count() != 0)
                    return TotalMMR / Count();
                return 0;
            } 
        }

        public int VictoryRate
        {
            get
            {
                switch (playerPosition)
                {
                    case PlayerPosition.LeftTeam:
                        return AppInstance.Instance.LeftTeamVictoryRate;
                    case PlayerPosition.RightTeam:
                        return AppInstance.Instance.RightTeamVictoryRate;
                    default:
                        return 0;
                }
            } 
        }

        public Player TopPlayer { get; set; } = new Player { Name = "" };
        public Player JunglePlayer { get; set; } = new Player { Name = "" };
        public Player MidPlayer { get; set; } = new Player { Name = "" };
        public Player AdPlayer { get; set; } = new Player { Name = "" };
        public Player SupportPlayer { get; set; } = new Player { Name = "" };

        public PlayerSettingViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator, PlayerPosition _PlayerPosition)
        {
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;

            playerPosition = _PlayerPosition;

            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    BackgroundColor = AppInstance.Instance.LeftTeamColor;
                    break;
                case PlayerPosition.RightTeam:
                    BackgroundColor = AppInstance.Instance.RightTeamColor;
                    break;
                default:
                    break;
            }



            #region 이벤트 설정

            _applicationCommands.ResetTeamCommand.RegisterCommand(InitPlayerControl);
            _eventAggregator.GetEvent<RandomTeamMatchingEvent>().Subscribe(RandomUpdateItemList);

            _eventAggregator.GetEvent<RemovePlayerInLeftTopEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInLeftTopEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInLeftJungleEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInLeftJungleEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInLeftMidEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInLeftMidEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInLeftADEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInLeftADEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInLeftSupportEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInLeftSupportEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInRightTopEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInRightTopEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInRightJungleEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInRightJungleEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInRightMidEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInRightMidEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInRightADEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInRightADEvent>().Subscribe(AddPlayer);
            _eventAggregator.GetEvent<RemovePlayerInRightSupportEvent>().Subscribe(RemovePlayer);
            _eventAggregator.GetEvent<AddPlayerInRightSupportEvent>().Subscribe(AddPlayer);

            _eventAggregator.GetEvent<UpdateTeamDetailInfoEvent>().Subscribe(SendDetailInfo);
            _eventAggregator.GetEvent<RefreshTeamDetailInfoEvent>().Subscribe(RefreshDetailInfo);

            #endregion
        }


        private void RefreshDetailInfo(EventParam obj)
        {
            RaisePropertyChanged("TotalMMR");
            RaisePropertyChanged("AverageMMR");
            RaisePropertyChanged("VictoryRate");
        }

        private void SendDetailInfo(EventParam obj)
        {
            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    AppInstance.Instance.LeftTeamTotalMMR = TopPlayer.MMR + JunglePlayer.MMR + MidPlayer.MMR + AdPlayer.MMR + SupportPlayer.MMR;
                    break;
                case PlayerPosition.RightTeam:
                    AppInstance.Instance.RightTeamTotalMMR = TopPlayer.MMR + JunglePlayer.MMR + MidPlayer.MMR + AdPlayer.MMR + SupportPlayer.MMR;
                    break;
            }
        }

        private void AddPlayer(EventParam obj)
        {
            Player player = obj.Item as Player;

            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    {
                        switch (player.State)
                        {
                            case PlayerPosition.LeftTop:
                                TopPlayer = player;
                                break;
                            case PlayerPosition.LeftJug:
                                JunglePlayer = player;
                                break;
                            case PlayerPosition.LeftMid:
                                MidPlayer = player;
                                break;
                            case PlayerPosition.LeftAd:
                                AdPlayer = player;
                                break;
                            case PlayerPosition.LeftSupport:
                                SupportPlayer = player;
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case PlayerPosition.RightTeam:
                    {
                        switch (player.State)
                        {
                            case PlayerPosition.RightTop:
                                TopPlayer = player;
                                break;
                            case PlayerPosition.RightJug:
                                JunglePlayer = player;
                                break;
                            case PlayerPosition.RightMid:
                                MidPlayer = player;
                                break;
                            case PlayerPosition.RightAd:
                                AdPlayer = player;
                                break;
                            case PlayerPosition.RightSupport:
                                SupportPlayer = player;
                                break;
                            default:
                                break;
                        }
                        break;
                    }
            }
        }

        private void RemovePlayer(EventParam obj)
        {
            Player player = obj.Item as Player;

            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    {
                        switch (player.State)
                        {
                            case PlayerPosition.LeftTop:
                                TopPlayer = new Player { Name=""};
                                break;
                            case PlayerPosition.LeftJug:
                                JunglePlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.LeftMid:
                                MidPlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.LeftAd:
                                AdPlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.LeftSupport:
                                SupportPlayer = new Player { Name = "" }; ;
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case PlayerPosition.RightTeam:
                    {
                        switch (player.State)
                        {
                            case PlayerPosition.RightTop:
                                TopPlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.RightJug:
                                JunglePlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.RightMid:
                                MidPlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.RightAd:
                                AdPlayer = new Player { Name = "" }; ;
                                break;
                            case PlayerPosition.RightSupport:
                                SupportPlayer = new Player { Name = "" }; ;
                                break;
                            default:
                                break;
                        }
                        break;
                    }
            }
        }

        private void RandomUpdateItemList(RandomTeamMatchingParam obj)
        {
            RandomTeamPlayers randomTeamPlayers = obj.Item as RandomTeamPlayers;
            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    InitRandomPlayer(randomTeamPlayers.RedTeamPlayers);
                    break;
                case PlayerPosition.RightTeam:
                    InitRandomPlayer(randomTeamPlayers.BlueTeamPlayers);
                    break;
                default:
                    break;
            }

            UpdateTeamDetailInfo();
        }

        private void InitRandomPlayer(ObservableCollection<Player> Players)
        {
            Players[0].Position = InGamePosition.Top;
            Players[1].Position = InGamePosition.Jungle ;
            Players[2].Position = InGamePosition.Mid;
            Players[3].Position = InGamePosition.AD;
            Players[4].Position = InGamePosition.Support;

            TopPlayer = Players[0];
            JunglePlayer = Players[1];
            MidPlayer = Players[2];
            AdPlayer = Players[3];
            SupportPlayer = Players[4];

            //AppInstance.Instance.CheckSelectedPlayer(_eventAggregator);
        }

        private void UpdateTeamDetailInfo()
        {
            AppInstance.Instance.UpdateTeamDetailInfo(_eventAggregator);
        }

        private int Count()
        {
            int i = 0;
            if (!string.IsNullOrEmpty(TopPlayer.Name)) i++;
            if (!string.IsNullOrEmpty(JunglePlayer.Name)) i++;
            if (!string.IsNullOrEmpty(MidPlayer.Name)) i++;
            if (!string.IsNullOrEmpty(AdPlayer.Name)) i++;
            if (!string.IsNullOrEmpty(SupportPlayer.Name)) i++;
            return i;
        }

        private PlayerPosition GetPlayerControlPosition(string Position)
        {
            switch (playerPosition)
            {
                case PlayerPosition.LeftTeam:
                    {
                        switch (Position)
                        {
                            case "Top":
                                return PlayerPosition.LeftTop;
                            case "Jungle":
                                return PlayerPosition.LeftJug;
                            case "Mid":
                                return PlayerPosition.LeftMid;
                            case "AD":
                                return PlayerPosition.LeftAd;
                            case "Support":
                                return PlayerPosition.LeftSupport;
                            default:
                                return PlayerPosition.None;
                        }
                    }
                case PlayerPosition.RightTeam:
                    {
                        switch (Position)
                        {
                            case "Top":
                                return PlayerPosition.RightTop;
                            case "Jungle":
                                return PlayerPosition.RightJug;
                            case "Mid":
                                return PlayerPosition.RightMid;
                            case "AD":
                                return PlayerPosition.RightAd;
                            case "Support":
                                return PlayerPosition.RightSupport;
                            default:
                                return PlayerPosition.None;
                        }
                    }
                default:
                    return PlayerPosition.None;
            }
        }

        #region Command

        public ICommand DropCommand
        {
            get
            {
                return new DelegateCommand<DragEventArgs>((e) =>
                {
                    var playercontrol = e.Source as PlayerControl;
                    var dropedPlayer = playercontrol.Player;
                    PlayerPosition DroppedPosition = GetPlayerControlPosition(playercontrol.Name);

                    //DropManager.Instance.DragedPlayer
                    if (DropManager.Instance.DragedPosition == PlayerPosition.Selected)
                    {
                        //copy
                        DropManager.Instance.DropedPosition = DroppedPosition;
                        DropManager.Instance.Copy(_eventAggregator);
                    }
                    
                    if (dropedPlayer!= null &&
                    DropManager.Instance.DragedPosition == PlayerPosition.LeftTop ||
                    DropManager.Instance.DragedPosition == PlayerPosition.LeftJug ||
                    DropManager.Instance.DragedPosition == PlayerPosition.LeftMid ||
                    DropManager.Instance.DragedPosition == PlayerPosition.LeftAd ||
                    DropManager.Instance.DragedPosition == PlayerPosition.LeftSupport ||
                    DropManager.Instance.DragedPosition == PlayerPosition.RightTop ||
                    DropManager.Instance.DragedPosition == PlayerPosition.RightJug ||
                    DropManager.Instance.DragedPosition == PlayerPosition.RightMid ||
                    DropManager.Instance.DragedPosition == PlayerPosition.RightAd ||
                    DropManager.Instance.DragedPosition == PlayerPosition.RightSupport )
                    {
                        //change
                        DropManager.Instance.DropedPosition = DroppedPosition;
                        DropManager.Instance.SetDroppedPlayer(dropedPlayer);
                        DropManager.Instance.Change(_eventAggregator);
                    }

                    UpdateTeamDetailInfo();

                    //AppInstance.Instance.CheckSelectedPlayer(_eventAggregator);
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

                    var playercontrol = e.Source as PlayerControl;
                    PlayerPosition DragedPosition = GetPlayerControlPosition(playercontrol.Name);

                    if (DragedPlayer != null && !DropManager.Instance.isDragged)
                    {
                        DropManager.Instance.SetDraggedPlayer(DragedPlayer);
                        DropManager.Instance.DragedPosition = DragedPosition;
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

        public ICommand InitPlayerControl
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {
                    TopPlayer = new Player { Name = "" };
                    JunglePlayer = new Player { Name = "" };
                    MidPlayer = new Player { Name = "" };
                    AdPlayer = new Player { Name = "" };
                    SupportPlayer  = new Player { Name = "" };

                    AppInstance.Instance.UpdateTeamDetailInfo(_eventAggregator);

                }); 
            }       
        }           

        #endregion
    }
}
