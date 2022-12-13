using LEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LEditor.Common;

namespace LEditor.Usercontrols
{
    /// <summary>
    /// WaitPlayer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WaitPlayer : UserControl
    {
        public WaitPlayer()
        {
            InitializeComponent();
        }


        public Player Player
        {
            get { return (Player)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register("Player", typeof(Player), typeof(WaitPlayer), new FrameworkPropertyMetadata(null, OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WaitPlayer obj = d as WaitPlayer;

            Player NewPlayer = e.NewValue as Player;

            obj.NameTB.Text = NewPlayer.Name.ToString();
            obj.RankTB.Text = NewPlayer.Rank.ToString();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.DataContext is Player player)
            {
                switch (button.Name)
                {
                    case ButtonDirection.LeftButton:
                        {
                            player.State = PlayerPosition.LeftTeam;
                            break;
                        }
                    case ButtonDirection.RightButton:
                        {
                            player.State = PlayerPosition.RightTeam;
                            break;
                        }
                    //case ButtonDirection.DownButton:
                    //    {
                    //        player.State = PlayerPosition.None;
                      
                    //        break;
                    //    }
                    default:
                        break;
                }
            }


        }
    }
}
