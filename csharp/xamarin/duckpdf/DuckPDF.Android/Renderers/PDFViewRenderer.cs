using System.Net;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(DuckPDF.PDFView), typeof(DuckPDF.Droid.Renderers.PDFViewRenderer))]
namespace DuckPDF.Droid.Renderers
{
    public class PDFViewRenderer : WebViewRenderer
    {

        public PDFViewRenderer(Context context): base(context)
        { 
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var pdfView = Element as PDFView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(pdfView.Uri))));
            }
        }
    }
}
