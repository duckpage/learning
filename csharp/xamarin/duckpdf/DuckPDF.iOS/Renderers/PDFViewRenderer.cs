using System.Net;
using System.IO;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(DuckPDF.PDFView), typeof(DuckPDF.iOS.Renderers.PDFViewRenderer))]
namespace DuckPDF.iOS.Renderers
{
    public class PDFViewRenderer : ViewRenderer<DuckPDF.PDFView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PDFView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                Control.ScalesPageToFit = true;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == DuckPDF.PDFView.UriProperty.PropertyName)
            {
                var docView = Element as DuckPDF.PDFView;
                string fileName = docView.Uri;
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
            }
        }
    }
}
