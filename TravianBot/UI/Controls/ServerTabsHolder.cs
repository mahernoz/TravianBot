using System.Windows.Forms;
using TravianBot.Data;

namespace TravianBot.UI.Controls
{
    public partial class ServerTabsHolder : UserControl
    {
        public ServerTabsHolder()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                Travian.Instance.OnNewServerAdded += OnServerAdded;
            }
        }

        public void OnServerAdded(Server server)
        {
            if (InvokeRequired)
            {
                Invoke(new ServerEventHandler(OnServerAdded), server);
                return;
            }

            TabPage tabPage = new TabPage(server.Name);
            tabPage.Controls.Add(new ServerViewTabPage(server));

            svTabs.TabPages.Add(tabPage);
        }
    }
}