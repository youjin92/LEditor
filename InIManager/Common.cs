using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InIManager
{
    public class Player : BindableBase
    {
        public string Name { get; set; } = "Name";
        public Rank Rank { get; set; }
        public Position Position { get; set; }
        public PlayerState State { get; set; }

    }

    public enum Rank
    {
        Iron,
        Bronze,
        Silver,
        Gold,
        Pletinum,
        Diamond,
    }

    public enum PlayerState
    {
        None,
        Wait,
        LeftTeam,
        RightTeam,
    }

    public enum PlayerControlDirection
    {
        Left,
        Right,
    }

    [Flags]
    public enum Position
    {
        Top = 1 << 0,
        Jungle = 1 << 1,
        Mid = 1 << 2,
        AD = 1 << 3,
        Support = 1 << 4,
    }

}
