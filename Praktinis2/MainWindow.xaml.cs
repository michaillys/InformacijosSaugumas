using System.Windows;
using System.Windows.Controls;

namespace Praktinis2
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

        SourceSelect sourceSelect = new SourceSelect();

        private void BrowseSource_Click(object sender, RoutedEventArgs e)
        {
            sourceSelect.SelectSource();
            txtSourcePath.Text = sourceSelect.SourcePath;
        }

        private void cmbEncryptionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BrowseOutput_Click(object sender, RoutedEventArgs e)
        {
            sourceSelect.SelectOutput();
            txtOutputFolder.Text = sourceSelect.OutputPath;
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourcePath.Text) || string.IsNullOrEmpty(txtOutputFolder.Text))
            {
                MessageBox.Show("Please select source and output paths");
                return;
            }
            else if (cmbEncryptionMode.SelectedItem == null)
            {
                MessageBox.Show("Please select encryption mode");
                return;
            }
            else
            {
                AesEncryption aesEncryption = new AesEncryption(cmbEncryptionMode.Text, txtSourcePath.Text, txtOutputFolder.Text, txtEncryptionKey.Text);
                MessageBox.Show(aesEncryption.Mode);

                aesEncryption.Encrypt();
            }

        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourcePath.Text) || string.IsNullOrEmpty(txtOutputFolder.Text))
            {
                MessageBox.Show("Please select source and output paths");
                return;
            }
            else if (cmbEncryptionMode.SelectedItem == null)
            {
                MessageBox.Show("Please select encryption mode");
                return;
            }
            else
            {
                AesEncryption aesEncryption = new AesEncryption(cmbEncryptionMode.Text, txtSourcePath.Text, txtOutputFolder.Text, txtEncryptionKey.Text);
                MessageBox.Show(aesEncryption.Mode);

                aesEncryption.Decrypt();
            }

        }
    }
}