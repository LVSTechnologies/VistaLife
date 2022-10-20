using System;
using Foundation;
using UIKit;
using VistaLifeSampleApp.Common.Toast;
using VistaLifeSampleApp.iOS.CustomRenderers;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastMessageiOS))]
namespace VistaLifeSampleApp.iOS.CustomRenderers
{
    public class ToastMessageiOS : IToastMessage
    {
        const double Delay = 1.0;

        public void ShowMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ShowToast(message, Delay);
            });
        }

        private void ShowToast(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.ActionSheet);
            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);

        }

        private void DismissMessage(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
