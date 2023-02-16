using LEditor.Common;
using LEditor.Utils;
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
        public Rank Rank => GetRankFromMMR();
        public InGamePosition Position { get; set; }
        public PlayerPosition State { get; set; }
        private Rank GetRankFromMMR()
        {
            if (MMR >= 2500)
                return Rank.Diamond1;
            else if (MMR >= 2425)
                return Rank.Diamond2;
            else if (MMR >= 2350)
                return Rank.Diamond3;
            else if (MMR >= 2275)
                return Rank.Diamond4;
            else if (MMR >= 2200)
                return Rank.Diamond5;
            else if (MMR >= 2150)
                return Rank.Pletinum1;
            else if (MMR >= 2075)
                return Rank.Pletinum2;
            else if (MMR >= 2000)
                return Rank.Pletinum3;
            else if (MMR >= 1925)
                return Rank.Pletinum4;
            else if (MMR >= 1850)
                return Rank.Pletinum5;
            else if (MMR >= 1800)
                return Rank.Gold1;
            else if (MMR >= 1725)
                return Rank.Gold2;
            else if (MMR >= 1650)
                return Rank.Gold3;
            else if (MMR >= 1575)
                return Rank.Gold4;
            else if (MMR >= 1500)
                return Rank.Gold5;
            else if (MMR >= 1450)
                return Rank.Silver1;
            else if (MMR >= 1375)
                return Rank.Silver2;
            else if (MMR >= 1300)
                return Rank.Silver3;
            else if (MMR >= 1225)
                return Rank.Silver4;
            else if (MMR >= 1150)
                return Rank.Silver5;
            else if (MMR >= 1100)
                return Rank.Bronze1;
            else if (MMR >= 1025)
                return Rank.Bronze2;
            else if (MMR >= 950)
                return Rank.Bronze3;
            else if (MMR >= 875)
                return Rank.Bronze4;
            else if (MMR >= 800)
                return Rank.Bronze5;

            return Rank.Iron;
        }
        public Uri ImageUri => UtilManager.GetRankImage(Rank);

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
