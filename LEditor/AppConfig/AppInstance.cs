using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Utils;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LEditor.AppConfig
{
    public class AppInstance : Singleton<AppInstance>
    {
        public AppInstance()
        {
            ReloadItemList();
        }

        #region 팀매칭 
        public ObservableCollection<Player> RandomTeamMatchingUsers { get; set; } = new ObservableCollection<Player>();

        public Dictionary<int, List<List<ObservableCollection<Player>>>> ScoreDiffDictionary = new Dictionary<int, List<List<ObservableCollection<Player>>>> ();
        //public ManualResetEvent mre = new ManualResetEvent(false);

        public void TeamMatchingLogic()
        {
            if (RandomTeamMatchingUsers.Count != 10)
            {
                MessageBox.Show("10명 만들어라!");
                return;
            }

            ScoreDiffDictionary.Clear();

            //10개 조
            //var testt = RandomTeamMatchingUsers[0];
            int TotalMMR = 0;
            foreach (var User in RandomTeamMatchingUsers)
                TotalMMR += User.MMR;

            int TargetMMR = TotalMMR / 2;

            ObservableCollection<Player> snapList = new ObservableCollection<Player>();

            Combination c = new Combination(10,5);

            while (c != null)
            {
                
                snapList = c.ApplyTo(RandomTeamMatchingUsers);
                int SumScore = SumListMMR(snapList);
                int CounterTeamScore = TotalMMR - SumListMMR(snapList);
                int ScoreDiff = Math.Abs(CounterTeamScore - SumScore);

                AddItemToDictionary(ScoreDiffDictionary, ScoreDiff, new List<ObservableCollection<Player>> { snapList, GetVSTeam(snapList) });
                c = c.Successor();
            }


        }

        private void AddItemToDictionary(Dictionary<int, List<List<ObservableCollection<Player>>>> Dic, int key, List<ObservableCollection<Player>> Item)
        {
            if (ScoreDiffDictionary.ContainsKey(key))
            {
                //검사
                foreach (List < ObservableCollection < Player >>  itemList in Dic[key])
                {
                    int FindCount = 0;

                    foreach (var item in Item[0])
                    {
                        foreach (var item2 in itemList[0])
                        {
                            if (item2.IsEqual(item))
                                FindCount++;
                        }
                    }
                    if (FindCount == 5 || FindCount == 0)
                        return;
                }

                Dic[key].Add(Item);
            }
            else
                Dic[key] = new List<List<ObservableCollection<Player>>> { Item };

        }

        private void DisplayConsole(ObservableCollection<Player> snapShotList)
        {
            Console.Write("{ ");
            foreach (var item in snapShotList)
            {
                Console.Write(item.Name+" ");
            }
            Console.WriteLine("}");
        }

        private int SumListMMR(ObservableCollection<Player> snapShotList)
        {
            int MMR = 0;
            foreach (var item in snapShotList)
            {
                MMR += item.MMR;
            }

            return MMR;
        }

        private ObservableCollection<Player> GetVSTeam(ObservableCollection<Player> snapShotList)
        {
            ObservableCollection<Player> vsTeam = new ObservableCollection<Player>();

            foreach (var item in RandomTeamMatchingUsers)
            {
                bool Find = false;
                foreach (var removeItem in snapShotList)
                {
                    if (item.IsEqual(removeItem))
                        Find = true;
                }

                if (!Find)
                    vsTeam.Add(item);
            }

            return vsTeam;
        }

        #endregion
        public ObservableCollection<Player> WaitUsers { get; set; } = new ObservableCollection<Player>();

        public ObservableCollection<Player> MatchedRedBlueTeamUsers { get; set; } = new ObservableCollection<Player>();

        public string INIPath { get; set; } = Path.Combine(System.Environment.CurrentDirectory, "Player.ini");
        IniFile MainInI = new IniFile();

        public int LeftTeamTotalMMR { get; set; } = 0;
        public int RightTeamTotalMMR { get; set; } = 0;

        public int LeftTeamVictoryRate { get
            {
                if(LeftTeamTotalMMR != 0 || RightTeamTotalMMR != 0)
                    return (LeftTeamTotalMMR * 100) / (LeftTeamTotalMMR + RightTeamTotalMMR) ;
                return 0;
            }
        }

        public int RightTeamVictoryRate
        {
            get
            {
                if (LeftTeamTotalMMR != 0 || RightTeamTotalMMR != 0)
                    return (RightTeamTotalMMR * 100) / (LeftTeamTotalMMR + RightTeamTotalMMR) ;
                return 0;
            }
        }

        public Brush LeftTeamColor = Brushes.DimGray;
        public Brush RightTeamColor = Brushes.DimGray;

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
                WaitUsers.Clear();
                foreach (var section in MainInI.Keys)
                {
                    WaitUsers.Add(ToPlayerFromMainInI(section.ToString()));
                }
            }
        }

        private Player ToPlayerFromMainInI(string Section)
        {
            Player player = new Player();
            player.Name = MainInI[Section]["Name"].ToString();
            player.MMR = MainInI[Section]["MMR"].ToInt();
            player.Rank = EnumUtil<Rank>.Parse(MainInI[Section]["Rank"].ToString());
            player.Position = EnumUtil<InGamePosition>.Parse(MainInI[Section]["Position"].ToString());
            player.State = EnumUtil<PlayerPosition>.Parse(MainInI[Section]["State"].ToString());

            return player;
        }

        public  void UpdateTeamDetailInfo(IEventAggregator _eventAggregator)
        {
            _eventAggregator.GetEvent<UpdateTeamDetailInfoEvent>().Publish(new EventParam(_Item: null));
            _eventAggregator.GetEvent<RefreshTeamDetailInfoEvent>().Publish(new EventParam(_Item: null));
        }
        #endregion
    }
}
