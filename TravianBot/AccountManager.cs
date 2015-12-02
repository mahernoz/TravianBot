using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using TravianBot.Data;

namespace TravianBot
{
    public class AccountManager
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static readonly Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountManager" />
        ///     class.
        /// </summary>
        public AccountManager()
        {
            Accounts = new Dictionary<string, Account>();
        }

        /// <summary>
        ///     Fires when a new account is created.
        /// </summary>
        public event AccountEventHandler NewAccount;

        /// <summary>
        ///     Gets accounts.
        /// </summary>
        public IDictionary<string, Account> Accounts { get; private set; }

        /// <summary>
        ///     Creates or gets an existing account.
        /// </summary>
        /// <param name="username">Unique user name.</param>
        /// <param name="password">Password string.</param>
        /// <returns>Created or existing account with username.</returns>
        public Account CreateAccount(
            string username,
            string password)
        {
            if (Accounts.ContainsKey(username))
            {
                Logger.Trace(
                    "Found an account with name:{0} returning.",
                    username);
                return Accounts[username];
            }

            Logger.Trace("Creating a new account with name:{0}", username);
            var a = new Account(username, password);
            Accounts.Add(username, a);

            if (NewAccount != null)
            {
                NewAccount.Invoke(a);
            }

            return a;
        }

        /// <summary>
        ///     Gets an account for given username.
        /// </summary>
        /// <param name="username">Account username.</param>
        /// <returns>Account.</returns>
        public Account GetAccount(string username)
        {
            return Accounts.FirstOrDefault(i =>
                i.Key.Equals(username, StringComparison.CurrentCultureIgnoreCase))
                .Value;
        }
    }
}