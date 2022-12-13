using LEditor.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Events
{

    public class UpdatePlayerEvent : PubSubEvent<EventParam>
    {

    }

    public class EventParam
    {
        public EventParam(object _Item)
        {
            Item = _Item;
        }

        public EventParam(object _Item, PlayerPosition _dropedPos)
        {
            Item = _Item;
            DropedPosition = _dropedPos;
        }

        public EventParam(object _Item, PlayerPosition _dropedPos, InGamePosition _InGamePosition)
        {
            Item = _Item;
            DropedPosition = _dropedPos;
            InGamePosition = _InGamePosition;
        }

        public object Item { get; set; }
        public PlayerPosition DropedPosition { get; set; }

        public InGamePosition InGamePosition { get; set; } = InGamePosition.None;
    }
}
