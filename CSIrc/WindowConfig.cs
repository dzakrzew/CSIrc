using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIrc
{
    public partial class WindowConfig : Form
    {
        public WindowConfig()
        {
            InitializeComponent();
        }

        private void eConnect_Click(object sender, EventArgs e)
        {
            int port;

            #region Input data validation
            if (eAddress.TextLength == 0 || ePort.TextLength == 0 || eNickname.TextLength == 0 || eUsername.TextLength == 0 || eRealname.TextLength == 0)
            {
                MessageBox.Show("Some fields are empty. Please enter correct values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(ePort.Text, out port) || port < 1 || 65535 < port)
            {
                MessageBox.Show("Port must be greater than 0 and less than 65536.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            Program.MainWindow = new WindowMain();

            var ircContext = new IrcServer(eAddress.Text, port, new Client(eNickname.Text, eUsername.Text, eRealname.Text, !eSkipMotd.Checked));

            ContextCollection.Server = ircContext;
            ContextCollection.Current = ircContext;

            this.Hide();
            
            Program.MainWindow.Closed += (s, args) => this.Close();
            Program.MainWindow.Show();

            ircContext.Connect();
        }
    }
}
