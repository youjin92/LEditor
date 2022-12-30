using LEditor.Events;
using LEditor.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LEditor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public IApplicationCommands ApplicationCommands { get; set; }
        public string Title { get; set; } = "LEditor";

        public MainWindowViewModel(IApplicationCommands _ApplicationCommands, IEventAggregator eventAggregator)
        {
            ApplicationCommands = _ApplicationCommands;
            _eventAggregator = eventAggregator;
        }       
    }
}
