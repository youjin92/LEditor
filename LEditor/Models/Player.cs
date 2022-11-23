using LEditor.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Models
{
    public class Player : BindableBase
    {
        public string Name { get; set; } = "Name";
        public Rank Rank { get; set; }
        public Position Position { get; set; }
        public bool IsSelected { get; set; }
    }
}
