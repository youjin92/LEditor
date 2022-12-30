using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Events
{
    public class RandomTeamMatchingEvent : PubSubEvent<RandomTeamMatchingParam>
    {

    }

    public class RandomTeamMatchingParam
    {
        public RandomTeamMatchingParam(object _Item)
        {
            Item = _Item;
        }

        public object Item { get; set; }

    }
}
