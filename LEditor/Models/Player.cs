using LEditor.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LEditor.Models
{
    public class Player : BindableBase
    {
        public string Name { get; set; } = "Name";
        public int MMR { get; set; } = 0;
        public Rank Rank { get; set; }
        public InGamePosition Position { get; set; }
        public PlayerPosition State { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool IsEqual(Player player)
        {
            if (player.Name == Name)
                return true;
            return false;
        }
    }

    public class RandomTeamPlayers : BindableBase
    {
        public int Index { get; set; }
        public int Score { get; set; }

        public string RedTeam
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < RedTeamPlayers.Count; i++)
                {
                    if (i == (RedTeamPlayers.Count - 1))
                        stringBuilder.Append(RedTeamPlayers[i].Name);
                    else
                        stringBuilder.AppendLine(RedTeamPlayers[i].Name);
                }

                return stringBuilder.ToString();
            }
        }

        public string BlueTeam
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < BlueTeamPlayers.Count; i++)
                {
                    if (i == (BlueTeamPlayers.Count - 1))
                        stringBuilder.Append(BlueTeamPlayers[i].Name);
                    else
                        stringBuilder.AppendLine(BlueTeamPlayers[i].Name);
                }

                return stringBuilder.ToString();
            }
        }
        public ObservableCollection<Player> RedTeamPlayers { get; set; }
        public ObservableCollection<Player> BlueTeamPlayers { get; set; }
    }
}
