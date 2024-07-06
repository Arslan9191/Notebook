using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace WPFNotebook
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand OpenFindWindowCommand = new RoutedCommand();

        private string currentFilePath;
        private bool isTextChanged;

        public MainWindow()
        {
            InitializeComponent();
            textBox.TextChanged += TextBox_TextChanged;
            CommandBindings.Add(new CommandBinding(OpenFindWindowCommand, OpenFindWindow_Executed));
            InputBindings.Add(new KeyBinding(OpenFindWindowCommand, new KeyGesture(Key.F, ModifierKeys.Control)));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanged = true;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                currentFilePath = dlg.FileName;
                textBox.Text = File.ReadAllText(currentFilePath);
                isTextChanged = false;
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs(sender, e);
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox.Text);
                isTextChanged = false;
            }
        }

        private void SaveFileAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                currentFilePath = dlg.FileName;
                File.WriteAllText(currentFilePath, textBox.Text);
                isTextChanged = false;
            }
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CutText(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.SelectedText))
            {
                Clipboard.SetText(textBox.SelectedText);
                textBox.SelectedText = "";
            }
        }

        private void CopyText(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.SelectedText))
            {
                Clipboard.SetText(textBox.SelectedText);
            }
        }

        private void PasteText(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textBox.SelectedText = Clipboard.GetText();
            }
        }

        private void DeleteText(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.SelectedText))
            {
                textBox.SelectedText = "";
            }
        }

        private void ToggleWordWrap(object sender, RoutedEventArgs e)
        {
            textBox.TextWrapping = textBox.TextWrapping == TextWrapping.Wrap ? TextWrapping.NoWrap : TextWrapping.Wrap;
        }

        private void ChangeFont(object sender, RoutedEventArgs e)
        {
            // Не забудьте импортировать нужные классы для FontDialog
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == true)
            {
                textBox.FontFamily = fontDialog.SelectedFontFamily;
                textBox.FontSize = fontDialog.SelectedFontSize;
            }
        }

        private void FindText(object sender, RoutedEventArgs e)
        {
            FindWindow findWindow = new FindWindow(textBox);
            findWindow.Show();
        }

        private void ReplaceText(object sender, RoutedEventArgs e)
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(textBox);
            replaceWindow.Show();
        }

        private void GoToLine(object sender, RoutedEventArgs e)
        {
            GoToLineWindow goToLineWindow = new GoToLineWindow(textBox);
            goToLineWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isTextChanged)
            {
                MessageBoxResult result = MessageBox.Show("Текст был изменен. Сохранить изменения?", "Блокнот", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveFile(sender, new RoutedEventArgs());
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void OpenFindWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FindWindow findWindow = new FindWindow(textBox);
            findWindow.Show();
        }

        private void TextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
