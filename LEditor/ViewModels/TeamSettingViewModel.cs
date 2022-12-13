using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
using LEditor.Utils;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LEditor.ViewModels
{
    public class TeamSettingViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public TeamSettingViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            RedTeamPlayerSettingViewModel = new PlayerSettingViewModel(eventAggregator, PlayerPosition.LeftTeam);
            BlueTeamPlayerSettingViewModel = new PlayerSettingViewModel(eventAggregator, PlayerPosition.RightTeam); 
        }

        public PlayerSettingViewModel RedTeamPlayerSettingViewModel { get; set; }
        public PlayerSettingViewModel BlueTeamPlayerSettingViewModel { get; set; }


    }
}
