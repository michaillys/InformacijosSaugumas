using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _3Praktikinis
{
    public static class WriteToFile
    {
        static string path = @"C:\Users\Public\Documents\RSAEncryption.txt";
        public static void Write(string text)
        {
            System.IO.File.WriteAllText(path, text);
        }
    }

    public static class ReadFromFile
    {
        static string path = @"C:\Users\Public\Documents\RSAEncryption.txt";
        public static string Read()
        {
            return System.IO.File.ReadAllText(path);
        }
    }

    public static class WriteToJSON
    {
        static string path = @"C:\Users\Public\Documents\RSAKeys.json";

        public static void WriteKeys(int p, int q, int privateKey, int publicKey)
        {
            int n = p * q;
            //save private and public keys to json file with n
            string json = "{\n";
            json += "\"n\": " + n + ",\n";
            json += "\"private\": " + privateKey + ",\n";
            json += "\"public\": " + publicKey + "\n";
            json += "}";
            System.IO.File.WriteAllText(path, json);
        }

        public static string ReadKeys()
        {
            return System.IO.File.ReadAllText(path);
        }
    }

    public class RSAKeys
    {
        public int n { get; set; }
        public int privateKey { get; set; }
        public int publicKey { get; set; }

        public static string path = @"C:\Users\Public\Documents\RSAKeys.json";
        

        public static void WriteKeys(int p, int q, int privateKey, int publicKey)
        {
            int n = p * q;


            // Create RSAKeys object to store the data
            RSAKeys keys = new RSAKeys
            {
                n = n,
                privateKey = privateKey,
                publicKey = publicKey
            };

            // Convert the RSAKeys object to JSON string
            string json = JsonSerializer.Serialize(keys);

            // Write JSON string to file
            File.WriteAllText(path, json);
        }

        public static RSAKeys ReadKeys()
        {
            // Read JSON string from file
            string json = File.ReadAllText(path);

            // Deserialize JSON string to RSAKeys object
            RSAKeys keys = JsonSerializer.Deserialize<RSAKeys>(json);

            return keys;
        }
    }

    


}
