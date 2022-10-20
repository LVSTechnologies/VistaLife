using System;
using UIKit;
using VistaLifeSampleApp.Effects;
using VistaLifeSampleApp.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("VistaLife")]
[assembly: ExportEffect(typeof(EntryBorderEffectiOS), nameof(EntryBorderEffect))]

namespace VistaLifeSampleApp.iOS.Effects
{
    public class EntryBorderEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null)
            {
                var entry = (UITextField)Control;
                entry.Layer.BorderWidth = 2;
                entry.Layer.BorderColor = UIColor.Black.CGColor;
                entry.Layer.CornerRadius = 4;
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
