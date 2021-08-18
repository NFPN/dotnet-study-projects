using System;
using System.Windows.Forms;

namespace UnipCRUD.Classes.Exceptions
{
    internal class MessageBoxException
    {
        public MessageBoxException() { }

        public MessageBoxException(Exception ex)
            : this(ex.Message, ex.InnerException) { }

        public MessageBoxException(string message)
            => MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public MessageBoxException(string message, Exception innerException)
        {
            var extraStack = innerException != null ? innerException.Message : string.Empty;
            MessageBox.Show(message + "\n" + extraStack, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
