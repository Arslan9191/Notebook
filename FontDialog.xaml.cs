using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFNotebook
{
    public partial class FontDialog : Window
    {
        public FontFamily SelectedFontFamily { get; private set; }
        public double SelectedFontSize { get; private set; }

        public FontDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && double.TryParse(FontSizeTextBox.Text, out double fontSize))
            {
                SelectedFontFamily = new FontFamily((FontFamilyComboBox.SelectedItem as ComboBoxItem).Content.ToString());
                SelectedFontSize = fontSize;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите шрифт и введите корректный размер.");
            }
        }
    }
}
