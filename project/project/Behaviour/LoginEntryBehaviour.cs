using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.Behaviour
{
    class LoginEntryBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += InvalidColor;
            base.OnAttachedTo(bindable);
        }
        private void InvalidColor(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            if (entry != null)
            {
                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    entry.BackgroundColor = Color.FromHex("#ba8484");
                }
                else
                {
                    entry.BackgroundColor = Color.AntiqueWhite;
                }
            }
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= InvalidColor;
            base.OnDetachingFrom(bindable);
        }
    }
}
