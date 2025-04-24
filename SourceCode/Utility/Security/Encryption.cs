using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;



namespace Utility
{
    public class Encryption
    {
        // Encryption method using AES
        public static string EncryptMessage(string plainText, string key, string iv)
        {
            // Convert key and IV to byte arrays
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }

                    // Return the encrypted bytes from the memory stream.
                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted); // Return as base64 string for easy transmission
                }
            }
        }

        // Decryption method using AES
        public static string DecryptMessage(string encryptedBase64, string key, string iv)
        {
            // Convert key and IV to byte arrays
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64); // Convert base64 to byte array

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Return the decrypted string
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Helper method to hash the passwords and secrets (for secure comparison)
        public static string HashPassword(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        // Encrypt a string of data 
        public static string Encrypt(string ClearData, string password)
        {
            // Convert ClearData into a byte array
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(ClearData);

            // We need to turn the password into Key and IV. 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            //PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
            //new byte[] {0x44, 0x64, 0x12, 0x5e, 0x10, 0x7d, 
            //0x56, 0x46, 0x32, 0x56, 0x76, 0x56, 0x12});

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
            new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] Key = pdb.GetBytes(32);
            byte[] IV = pdb.GetBytes(16);

            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the
            // next line with something like 
            //      TripleDES alg = TripleDES.Create(); 
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because
            // the algorithm is operating in its default 
            // mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte) 
            // of the data before it is encrypted, and then each
            // encrypted block is XORed with the 
            // following block of plaintext.
            // This is done to make encryption more secure. 

            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream and the output will be written
            // in the MemoryStream we have provided. 
            CryptoStream cs = new CryptoStream(ms,
            alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption 
            cs.Write(buffer, 0, buffer.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our encryption and
            // there is no more data coming in, 
            // and it is now a good time to apply the padding and
            // finalize the encryption process. 
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            byte[] encryptedData = ms.ToArray();

            return Convert.ToBase64String(encryptedData);
        }


        // Decrypt a byte array into a byte array using a key and an IV 
        public static string Decrypt(string cipherData, string password)
        {
            // Convert cipherData into a byte array
            byte[] buffer = Convert.FromBase64String(cipherData);
            //            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(cipherData);

            // We need to turn the password into Key and IV. 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
            new byte[] {0x44, 0x64, 0x12, 0x5e, 0x10, 0x7d,
            0x56, 0x46, 0x32, 0x56, 0x76, 0x56, 0x12});

            byte[] Key = pdb.GetBytes(32);
            byte[] IV = pdb.GetBytes(16);

            // Create a MemoryStream that is going to accept the
            // decrypted bytes 
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the next
            // line with something like 
            //     TripleDES alg = TripleDES.Create(); 
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because the algorithm
            // is operating in its default 
            // mode called CBC (Cipher Block Chaining). The IV is XORed with
            // the first block (8 byte) 
            // of the data after it is decrypted, and then each decrypted
            // block is XORed with the previous 
            // cipher block. This is done to make encryption more secure. 
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream 
            // and the output will be written in the MemoryStream
            // we have provided. 
            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption 
            cs.Write(buffer, 0, buffer.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our decryption
            // and there is no more data coming in, 
            // and it is now a good time to remove the padding
            // and finalize the decryption process. 

            //cs.Close();

            // Now get the decrypted data from the MemoryStream. 
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            byte[] decryptedData = ms.ToArray();

            return System.Text.Encoding.Unicode.GetString(decryptedData);

        }

        public static string Enc(string Data)
        {
            System.Security.Cryptography.DESCryptoServiceProvider md5Obj = new System.Security.Cryptography.DESCryptoServiceProvider();
            byte[] key = new byte[] { 146, 43, 41, 160, 64, 185, 185, 121 };
            md5Obj.Key = key;
            md5Obj.IV = key;
            ICryptoTransform desencrypt = md5Obj.CreateEncryptor();
            byte[] byteToHash = System.Text.Encoding.ASCII.GetBytes(Data);
            byte[] result = desencrypt.TransformFinalBlock(byteToHash, 0, byteToHash.Length);
            string ret = BitConverter.ToString(result);
            return ret;
        }

        public static string Dec(string cipherData)
        {
            string[] arrayData = cipherData.Split("-".ToCharArray());
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[arrayData.Length];
            for (int i = 0; i < arrayData.Length; i++)
            {
                inputByteArray[i] = byte.Parse(arrayData[i], System.Globalization.NumberStyles.HexNumber);
            }

            des.Key = new byte[] { 146, 43, 41, 160, 64, 185, 185, 121 };
            des.IV = new byte[] { 146, 43, 41, 160, 64, 185, 185, 121 };
            ICryptoTransform desencrypt = des.CreateDecryptor();
            byte[] result = desencrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
            string ret = Encoding.UTF8.GetString(result);
            return ret;
        }

    }
}
