using LEditor.AppConfig;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LEditor.ViewModels
{
    public class RandomTeamViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApplicationCommands _applicationCommands;


        public string Title { get; set; } = "RandomTeamList";
        public ObservableCollection<RandomTeamPlayers> WaitUsers { get; set; } = new ObservableCollection<RandomTeamPlayers>();


        public RandomTeamViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;

            _applicationCommands.RandomTeamMatchingCommand.RegisterCommand(UpdateItemListCommand);
        }

        public ICommand UpdateItemListCommand
        {
            get
            {
                return new DelegateCommand<object>((e) =>
                {
                    MakeRandomTeamPlayers(AppInstance.Instance.ScoreDiffDictionary);

                });
            }
        }

        private void MakeRandomTeamPlayers(Dictionary<int, List<List<ObservableCollection<Player>>>> ScoreDiffDictionary)
        {
            WaitUsers.Clear();
            int index = 0;

            var SortedDictionary = ScoreDiffDictionary.OrderBy(item => item.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var Key in SortedDictionary.Keys)
            {
                foreach ( List < ObservableCollection < Player >> itemList in ScoreDiffDictionary[Key])
                {
                    RandomTeamPlayers randomTeamPlayers = new RandomTeamPlayers();
                    randomTeamPlayers.Index = index++;
                    randomTeamPlayers.Score = Key;
                    randomTeamPlayers.RedTeamPlayers = itemList[0];
                    randomTeamPlayers.BlueTeamPlayers = itemList[1];

                    WaitUsers.Add(randomTeamPlayers);
                }
                
            }
        }


        #region Command
        public ICommand ApplyCommand
        {
            get
            {
                return new DelegateCommand<RandomTeamPlayers>((e) =>
                {
                    _eventAggregator.GetEvent<RandomTeamMatchingEvent>().Publish(new RandomTeamMatchingParam(_Item: e));
                    _eventAggregator.GetEvent<RandomTeamMatchingEvent>().Publish(new RandomTeamMatchingParam(_Item: e));
                });
            }
        }
        


        #endregion

    }

   
}
