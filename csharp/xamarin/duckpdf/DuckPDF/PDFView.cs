using System;

using Xamarin.Forms;

namespace DuckPDF
{
    public class PDFView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
        returnType: typeof(string),
        declaringType: typeof(PDFView),
        defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}

