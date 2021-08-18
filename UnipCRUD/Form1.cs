using System.Windows.Forms;
using UnipCRUD.Database;

namespace UnipCRUD
{
    public partial class MainForm : Form
    {
        private readonly DatabaseConnectionManager connectionManager = new DatabaseConnectionManager();

        public MainForm() => InitializeComponent();

        private void BtnConnection_Click(object sender, System.EventArgs e)
        {
            using (var test = connectionManager.GetConnection())
            {
                test.Open();
            }
        }

        private void BtnCloseConnection_Click(object sender, System.EventArgs e)
        {
            connectionManager.Disconnect();
        }
    }
}
