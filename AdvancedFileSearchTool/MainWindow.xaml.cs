using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TextSearchTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding cb = new CommandBinding(ApplicationCommands.Copy, CopyCmdExecuted, CopyCmdCanExecute);

            lstResults.CommandBindings.Add(cb);
        }

        private void CopyCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(Path.GetDirectoryName(lstResults.SelectedItem.ToString()));
        }

        private void CopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var lb = e.OriginalSource as ListBox;
            e.CanExecute = lb.SelectedItems.Count > 0;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();

            var result = folderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
                txtFolderPath.Text = folderDialog.SelectedPath;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();

            var folderPath = txtFolderPath.Text;

            if (string.IsNullOrEmpty(folderPath))
            {
                lblStatus.Content = "Please select a folder to search.";
                return;
            }

            try
            {
                var files = Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories);

                foreach (var file in files)
                    if (File.ReadAllText(file).Contains(txtToSearch.Text))
                        lstResults.Items.Add(file);

                lblStatus.Content = $"Found {lstResults.Items.Count} files containing text.";
            }
            catch (Exception ex)
            {
                lblStatus.Content = $"Error searching for files: {ex.Message}";
            }
        }
    }
}
