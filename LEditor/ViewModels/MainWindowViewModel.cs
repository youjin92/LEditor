using Prism.Commands;
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

namespace LEditor.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public string Title { get; set; } = "LEditor";

    }
}
