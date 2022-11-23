﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Common
{
    public class Enums
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

        [Flags]
        public enum Position
        {
            Top         = 1 << 0,
            Jungle      = 1 << 1,
            Mid         = 1 << 2,
            AD          = 1 << 3,
            Support     = 1 << 4,
        }
    }
}