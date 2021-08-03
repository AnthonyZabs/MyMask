using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyMask.Behaviors
{
    public class MaskedBehavior : Behavior<Entry>
    {
        private string _mask = "";

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
            }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var text = Regex.Replace(entry.Text, "[^0-9]", "");

            for (int i = 0; i < text.Length; i++)
            {
                if (Mask[i] != 'X')
                {
                    text = text.Insert(i, Mask[i].ToString());
                }
            }

            if (!string.IsNullOrWhiteSpace(Mask))
            {
                // Adding the MaxLength
                if (text.Length == Mask.Length)
                    entry.MaxLength = Mask.Length;
            }

            entry.Text = text;
            entry.Placeholder = Mask;
        }
    }
}