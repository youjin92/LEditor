using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InIManager.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public string Title { get; set; } = "InIManager";
        public string LoadAddress { get; set; } = @"C:\Player.ini";
        public ObservableCollection<Player> ItemList { get; set; } = new ObservableCollection<Player>();
        public Player ModifiedPlayer { get; set; }


        IniFile MainInI = new IniFile();

        public MainWindowViewModel()
        {
            MainInI.Save(LoadAddress);
        }

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
                                MainInI.Load(LoadAddress);

                                if (MainInI.Keys.Count > 0)
                                {
                                    ItemList.Clear();
                                    foreach (var section in MainInI.Keys)
                                    {
                                        Player play = new Player();
                                        play.Name = MainInI[section]["Name"].ToString();
                                        play.Rank = (Rank)MainInI[section]["Rank"].ToInt();
                                        play.Position = (Position)MainInI[section]["Position"].ToInt();
                                        play.State = (PlayerState)MainInI[section]["State"].ToInt();

                                        ItemList.Add(play);
                                    }
                                }


                                //IniFile ini = new IniFile();
                                //ini["Test1"]["Name"] = "해리포터";
                                //ini["Test1"]["Rank"] = "블리자드";

                                //ini["Test2"]["Name"] = "파랑새";
                                //ini["Test2"]["Rank"] = "붉은노을";

                                //ini["Test3"]["Name"] = "노랑새";
                                //ini["Test3"]["Rank"] = "새우잡이";

                                ////IniFile ini2 = new IniFile();
                                ////ini2["Test4"]["Name"] = "슈퍼";
                                ////ini2["Test4"]["Rank"] = "마켓";

                                ////ini.Clear();
                                //var boolt = ini.ContainsSection("Test3");
                                //var boolt2 = ini.ContainsSection("Test4");

                                //var a = ini.Keys;


                                //ini.Save(@"C:\Player.ini");
                                break;
                            }

                        case "저장":
                            {
                                MainInI[ModifiedPlayer.Name]["Name"] = ModifiedPlayer.Name;
                                MainInI[ModifiedPlayer.Name]["Name"] = ModifiedPlayer.Name;
                                MainInI[ModifiedPlayer.Name]["Name"] = ModifiedPlayer.Name;
                                MainInI[ModifiedPlayer.Name]["Name"] = ModifiedPlayer.Name;
                                break;
                            }

                        default:
                            break;
                    }
                });
            }
        }
        #endregion
    }
}
