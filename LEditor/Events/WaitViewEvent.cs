﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Events
{
    public class AddPlayerInWaitViewEvent : PubSubEvent<EventParam>
    {

    }

    public class RemovePlayerInWaitViewEvent : PubSubEvent<EventParam>
    {

    }

    public class EventParam
    {
        public EventParam(object _Item)
        {
            Item = _Item;
        }

        public object Item { get; set; }

    }
}
