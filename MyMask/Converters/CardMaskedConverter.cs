using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyMask.Converters
{
    public class CardMaskedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int textLength = (int) value;
            string maskPrompt = string.Empty;

            #region Adjust blank spaces
            if (textLength > 4 && textLength < 10)
                textLength--;
            else if (textLength > 9 && textLength < 15)
                textLength -= 2;
            else if (textLength > 14 && textLength < 20)
                textLength -= 3;
            else if (textLength > 19)
                textLength -= 4;
            #endregion

            maskPrompt = maskPrompt.PadRight(textLength, '	');

            if (textLength <= 11)
                maskPrompt = maskPrompt.PadRight(11, '_');
            else if (textLength >= 12 && textLength <= 16)
                maskPrompt = maskPrompt.PadRight(16, '_');
            else if (textLength >= 17)
                maskPrompt = maskPrompt.PadRight(18, '_');

            for (int i = 4; i < maskPrompt.Length; i = i + 5)
                maskPrompt = maskPrompt.Insert(i, " ");

            return maskPrompt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
