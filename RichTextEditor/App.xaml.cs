using RichTextEditor.Views;
using System.Windows;

namespace RichTextEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new TextEditorView().Show();
        }
    }
}