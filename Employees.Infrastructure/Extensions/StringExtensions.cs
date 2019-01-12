using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string TrimAndRemoveWhiteSpaces(this string text)
        {
            text = text.Trim();
            var regex = new Regex(@"\s{2,}");
            while (regex.IsMatch(text))
                text = regex.Replace(text, " ", 1);
            return text;
        }

        public static string FirstLetterCapitalization(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public static string NameFormatting(this string text)
        {
            var textWithoutMultipleWhiteSpaces = TrimAndRemoveWhiteSpaces(text);
            return FirstLetterCapitalization(textWithoutMultipleWhiteSpaces);
        }
    }
}
