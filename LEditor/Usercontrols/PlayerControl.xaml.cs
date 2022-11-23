using LEditor.Common.Draggables;
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
        }

        public string NameDisplay { get; set; }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(PlayerControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayerControl obj = d as PlayerControl;

            obj.NameDisplay = e.NewValue.ToString();
        }

    }
}
