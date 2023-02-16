using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Common
{
    public enum Rank
    {
        Iron,

        Bronze1,
        Bronze2,
        Bronze3,
        Bronze4,
        Bronze5,

        Silver1,
        Silver2,
        Silver3,
        Silver4,
        Silver5,

        Gold1,
        Gold2,
        Gold3,
        Gold4,
        Gold5,

        Pletinum1,
        Pletinum2,
        Pletinum3,
        Pletinum4,
        Pletinum5,

        Diamond1,
        Diamond2,
        Diamond3,
        Diamond4,
        Diamond5,
    }

    public enum PlayerPosition
    {
        None,
        Wait,
        Selected,

        LeftTeam,
        LeftTop,
        LeftJug,
        LeftMid,
        LeftAd,
        LeftSupport,

        RightTeam,
        RightTop,
        RightJug,
        RightMid,
        RightAd,
        RightSupport,
    }

    [Flags]
    public enum InGamePosition
    {
        None        = 1 << 0,
        Top         = 1 << 1,
        Jungle      = 1 << 2,
        Mid         = 1 << 3,
        AD          = 1 << 4,
        Support     = 1 << 5,
    }
}
