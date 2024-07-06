using System.Windows;
using System.Windows.Controls;

namespace WPFNotebook
{
    public partial class FindWindow : Window
    {
        private TextBox textBox;
        private int lastIndex;

        public FindWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            lastIndex = 0;
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            string textToFind = findTextBox.Text;
            if (!string.IsNullOrEmpty(textToFind))
            {
                lastIndex = textBox.Text.IndexOf(textToFind, lastIndex);
                if (lastIndex != -1)
                {
                    textBox.Focus();
                    textBox.Select(lastIndex, textToFind.Length);
                    lastIndex += textToFind.Length;
                }
                else
                {
                    MessageBox.Show("Текст не найден.");
                    lastIndex = 0;
                }
            }
        }

        private void FindNextButton_Click(object sender, RoutedEventArgs e)
        {
            string textToFind = findTextBox.Text;
            if (!string.IsNullOrEmpty(textToFind))
            {
                lastIndex = textBox.Text.IndexOf(textToFind, lastIndex);
                if (lastIndex != -1)
                {
                    textBox.Focus();
                    textBox.Select(lastIndex, textToFind.Length);
                    lastIndex += textToFind.Length;
                }
                else
                {
                    MessageBox.Show("Текст не найден.");
                    lastIndex = 0;
                }
            }
        }

        private void FindPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            string textToFind = findTextBox.Text;
            if (!string.IsNullOrEmpty(textToFind))
            {
                lastIndex = textBox.Text.LastIndexOf(textToFind, lastIndex - 1);
                if (lastIndex != -1)
                {
                    textBox.Focus();
                    textBox.Select(lastIndex, textToFind.Length);
                }
                else
                {
                    MessageBox.Show("Текст не найден.");
                    lastIndex = textBox.Text.Length;
                }
            }
        }

        public string GetSearchText()
        {
            return findTextBox.Text;
        }

        public int GetCurrentSearchIndex()
        {
            return lastIndex;
        }

        public void SetCurrentSearchIndex(int index)
        {
            lastIndex = index;
        }
    }
}
