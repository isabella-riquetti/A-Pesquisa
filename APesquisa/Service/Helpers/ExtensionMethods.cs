using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace APesquisa.Service
{
    public static class ExtensionMethods
    {
        public static string StringValueOf(this System.Enum objEnum)
        {
            FieldInfo info = objEnum.GetType().GetField(objEnum.ToString());
            DescriptionAttribute[] atributos =
                (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (atributos.Length > 0)
                return atributos[0].Description;
            else
                return objEnum.ToString();
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string ClearToCompare(this string text)
        {
            return text.RemoveDiacritics().RemoveSpecialCharacters().Replace(" ", string.Empty).ToLower();
        }

        public static DateTime Brasilia(this DateTime date)
        {
            var utc = DateTime.UtcNow;
            var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var dateTimeNowBrasilia = TimeZoneInfo.ConvertTimeFromUtc(utc, brasiliaTimeZone);

            return dateTimeNowBrasilia;
        }
    }
}