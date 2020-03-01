using System.ComponentModel;

namespace RichTextEditor.Models
{
    public class TextEditor
    {
        private string textBoxText;

        public string TextBoxText
        {
            get { return textBoxText; }
            set
            {
                textBoxText = value;
                OnPropertyChanged("TextBoxText");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Members
    }
}