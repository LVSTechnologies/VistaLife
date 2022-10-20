using System;
using Android.Widget;
using VistaLifeSampleApp.Common.Toast;
using VistaLifeSampleApp.Droid.CustomRenderers;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastMessageAndroid))]
namespace VistaLifeSampleApp.Droid.CustomRenderers
{
    public class ToastMessageAndroid : IToastMessage
    {
        Toast toast;

        public void ShowMessage(string message)
        {
            toast = Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            toast.Show();
        }
    }
}
