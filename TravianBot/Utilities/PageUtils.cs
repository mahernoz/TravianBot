//--------------------------------------------------------
// <copyright file="TravianClient.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

namespace TravianBot.Utilities
{
    public static class PageUtils
    {
        /// <summary>
        ///     Gets page enum from string.
        /// </summary>
        /// <param name="pageName">Page name.</param>
        /// <returns>Return page enum.</returns>
        public static Page GetPageEnum(string pageName)
        {
            Page p;

            switch (pageName)
            {
                case "village1":
                case "dorf1":
                    p = Page.VILLAGE1;
                    break;
                case "village2":
                case "dorf2":
                    p = Page.VILLAGE2;
                    break;
                case "village3":
                case "dorf3":
                    p = Page.VILLAGE3;
                    break;
                case "profile":
                case "spieler":
                    p = Page.PROFILE;
                    break;
                case "map":
                case "karte":
                    p = Page.MAP;
                    break;
                case "statistics":
                case "statistiken":
                    p = Page.STATISTICS;
                    break;
                case "msg":
                case "nachrichten":
                    p = Page.MESSAGES;
                    break;
                case "reports":
                case "berichte":
                    p = Page.REPORTS;
                    break;
                case "build":
                    p = Page.BUILD;
                    break;
                case "index":
                    p = Page.INDEX;
                    break;
                case "login":
                    p = Page.LOGIN;
                    break;
                case "v2v":
                case "a2b":
                    p = Page.V2V;
                    break;
                default:
                    p = Page.UNKNOWN;
                    break;
            }
            return p;
        }

        /// <summary>
        ///     Gets page name from page enum.
        /// </summary>
        /// <param name="page">Page enum.</param>
        /// <returns>Returns page name.</returns>
        public static string GetPageName(Page page)
        {
            var pageName = string.Empty;
            var ver = (int) Travian.Instance.Version;

            switch (page)
            {
                case Page.BUILD:
                    pageName = "build";
                    break;
                case Page.INDEX:
                    pageName = "index";
                    break;
                case Page.LOGIN:
                    pageName = "login";
                    break;
                case Page.MAP:
                    if (ver == 0)
                    {
                        pageName = "map";
                    }
                    else
                    {
                        pageName = "karte";
                    }
                    break;
                case Page.MESSAGES:
                    if (ver == 0)
                    {
                        pageName = "msg";
                    }
                    else
                    {
                        pageName = "nachrichten";
                    }
                    break;
                case Page.PROFILE:
                    if (ver == 0)
                    {
                        pageName = "profile";
                    }
                    else
                    {
                        pageName = "spieler";
                    }
                    break;
                case Page.REPORTS:
                    if (ver == 0)
                    {
                        pageName = "reports";
                    }
                    else
                    {
                        pageName = "berichte";
                    }
                    break;
                case Page.STATISTICS:
                    if (ver == 0)
                    {
                        pageName = "statistics";
                    }
                    else
                    {
                        pageName = "statistiken";
                    }
                    break;
                case Page.UNKNOWN:
                    pageName = "unknown";
                    break;
                case Page.VILLAGE1:
                    if (ver == 0)
                    {
                        pageName = "village1";
                    }
                    else
                    {
                        pageName = "dorf1";
                    }
                    break;
                case Page.VILLAGE2:
                    if (ver == 0)
                    {
                        pageName = "village2";
                    }
                    else
                    {
                        pageName = "dorf2";
                    }
                    break;
                case Page.VILLAGE3:
                    if (ver == 0)
                    {
                        pageName = "village3";
                    }
                    else
                    {
                        pageName = "dorf3";
                    }
                    break;
                case Page.V2V:
                    if (ver == 0)
                    {
                        pageName = "v2v";
                    }
                    else
                    {
                        pageName = "a2b";
                    }
                    break;
            }
            return pageName;
        }
    }
}