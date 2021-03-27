using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project
{
    [ContentProperty(nameof(Source))]
    class EmbeddedImagesHelper : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            var image = ImageSource.FromResource(Source, typeof(EmbeddedImagesHelper).GetTypeInfo().Assembly);
            return image;
        }
    }
}
