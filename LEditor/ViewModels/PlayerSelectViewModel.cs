using LEditor.Common;
using LEditor.Events;
using LEditor.Models;
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
    public class PlayerSelectViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public static ObservableCollection<Player> ItemList { get; set; } = new ObservableCollection<Player>();

        public PlayerSelectViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            ItemList.Add(new Player { Name = "시묘1", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘2", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘3", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘4", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘5", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘6", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘7", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘8", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘9", Rank = Rank.Gold, Position = Position.Top });
            ItemList.Add(new Player { Name = "시묘10", Rank = Rank.Gold, Position = Position.Top });
        }

        #region Command

        public ICommand MouseDoubleClickCommand 
        {
            get
            {
                return new DelegateCommand<MouseButtonEventArgs>((e) =>
                {
                    if (e.OriginalSource is TextBlock textBlock)
                    {
                        if (textBlock.DataContext is Player player)
                        {
                            if (player.State != PlayerState.None)
                                return;

                            player.State = PlayerState.Wait;
                            _eventAggregator.GetEvent<GoToWaitViewEvent>().Publish(new EventParam(_Item: player));
                        }
                    }
                });
            }
        }

        #endregion
    }
}
