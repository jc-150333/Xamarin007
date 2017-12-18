using Xamarin007;
using GestureSample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExImage), typeof(ExImageRenderer))] // ←1
namespace GestureSample.iOS
{
    internal class ExImageRenderer : ImageRenderer
    { // ← 2
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            var exImage = Element as ExImage;
            var gr = new UILongPressGestureRecognizer(o => exImage.OnLongPress()); // 3

            AddGestureRecognizer(gr); // ← 4
        }
    }
}