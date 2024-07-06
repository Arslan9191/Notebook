using System.Windows;
using System.Windows.Controls;

namespace WPFNotebook
{
    public partial class ReplaceWindow : Window
    {
        private TextBox textBox;

        public ReplaceWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            string textToFind = findTextBox.Text;
            string textToReplace = replaceTextBox.Text;
            if (!string.IsNullOrEmpty(textToFind))
            {
                int index = textBox.Text.IndexOf(textToFind);
                if (index != -1)
                {
                    textBox.Text = textBox.Text.Remove(index, textToFind.Length).Insert(index, textToReplace);
                }
                else
                {
                    MessageBox.Show("Текст не найден.");
                }
            }
        }

        private void ReplaceAllButton_Click(object sender, RoutedEventArgs e)
        {
            string textToFind = findTextBox.Text;
            string textToReplace = replaceTextBox.Text;
            if (!string.IsNullOrEmpty(textToFind))
            {
                textBox.Text = textBox.Text.Replace(textToFind, textToReplace);
            }
        }
    }
}
