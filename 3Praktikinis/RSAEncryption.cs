using System.Text;

namespace _3Praktikinis
{
    public static class RSAEncryption
    {
        public static int GetRSAPublicKey(int p, int q)
        {
            int n = p * q;
            int phi = (p - 1) * (q - 1);
            int e = 2; 
                       
            while (GCD(e, phi) != 1)
            {
                e++;
            }
            return e;
        }

        public static int GetRSAPrivateKey(int p, int q)
        {
            int phi = (p - 1) * (q - 1);
            int e = GetRSAPublicKey(p, q);

            // Calculate the modular multiplicative inverse of e modulo phi(n)
            int d = ModInverse(e, phi);

            return d;
        }
        public static string RSAEncrypt(int p, int q, string message)
        {
            int n = p * q;
            int e = GetRSAPublicKey(p, q);
            string encryptedMessage = "";
            foreach (char c in message)
            {               
                int ascii = c;
                
                double encryptedChar = (double)Math.Pow(ascii, e);
                encryptedChar = encryptedChar % n;                
                int encryptedCharInt = (int)encryptedChar;
                
                encryptedMessage += encryptedCharInt.ToString() + " ";
            }
            return encryptedMessage;
        }

        public static string RSADecrypt(int n, int d, string encryptedMessage)
        {            
            StringBuilder decryptedMessage = new StringBuilder();
            string[] encryptedChars = encryptedMessage.Split(' ');
            foreach (string s in encryptedChars)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    try
                    {
                        int encryptedChar = int.Parse(s);
                        int decryptedCharInt = ModPow(encryptedChar, d, n);
                        char c = (char)decryptedCharInt;
                        decryptedMessage.Append(c);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error parsing '{s}': {ex.Message}");
                        // Handle parsing error
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"Parsing '{s}' resulted in overflow: {ex.Message}");
                        // Handle overflow error
                    }
                }
            }
            return decryptedMessage.ToString();
        }

        public static int ModPow(int value, int exponent, int modulus)
        {
            if (exponent < 0)
                throw new ArgumentOutOfRangeException(nameof(exponent), "Exponent must be non-negative.");

            long result = 1;
            long baseValue = value % modulus;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * baseValue) % modulus;
                exponent >>= 1;
                baseValue = (baseValue * baseValue) % modulus;
            }
            return (int)result;
        }
                
        public static int ModInverse(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                int q = a / m;
                int t = m;

                // m is remainder now, process same as Euclid's algorithm
                m = a % m;
                a = t;
                t = y;

                // Update x and y
                y = x - q * y;
                x = t;
            }

            // Make x positive
            if (x < 0)
                x += m0;

            return x;
        }
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }       

        
        public static int[] FindKeyPair(int n)
        {
            int[] keyPair = new int[2];
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    keyPair[0] = i;
                    keyPair[1] = n / i;
                    break;
                }
            }
            return keyPair;
        }

    }
}
