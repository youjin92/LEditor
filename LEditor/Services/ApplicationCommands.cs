using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Services
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _RandomTeamMatchingCommand = new CompositeCommand();
        public CompositeCommand RandomTeamMatchingCommand
        {
            get { return _RandomTeamMatchingCommand; }
        }

        private CompositeCommand _ResetTeamCommand = new CompositeCommand();
        public CompositeCommand ResetTeamCommand
        {
            get { return _ResetTeamCommand; }
        }
    }
}
