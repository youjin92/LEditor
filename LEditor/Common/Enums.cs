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
        Bronze,
        Silver,
        Gold,
        Pletinum,
        Diamond,
    }

    public enum PlayerPosition
    {
        Wait,
        Selected,
        LeftTeam,
        RightTeam,
    }

    public enum PlayerControlDirection
    {
        Left,
        Right,
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

    public enum DropState
    {
        CanDrop,
        CannotDrop
    }
}
