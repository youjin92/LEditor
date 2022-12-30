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
    public partial class PlayerControl : Draggable
    {
        public PlayerControl()
        {
            InitializeComponent();
            DragTagName = "Player";
            DragPropertyobject = Player;

            blankBorder.Visibility = Visibility.Visible;

            DragEnterAction += new DragEventHandler(UserControl_DragEnter);
            DropAction += new DragEventHandler(UserControl_Drop);
            DragLeave += new DragEventHandler(UserControl_DragLeave);
        }

        public object BindingParentControl
        {
            get { return (object)GetValue(BindingParentControlProperty); }
            set { SetValue(BindingParentControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingParentControlProperty =
            DependencyProperty.Register("BindingParentControl", typeof(object), typeof(PlayerControl), new FrameworkPropertyMetadata(null, OnParentControlChanged));

        private static void OnParentControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayerControl obj = d as PlayerControl;

            object Newobj = e.NewValue as object;

            obj.ParentControl = Newobj;
        }

        public Player Player
        {
            get { return (Player)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register("Player", typeof(Player), typeof(PlayerControl), new FrameworkPropertyMetadata(new Player { Name = ""}, OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayerControl obj = d as PlayerControl;

            Player NewPlayer = e.NewValue as Player;

            Uri uriSource;
            switch (NewPlayer.Rank)
            {
                case Rank.Iron:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Iron.png");
                    break;
                case Rank.Bronze:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Bronze.png");
                    break;
                case Rank.Silver:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Silver.png");
                    break;
                case Rank.Gold:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Gold.png");
                    break;
                case Rank.Pletinum:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Pletinum.png");
                    break;
                case Rank.Diamond:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/Diamond.png");
                    break;
                default:
                    uriSource = new Uri("pack://application:,,,/LEditor;component/Images/User-icon.png");
                    break;
            }
            obj.ImageControl.Source = new BitmapImage(uriSource); 
            obj.NameTB.Text = NewPlayer.Name.ToString();
            obj.MMRTB.Text = NewPlayer.MMR.ToString();
            obj.DragPropertyobject = NewPlayer;

            if (string.IsNullOrEmpty(obj.NameTB.Text))
            {
                obj.blankBorder.Visibility = Visibility.Visible;
                obj.IsDragable = false;
            }
            else
            {
                obj.blankBorder.Visibility = Visibility.Collapsed;
                obj.IsDragable = true;
            }
        }

        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
            this.rectangle.Stroke = Brushes.Wheat;
            this.rectangle.StrokeDashArray = new DoubleCollection() { 4, 2 };
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            this.rectangle.Stroke = Brushes.Wheat;
            this.rectangle.StrokeDashArray = null;
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
            this.rectangle.Stroke = Brushes.Wheat;
            this.rectangle.StrokeDashArray = null;
        }

    }
}
