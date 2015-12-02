//--------------------------------------------------------
// <copyright file="EventHandlers.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using TravianBot.Data;
using TravianBot.Structs;

namespace TravianBot
{
    /// <summary>
    ///     Fires when parsing is completed.
    /// </summary>
    public delegate void ParseCompletedHandler();

    /// <summary>
    ///     Handles new content events.
    /// </summary>
    /// <param name="content">Content received from server.</param>
    public delegate void NewContentHandler(string content, Page page);

    /// <summary>
    ///     Handles client events.
    /// </summary>
    /// <param name="c">Client object.</param>
    public delegate void ClientEventHandler(TravianClient c);

    /// <summary>
    ///     Handles server events.
    /// </summary>
    /// <param name="s">Event object.</param>
    public delegate void ServerEventHandler(Server s);

    /// <summary>
    ///     Handles alliance events.
    /// </summary>
    /// <param name="a">Alliance object.</param>
    public delegate void AllyEventHandler(Alliance a);

    /// <summary>
    ///     Player event handler.
    /// </summary>
    /// <param name="player">Event player.</param>
    public delegate void PlayerEventHandler(Player player);

    /// <summary>
    ///     Village events handler.
    /// </summary>
    /// <param name="village">Event village.</param>
    public delegate void VillageEventHandler(Village village);

    /// <summary>
    ///     MyVillage events handler.
    /// </summary>
    /// <param name="mv"></param>
    public delegate void MyVillageEventHandler(MyVillage mv);

    /// <summary>
    ///     Handles structure events.
    /// </summary>
    /// <param name="s">Event structure.</param>
    public delegate void BuildingEventHandler(Building b);

    /// <summary>
    ///     Handles random key events.
    /// </summary>
    /// <param name="key">Random key.</param>
    public delegate void RandomKeyEventHandler(string key);

    /// <summary>
    ///     Handles account events.
    /// </summary>
    /// <param name="a"></param>
    public delegate void AccountEventHandler(Account a);

    /// <summary>
    ///     Handles player data events.
    /// </summary>
    /// <param name="players"></param>
    public delegate void PlayerDataEventHandler(params PlayerData[] players);

    /// <summary>
    ///     Handles village data evets.
    /// </summary>
    /// <param name="villages"></param>
    public delegate void VillageDataEventHandler(params VillageData[] villages);
}