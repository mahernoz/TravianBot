//--------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.Web;

namespace TravianBot.Utilities
{
    public static class ExtensionMethods
    {
        public static void AppendUrlEncoded(this StringBuilder sb, string name, object value, bool moreValues = true)
        {
            sb.Append(HttpUtility.UrlEncode(name));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(value.ToString()));
            if (moreValues)
                sb.Append("&");
        }

        public static bool IsIn<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }

        public static string F(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static int AsInt(this string s)
        {
            return int.Parse(s);
        }

        public static T ToEnum<T>(this string s)
        {
            return (T) Enum.Parse(typeof (T), s, true);
        }

        public static bool EqualsIgnoreCase(this string s, string val)
        {
            return s.Equals(val, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}