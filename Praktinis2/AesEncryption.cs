using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.IO;


namespace Praktinis2
{
    class AesEncryption
    {
        public string Mode { get; set; }
        private string SourcePath { get; set; }
        private string OutputPath { get; set; }

        private string KeyName { get; set; }    

        private byte[] Key;
        private byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");




       

        

        public AesEncryption(string mode, string sourcePath, string outputPath)
        {
            Mode = mode;
            SourcePath = sourcePath;
            OutputPath = outputPath;
        }

        public AesEncryption(string mode, string sourcePath, string outputPath, string key)
        {
            Mode = mode;
            SourcePath = sourcePath;
            OutputPath = outputPath;
            KeyName = key;


            Rfc2898DeriveBytes pdb = new(key, IV, 1000);
            Key = pdb.GetBytes(32);
        }

        public void Encrypt()
        {
        
            using (Aes myAes = Aes.Create())
            {
                switch (Mode.ToUpper())
                {
                    case "CBC":
                        myAes.Mode = CipherMode.CBC;
                        break;
                    case "ECB":
                        myAes.Mode = CipherMode.ECB;
                        break;
                    case "CFB":
                        myAes.Mode = CipherMode.CFB;
                        break;
                    default:
                        myAes.Mode = CipherMode.CBC;
                        break;
                }   

                myAes.Key = Key;
                myAes.IV = IV;

                OutputPath = OutputPath + "\\" + "Encrypted_" + Mode + "_" + KeyName + Path.GetFileName(SourcePath);

                ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV); 

                
                
                using (FileStream fsInput = new FileStream(SourcePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsEncrypted = new FileStream(OutputPath, FileMode.Create, FileAccess.Write))
                    {
                        using (CryptoStream cs = new CryptoStream(fsEncrypted, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            do
                            {
                                bytesRead = fsInput.Read(buffer, 0, buffer.Length);
                                cs.Write(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                        }
                    }
                }
            }
        }

        public void Decrypt()
        {
            using (Aes myAes = Aes.Create())
            {
                switch (Mode.ToUpper())
                {
                    case "CBC":
                        myAes.Mode = CipherMode.CBC;
                        break;
                    case "ECB":
                        myAes.Mode = CipherMode.ECB;
                        break;
                    case "CFB":
                        myAes.Mode = CipherMode.CFB;
                        break;
                    default:
                        myAes.Mode = CipherMode.CBC;
                        break;
                }

                myAes.Key = Key;
                myAes.IV = IV;

                OutputPath = OutputPath + "\\" + "Decrypted_" + Path.GetFileName(SourcePath);

                ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);

                using (FileStream fsEncrypted = new FileStream(SourcePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsDecrypted = new FileStream(OutputPath, FileMode.Create, FileAccess.Write))
                    {
                        using (CryptoStream cs = new CryptoStream(fsEncrypted, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            do
                            {
                                bytesRead = cs.Read(buffer, 0, buffer.Length);
                                fsDecrypted.Write(buffer, 0, bytesRead);
                            } 
                            while (bytesRead != 0);
                        }
                    }
                }
            }
        }
        
    }
}
