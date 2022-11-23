using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LEditor.Common.Enums;

namespace LEditor.Models
{
    public class Player : BindableBase
    {
        public string Name { get; set; } = "Name";
        public Rank Rank { get; set; }
        public Position Position { get; set; }
    }
}
