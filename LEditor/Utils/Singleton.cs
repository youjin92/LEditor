using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEditor.Utils
{

    abstract public class Singleton<T> : BindableBase where T : class 
    {
        private static readonly Lazy<T> lazy = new Lazy<T>(() => CreateInstance());
        public static T Instance { get { return lazy.Value; } }
        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }
    }
}
