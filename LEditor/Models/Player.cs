using LEditor.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LEditor.Models
{
    public class Player : BindableBase
    {
        public string Name { get; set; } = "Name";
        public Rank Rank { get; set; }
        public InGamePosition Position { get; set; }
        public PlayerPosition State { get; set; }

    }
}
