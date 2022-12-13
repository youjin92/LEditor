using LEditor.Common;
using LEditor.Models;
using LEditor.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LEditor.AppConfig
{
    public class AppInstance : Singleton<AppInstance>
    {
        public ObservableCollection<Player> WaitUsers { get; set; } = new ObservableCollection<Player>();

        public string INIPath { get; set; } = Path.Combine(System.Environment.CurrentDirectory, "Player.ini");
        IniFile MainInI = new IniFile();

        public Brush LeftTeamColor = Brushes.PaleVioletRed;
        public Brush RightTeamColor = Brushes.DarkSlateBlue;

        public AppInstance()
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

        #endregion
    }
}
