using System.Text;

namespace InformacijosSaugumas
{
    public class VigenaryMethod
    {
        private static char[] characters = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        public static string Encrypt(string text, string key)
        {
            string newKey = "";
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    newKey += " ";
                }
                else
                {
                    newKey += key[j];
                    j++;
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                }
            }

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    encryptedText.Append(" ");
                }
                else
                {
                    text = text.ToLower();

                    int characterPosition = Array.IndexOf(characters, text[i]);

                    int keyPosition = Array.IndexOf(characters, newKey[i]);

                    int encryptedIndex = (characterPosition + keyPosition) % characters.Length;

                    encryptedText.Append(characters[encryptedIndex]);
                }
            }

            return encryptedText.ToString();
        }

        public static string Decrypt(string text, string key)
        {
            string newKey = "";
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    newKey += " ";
                }
                else
                {
                    newKey += key[j];
                    j++;
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                }
            }

            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    decryptedText.Append(" ");
                }
                else
                {
                    text = text.ToLower();

                    int characterPosition = Array.IndexOf(characters, text[i]);

                    int keyPosition = Array.IndexOf(characters, newKey[i]);

                    int decryptedIndex = (characterPosition - keyPosition + characters.Length) % characters.Length;

                    decryptedText.Append(characters[decryptedIndex]);

                }
            }

            return decryptedText.ToString();
        }
    }

    public class VigenaryANSIIMethod
    {

        public static string Encrypt(string text, string key)
        {
            string newKey = "";
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    newKey += " ";
                }
                else
                {
                    newKey += key[j];
                    j++;
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                }
            }

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    encryptedText.Append(" ");
                }
                else
                {
                    int characterPosition = (int)text[i] - 32;
                    int keyPosition = (int)newKey[i] - 32;
                    int encryptedIndex = (characterPosition + keyPosition) % 95;
                    encryptedText.Append((char)(encryptedIndex + 32));
                }
            }

            return encryptedText.ToString();
        }

        public static string Decrypt(string text, string key)
        {
            string newKey = "";
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    newKey += " ";
                }
                else
                {
                    newKey += key[j];
                    j++;
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                }
            }

            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    decryptedText.Append(" ");
                }
                else
                {
                    int characterPosition = (int)text[i] - 32;
                    int keyPosition = (int)newKey[i] - 32;
                    int decryptedIndex = (characterPosition - keyPosition + 95) % 95;
                    decryptedText.Append((char)(decryptedIndex + 32));
                }
            }

            return decryptedText.ToString();
        }
    }
}
