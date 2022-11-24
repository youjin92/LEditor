using LEditor.Common;
using LEditor.Common.Draggables;
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

namespace LEditor.Usercontrols
{
    /// <summary>
    /// PlayerControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
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
            DependencyProperty.Register("Player", typeof(Player), typeof(PlayerControl), new FrameworkPropertyMetadata(null, OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayerControl obj = d as PlayerControl;

            Player NewPlayer = e.NewValue as Player;

            obj.NameTB.Text = NewPlayer.Name.ToString();
            obj.RankTB.Text = NewPlayer.Rank.ToString();

            if (NewPlayer.State == PlayerState.LeftTeam)
                obj.LeftButton.Visibility = Visibility.Collapsed;

            if (NewPlayer.State == PlayerState.RightTeam)
                obj.RightButton.Visibility = Visibility.Collapsed;

        }

    }
}
