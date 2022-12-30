using LEditor.Common;
using LEditor.Services;
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
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

            containerRegistry.RegisterForNavigation<TeamSettingView>();
            containerRegistry.RegisterForNavigation<SelectedPlayerView>();
            containerRegistry.RegisterForNavigation<WaitPlayerView>();
            containerRegistry.RegisterForNavigation<RandomTeamView>();

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var RegionManager = Container.Resolve<IRegionManager>();

            
            RegionManager.RequestNavigate(RegionNames.TeamSettingRegion, "TeamSettingView");
            RegionManager.RequestNavigate(RegionNames.WaitPlayerRegion, "WaitPlayerView");
            RegionManager.RequestNavigate(RegionNames.SelectedPlayerRegion, "SelectedPlayerView");
            RegionManager.RequestNavigate(RegionNames.RandomTeamRegion, "RandomTeamView");

        }
    }
}
