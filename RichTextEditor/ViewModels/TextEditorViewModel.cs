using RichTextEditor.Models;
using System;
using System.Windows.Input;

namespace RichTextEditor.ViewModels
{
    public class TextEditorViewModel
    {
        public TextEditor Editor { get; set; }

        public TextEditorViewModel()
        {
            Editor = new TextEditor { TextBoxText = "Sample Text" };
        }

        private ICommand mUpdater;

        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set => mUpdater = value;
        }

        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter) => true;

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            { }

            #endregion ICommand Members
        }
    }
}