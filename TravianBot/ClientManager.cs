//--------------------------------------------------------
// <copyright file="ClintManager.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using TravianBot.Data;

namespace TravianBot
{
    public class ClientManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClientManager" />
        ///     class.
        /// </summary>
        public ClientManager(Server server)
        {
            AllClients = new List<HttpClient>();
            Clients = new Dictionary<string, HttpClient>();
            TravianClients = new Dictionary<string, TravianClient>();
            Server = server;
        }

        /// <summary>
        ///     Fires when a new client is created.
        /// </summary>
        public event ClientEventHandler NewClient;

        /// <summary>
        ///     Gets managing server.
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        ///     Gets or sets network clients.
        /// </summary>
        private static IList<HttpClient> AllClients { get; set; }

        /// <summary>
        ///     Gets server's clients.
        /// </summary>
        public IDictionary<string, HttpClient> Clients { get; private set; }

        /// <summary>
        ///     Gets server's travian clients.
        /// </summary>
        public IDictionary<string, TravianClient> TravianClients { get; private set; }

        /// <summary>
        ///     Gets an existing http client.
        /// </summary>
        /// <param name="username">Account username.</param>
        /// <returns>Http client.</returns>
        public HttpClient GetClient(string username, string host)
        {
            var client = AllClients
                .Except(Clients.Select(i => i.Value))
                .FirstOrDefault();

            if (client == null)
            {
                client = CreateClient(host);
                AllClients.Add(client);
                Clients.Add(username, client);
            }

            return client;
        }

        /// <summary>
        ///     Creates or gets a travian client.
        /// </summary>
        /// <param name="a">Account to be associated.</param>
        /// <param name="host">Host address.</param>
        /// <returns>Travian client.</returns>
        public TravianClient CreateTravianClient(Account a, string host)
        {
            if (TravianClients.ContainsKey(a.Username))
            {
                return TravianClients[a.Username];
            }

            var tc = new TravianClient(a, GetClient(a.Username, host));
            TravianClients.Add(a.Username, tc);
            
            if (NewClient != null)
            {
                NewClient.Invoke(tc);
            }

            return tc;
        }

        /// <summary>
        ///     Creates a new http client.
        /// </summary>
        /// <param name="host">Base host address.</param>
        /// <param name="configFile">Config file path.</param>
        /// <returns>Http client.</returns>
        public HttpClient CreateClient(
            string host,
            string configFile = "net.config")
        {
            XmlDocument configXml = new XmlDocument();
            configXml.Load(configFile);

            HttpClient client = new HttpClient(
                new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });

            foreach (XmlNode headerNode in
                configXml.SelectNodes("configuration/Headers/*/header"))
            {
                client.DefaultRequestHeaders.Add(
                    headerNode.Attributes["key"].Value,
                    headerNode.InnerText);
            }

            client.BaseAddress = new Uri(host);

            AllClients.Add(client);

            return client;
        }
    }
}