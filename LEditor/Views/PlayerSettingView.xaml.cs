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

namespace LEditor.Views
{
    /// <summary>
    /// PlayerView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerSettingView : UserControl
    {
        public PlayerSettingView()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PlayerSettingView), new FrameworkPropertyMetadata( "PlayList", OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlayerSettingView obj = d as PlayerSettingView;

            string NewTitle = e.NewValue.ToString();

            obj.TitleTB.Text = NewTitle;
        }
    }
}
