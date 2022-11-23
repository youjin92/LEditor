using LEditor.Events;
using LEditor.Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.ViewModels
{
    public class PlayerWaitViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<Player> WaitItemList { get; set; } = new ObservableCollection<Player>();

        public PlayerWaitViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectPlayerEvent>().Subscribe(ExcuteReceiveItem);
        }

        private void ExcuteReceiveItem(EventParam obj)
        {
            WaitItemList.Add(obj.Item as Player);
        }
    }
}
