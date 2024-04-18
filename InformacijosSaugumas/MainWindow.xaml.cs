using System.Windows;
using System.Windows.Controls;

namespace InformacijosSaugumas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = TextBoxInput.Text;
            string key = TextBoxKeyInput.Text;
            string encryptedText = VigenaryMethod.Encrypt(text, key);
            TextBoxOutput.Text = encryptedText;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text = TextBoxOutput.Text;
            string key = TextBoxKeyInput.Text;
            string decryptedText = VigenaryMethod.Decrypt(text, key);
            TextBoxInput.Text = decryptedText;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string text = TextBoxInput.Text;
            string key = TextBoxKeyInput.Text;
            string encryptedText = VigenaryANSIIMethod.Encrypt(text, key);
            TextBoxOutput.Text = encryptedText;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string text = TextBoxOutput.Text;
            string key = TextBoxKeyInput.Text;
            string decryptedText = VigenaryANSIIMethod.Decrypt(text, key);
            TextBoxInput.Text = decryptedText;
        }

        private void TextBoxKeyInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}