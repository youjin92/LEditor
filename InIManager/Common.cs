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
        private string Name_ = "Default Name";
        public string Name {
            get=> Name_;
            set
            {
                Name_ = value;
                RaisePropertyChanged();
            }
        } 

        private Rank Rank_ = Rank.Pletinum;
        public Rank Rank { 
            get=> Rank_;
            set
            {
                Rank_ = value;
                RaisePropertyChanged();
            }
        }

        private Position Position_ = Position.AD;
        public Position Position
        {
            get => Position_;
            set
            {
                Position_ = value;
                RaisePropertyChanged();
            }
        }

        private PlayerState State_ = PlayerState.None;

        public PlayerState State
        {
            get => State_;
            set
            {
                State_ = value;
                RaisePropertyChanged();
            }
        }

    }

    public static class EnumUtil<T>
    {
        public static T Parse(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
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
