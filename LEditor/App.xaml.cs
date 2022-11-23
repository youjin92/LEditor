using LEditor.Common;
using LEditor.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PlayerView>();
            containerRegistry.RegisterForNavigation<PlayerMirrorView>();
            containerRegistry.RegisterForNavigation<PlayerSelectView>();
            containerRegistry.RegisterForNavigation<PlayerWaitView>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var RegionManager = Container.Resolve<IRegionManager>();

            RegionManager.RequestNavigate(RegionNames.LeftPlayerExplorer, "PlayerView");
            RegionManager.RequestNavigate(RegionNames.RightPlayerExplorer, "PlayerMirrorView");
            RegionManager.RequestNavigate(RegionNames.SelectPlayerRegion, "PlayerSelectView");
            RegionManager.RequestNavigate(RegionNames.WaitPlayerExplorer, "PlayerWaitView");

        }
    }
}
