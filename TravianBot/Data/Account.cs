//--------------------------------------------------------
// <copyright file="Account.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using NLog;

namespace TravianBot.Data
{
    /// <summary>
    ///     Account class holds all information for accounts.
    /// </summary>
    public class Account
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static readonly Logger Logger
            = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the Account class.
        /// </summary>
        /// <param name="id">Account id.</param>
        /// <param name="username">Account username.</param>
        /// <param name="password">Account password.</param>
        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void SetPlayer(MyPlayer p)
        {
            Player = p;
        }

        /// <summary>
        ///     Converts object to string representation.
        /// </summary>
        /// <returns>String representation of object.</returns>
        public override string ToString()
        {
            return Username;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets the username property.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the password property.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the email property.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the gold count.
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        ///     Gets or sets the account player.
        /// </summary>
        public MyPlayer Player { get; private set; }

        #endregion
    }
}