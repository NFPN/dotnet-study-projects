using System.Windows.Forms;
using UnipCRUD.Database;

namespace UnipCRUD
{
    public partial class MainForm : Form
    {
        private readonly DBConnection connection = new DBConnection();

        public MainForm() => InitializeComponent();

        private void BtnConnection_Click(object sender, System.EventArgs e)
            => connection.CreateConnection();

        private void BtnCloseConnection_Click(object sender, System.EventArgs e)
            => connection.Disconnect();
    }
}
