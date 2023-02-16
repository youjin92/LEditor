using LEditor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Utils
{
    public class UtilManager
    {
        public static Uri GetRankImage(Rank rank)
        {
            Uri uriSource;
            switch (rank)
            {
                case Rank.Iron:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Iron.png");
                    break;
                case Rank.Bronze1:
                case Rank.Bronze2:
                case Rank.Bronze3:
                case Rank.Bronze4:
                case Rank.Bronze5:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Bronze.png");
                    break;
                case Rank.Silver1:
                case Rank.Silver2:
                case Rank.Silver3:
                case Rank.Silver4:
                case Rank.Silver5:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Silver.png");
                    break;
                case Rank.Gold1:
                case Rank.Gold2:
                case Rank.Gold3:
                case Rank.Gold4:
                case Rank.Gold5:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Gold.png");
                    break;
                case Rank.Pletinum1:
                case Rank.Pletinum2:
                case Rank.Pletinum3:
                case Rank.Pletinum4:
                case Rank.Pletinum5:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Pletinum.png");
                    break;
                case Rank.Diamond1:
                case Rank.Diamond2:
                case Rank.Diamond3:
                case Rank.Diamond4:
                case Rank.Diamond5:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Diamond.png");
                    break;
                default:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/User-icon.png");
                    break;
            }

            return uriSource;
        }
    }
}
