using System;
using Android.Content.Res;
using VistaLifeSampleApp.Droid.Effects;
using VistaLifeSampleApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("VistaLife")]
[assembly: ExportEffect(typeof(EntryBorderEffectAndroid), nameof(EntryBorderEffect))]
namespace VistaLifeSampleApp.Droid.Effects
{
    public class EntryBorderEffectAndroid : PlatformEffect
    {

        protected override void OnAttached()
        {
            Android.Graphics.Color borderColor = Android.Graphics.Color.Orange;

            if (Control != null)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(borderColor);
            }
            
        }

        protected override void OnDetached()
        {
            
        }
    }
}
