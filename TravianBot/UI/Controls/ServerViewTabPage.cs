using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TravianBot.Data;

namespace TravianBot.UI.Controls
{
    public partial class ServerViewTabPage : UserControl
    {
        private readonly Server _server;

        public ServerViewTabPage(Server server)
        {
            InitializeComponent();
            _server = server;
            Dock = DockStyle.Fill;

            gridPlayers.AutoGenerateColumns = true;
            gridAllies.AutoGenerateColumns = true;

            server.PlayerManager.OnNewPlayer += OnNewPlayer;
            server.AllyManager.OnNewAlliance += OnNewAlliance;
        }

        private void BindPlayers(IList<Player> players)
        {
            gridPlayers.DataSource = players;
        }

        private void BindAlliances(IList<Alliance> alliances)
        {
            gridAllies.DataSource = alliances;
        }

        public void OnNewPlayer(Player p)
        {
            if (InvokeRequired)
            {
                Invoke(new PlayerEventHandler(OnNewPlayer), p);
                return;
            }
            BindPlayers(_server.Players);
        }

        public void OnNewAlliance(Alliance a)
        {
            if (InvokeRequired)
            {
                Invoke(new AllyEventHandler(OnNewAlliance), a);
                return;
            }
            BindAlliances(_server.Alliances);
        }
    }
}