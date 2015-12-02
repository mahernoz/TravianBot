//--------------------------------------------------------
// <copyright file="Utils.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System.Text.RegularExpressions;
using NLog;

namespace TravianBot.Utilities
{
    public static class Utils
    {
        private static readonly Logger logger =
            LogManager.GetCurrentClassLogger();

        public static string ExtractPageName(string url)
        {
            var m = Regex.Match(url, "([^/])+(?=\\.php)");

            if (m.Success)
            {
                var pageName = m.Value;
                return pageName;
            }
            logger.Error("Can't find page name:{0}", url);
            return null;
        }
    }
}