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
        public Player SelectedItem { get; set; }

        public PlayerSelectViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;


            ItemList.Add(new Player { Name = "유진", Rank = Rank.Bronze, Position = Position.Support });
            ItemList.Add(new Player { Name = "잦성", Rank = Rank.Silver, Position = Position.Jungle });
            ItemList.Add(new Player { Name = "시묘", Rank = Rank.Gold, Position = Position.Top });
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
                            player.IsSelected = true;
                            _eventAggregator.GetEvent<SelectPlayerEvent>().Publish(new EventParam(_Item: player));
                        }
                    }
                });
            }
        }

        #endregion
    }
}
