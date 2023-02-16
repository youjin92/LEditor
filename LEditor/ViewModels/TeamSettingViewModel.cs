using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Services;
using LEditor.Utils;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LEditor.ViewModels
{
    public class TeamSettingViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApplicationCommands _applicationCommands;

        public PlayerSettingViewModel RedTeamPlayerSettingViewModel { get; set; }
        public PlayerSettingViewModel BlueTeamPlayerSettingViewModel { get; set; }

        public TeamSettingViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;

            RedTeamPlayerSettingViewModel = new PlayerSettingViewModel(_applicationCommands, eventAggregator, PlayerPosition.LeftTeam);
            BlueTeamPlayerSettingViewModel = new PlayerSettingViewModel(_applicationCommands, eventAggregator, PlayerPosition.RightTeam);

            Task.Factory.StartNew(() => CheckMatchedPlayer());
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void CheckMatchedPlayer()
        {
            //throw new NotImplementedException();
        }
    }
}
