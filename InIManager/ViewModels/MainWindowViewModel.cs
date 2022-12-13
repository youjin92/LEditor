using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;

namespace InIManager.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public string INIPath { get; set; } = Path.Combine(System.Environment.CurrentDirectory, "Player.ini");

        #region 프로퍼티
        public string Title { get; set; } = "InIManager";
        public ObservableCollection<Player> ItemList { get; set; } = new ObservableCollection<Player>();

        private Player _ModifiedPlayer = new Player();
        public Player ModifiedPlayer {
            get
            {
                if (_ModifiedPlayer == null && ItemList.Count > 0)
                    _ModifiedPlayer = ItemList[0];
                return _ModifiedPlayer;
            } 
            set
            {
                _ModifiedPlayer = value;
                RaisePropertyChanged();
            }
        } 
        #endregion

        #region 필드
        IniFile MainInI = new IniFile();
        #endregion

        public MainWindowViewModel()
        {
            ReloadItemList();
        }

        #region 함수

        private void ReloadItemList()
        {
            if (!File.Exists(INIPath))
            {
                MainInI.Save(INIPath);
            }

            MainInI.Load(INIPath);

            if (MainInI.Keys.Count > 0)
            {
                ItemList.Clear();
                foreach (var section in MainInI.Keys)
                {
                    ItemList.Add(ToPlayerFromMainInI(section.ToString()));
                }
            }
        }

        private Player ToPlayerFromMainInI(string Section)
        {
            Player player   = new Player();
            player.Name     = MainInI[Section]["Name"].ToString();
            player.MMR      = MainInI[Section]["MMR"].ToInt();
            player.Rank     = EnumUtil<Rank>.Parse(MainInI[Section]["Rank"].ToString());
            player.Position = EnumUtil<Position>.Parse(MainInI[Section]["Position"].ToString());
            player.State    = EnumUtil<PlayerState>.Parse(MainInI[Section]["State"].ToString());

            return player;
        }

        private void MakeBlankPlayer()
        {
            ModifiedPlayer.Name = "";
            ModifiedPlayer.MMR = 0;
            ModifiedPlayer.Rank = Rank.Iron;
            ModifiedPlayer.Position = Position.Top;
            ModifiedPlayer.State = PlayerState.None;
        }

        #endregion

        #region Command
        public ICommand ClickCommand
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {
                    switch (e.ToString())
                    {
                        case "불러오기":
                            {
                                ReloadItemList();

                                break;
                            }

                        case "추가":
                            {
                                Player AddPlayer = new Player();
                                ItemList.Add(AddPlayer);

                                ModifiedPlayer = AddPlayer;
                                break;
                            }

                        case "저장":
                            {
                                if (string.IsNullOrEmpty(ModifiedPlayer.Name))
                                    return;

                                MainInI[ModifiedPlayer.Name]["Name"] = ModifiedPlayer.Name.ToString();
                                MainInI[ModifiedPlayer.Name]["MMR"] = ModifiedPlayer.MMR.ToString();
                                MainInI[ModifiedPlayer.Name]["Rank"] = ModifiedPlayer.Rank.ToString();
                                MainInI[ModifiedPlayer.Name]["Position"] = ModifiedPlayer.Position.ToString();
                                MainInI[ModifiedPlayer.Name]["State"] = ModifiedPlayer.State.ToString();

                                MainInI.Save(INIPath);

                                ReloadItemList();
                                break;
                            }

                        case "초기화":
                            {
                                MakeBlankPlayer();
                                break;
                            }

                        case "삭제(Name입력 필수)":
                            {
                                if (MainInI.Keys.Contains(ModifiedPlayer.Name))
                                {
                                    MainInI.Remove(ModifiedPlayer.Name);
                                    MainInI.Save(INIPath);
                                    
                                    if (ItemList.Count > 0)
                                    {
                                        ModifiedPlayer = ItemList[0];
                                        MakeBlankPlayer();
                                    }

                                    ReloadItemList();
                                }
                                break;
                            }

                        default:
                            break;
                    }
                });
            }
        }

        public ICommand MouseDoubleClickCommand
        {
            get
            {
                return new DelegateCommand<MouseButtonEventArgs>((e) =>
                {
                    if (e.OriginalSource is TextBlock textBlock)
                    {
                        if (textBlock.DataContext is Player player)
                        {
                            ModifiedPlayer.Name = player.Name;
                            ModifiedPlayer.MMR = player.MMR;
                            ModifiedPlayer.Rank = player.Rank;
                            ModifiedPlayer.Position = player.Position;
                            ModifiedPlayer.State = player.State;
                        }
                    }
                });
            }
        }
        #endregion
    }
}
