using RichTextEditor.ViewModels;
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
            base.OnStartup(e);
            var window = new TextEditorView() { DataContext = new TextEditorViewModel() };
            window.Show();
        }
    }
}