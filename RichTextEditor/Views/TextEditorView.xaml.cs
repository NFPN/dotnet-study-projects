using Microsoft.Win32;
using RichTextEditor.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace RichTextEditor.Views
{
    /// <summary>
    /// Interaction logic for TextEditorView.xaml
    /// </summary>
    public partial class TextEditorView : Window
    {
        public TextEditorView() => InitialSetup();

        public TextEditorView(object context)
        {
            InitialSetup();
            DataContext = context;
        }

        private void InitialSetup()
        {
            InitializeComponent();
            DataContext = new TextEditorViewModel();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void EditorSelectionChanged(object sender, RoutedEventArgs e)
        {
            var temp = rtbEditor.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbEditor.Selection.GetPropertyValue(TextElement.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbEditor.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = rtbEditor.Selection.GetPropertyValue(TextElement.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void OpenRichTextFile(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*" };
            if (dlg.ShowDialog() == true)
            {
                var fileStream = new FileStream(dlg.FileName, FileMode.Open);
                var range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void SaveRichTextFile(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*" };
            if (dlg.ShowDialog() == true)
            {
                var fileStream = new FileStream(dlg.FileName, FileMode.Create);
                var range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void SelectionFontFamilyChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }

        private void TextFontSizeChanged(object sender, TextChangedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, cmbFontSize.Text);
        }
    }
}