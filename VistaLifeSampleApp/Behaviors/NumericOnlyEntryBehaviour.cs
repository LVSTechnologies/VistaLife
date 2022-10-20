using System;
using Xamarin.Forms;

namespace VistaLifeSampleApp.Behaviors
{
    public class NumericOnlyEntryBehaviour : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = double.TryParse(e.NewTextValue,out _);
            ((Entry)sender).TextColor = isValid ? Color.Green : Color.Red;
        }
    }
}
