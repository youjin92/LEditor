using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace LEditor.MarkupExtensions
{
    class ImageSourceExtension : MarkupExtension
    {
        private string root = "pack://application:,,,/LEditor;component/Images/";

        public string FileName { get; set; }

        public ImageSourceExtension() { }

        public ImageSourceExtension(string name)
        {
            this.FileName = name;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var source = new BitmapImage(new Uri(root + FileName, UriKind.Absolute));

            return source;
        }
    }
}
