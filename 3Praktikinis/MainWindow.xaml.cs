using System.Windows;
using System.Windows.Controls;

namespace _3Praktikinis
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

        private void txtP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtQ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {           
            int p = int.Parse(txtP.Text);
            //check if p is prime
            if (p < 2)
            {
                MessageBox.Show("P must be greater than 1");
                return;
            }
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0)
                {
                    MessageBox.Show("P must be prime");
                    return;
                }
            }


            int q = int.Parse(txtQ.Text);
            //check if q is prime
            if (q < 2)
            {
                MessageBox.Show("Q must be greater than 1");
                return;
            }
            for (int i = 2; i < q; i++)
            {
                if (q % i == 0)
                {
                    MessageBox.Show("Q must be prime");
                    return;
                }
            }
            int privateKey = RSAEncryption.GetRSAPrivateKey(p, q);
            int publicKey = RSAEncryption.GetRSAPublicKey(p, q);

            RSAKeys keys = new RSAKeys();
            RSAKeys.WriteKeys(p, q, privateKey, publicKey);


            txtPrivateKey.Text = privateKey.ToString();
            txtPublicKey.Text = publicKey.ToString();
            //WriteToJSON.WriteKeys(p, q, privateKey, publicKey);

            
            
            string message = txtX.Text;
            string encryptedMessage = RSAEncryption.RSAEncrypt(p, q, message);
            txtEncryptedMessage.Text = encryptedMessage;
            WriteToFile.Write(encryptedMessage);

            

            

        }

        private void txtEncryptedMessage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrivateKey_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPublicKey_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            //int d = int.Parse(txtPrivateKey.Text);
            //int p = int.Parse(txtP.Text);
            //int q = int.Parse(txtQ.Text);


            string message;
            message = ReadFromFile.Read();
            RSAKeys readKeys = new RSAKeys();
            readKeys = RSAKeys.ReadKeys();
            int d = readKeys.privateKey;
            int n = readKeys.n;
            string encryptedMessage = txtEncryptedMessage.Text;
            string decryptedMessage = RSAEncryption.RSADecrypt(n, d, encryptedMessage);
            txtDecryptedMessage.Text = decryptedMessage;

        }

        private void txtDecryptedMessage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}