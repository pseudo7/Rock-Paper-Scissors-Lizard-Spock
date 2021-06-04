using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace RPSLS.Miscellaneous
{
    public static class Utilities
    {
        public static string ToColoredString(this string currentString, Color stringColor) =>
            $"<color=#{ColorUtility.ToHtmlStringRGB(stringColor)}>{currentString}</color>";

        public static string ToTitleCase(this string currentString)
        {
            var returnString = currentString.ToLowerInvariant();
            return char.ToUpperInvariant(returnString[0]) + returnString.Substring(1);
        }

        public static string ToSnakeCase(this string str)
        {
            var pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            var objects = pattern.Matches(str);
            var builder = new StringBuilder();
            for (var i = 0; i < objects.Count; i++)
                builder.Append(objects[i].Value + "_");
            return builder.ToString().TrimEnd('_').ToUpper();
        }
    }
}