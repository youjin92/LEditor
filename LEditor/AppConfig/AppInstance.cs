using LEditor.Common;
using LEditor.Models;
using LEditor.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LEditor.AppConfig
{
    public class AppInstance : Singleton<AppInstance>
    {
        public ObservableCollection<Player> WaitUsers { get; set; } = new ObservableCollection<Player>() { new Player { Name = "시묘0", Rank = Rank.Gold, Position = InGamePosition.Top } };

        public Brush LeftTeamColor = Brushes.DarkRed;
        public Brush RightTeamColor = Brushes.DarkBlue;

        public AppInstance()
        {

            WaitUsers.Add(new Player { Name = "시묘1", Rank = Rank.Bronze, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘2", Rank = Rank.Iron, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘3", Rank = Rank.Silver, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘4", Rank = Rank.Pletinum, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘5", Rank = Rank.Diamond, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘6", Rank = Rank.Gold, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘7", Rank = Rank.Iron, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘8", Rank = Rank.Gold, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘9", Rank = Rank.Gold, Position = InGamePosition.Top });
            WaitUsers.Add(new Player { Name = "시묘10", Rank = Rank.Gold, Position = InGamePosition.Top });
        }
    }
}
