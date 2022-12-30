﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Services
{
    public interface IApplicationCommands
    {
        CompositeCommand RandomTeamMatchingCommand { get; }
        CompositeCommand ResetTeamCommand { get; }
    }
}
