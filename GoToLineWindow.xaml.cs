using System.Windows;
using System.Windows.Controls;

namespace WPFNotebook
{
    public partial class GoToLineWindow : Window
    {
        private TextBox textBox;

        public GoToLineWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
        }

        private void GoToLineButton_Click(object sender, RoutedEventArgs e)
        {
            int lineNumber;
            if (int.TryParse(lineNumberTextBox.Text, out lineNumber))
            {
                int lineIndex = textBox.GetCharacterIndexFromLineIndex(lineNumber - 1);
                if (lineIndex != -1)
                {
                    textBox.Focus();
                    textBox.Select(lineIndex, 0);
                }
                else
                {
                    MessageBox.Show("Номер строки не существует.");
                }
            }
        }
    }
}
