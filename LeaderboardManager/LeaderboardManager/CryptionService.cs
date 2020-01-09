using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace LeaderboardManager
{
    public class KeyIVPair
    {
        public byte[] Key;
        public byte[] IV;

        public KeyIVPair(byte[] key, byte[] iv)
        {
            Key = key;
            IV = iv;
        }
    }
    public enum CryptoAlgo { RC2, AES, Rijndael, DES, TripleDES}
    public class CryptionService
    {
        public KeyIVPair KeyIVPair { get; private set; }
        public CryptoAlgo ChosenAlgo { get; private set; }

        private SymmetricAlgorithm crypter;

        public CryptionService(CryptoAlgo chosenAlgo)
        {
            ChosenAlgo = chosenAlgo;

            switch (ChosenAlgo)
            {
                case CryptoAlgo.AES:
                    crypter = new AesManaged();
                    break;
                case CryptoAlgo.DES:
                    crypter = new TripleDESCryptoServiceProvider();
                    break;
                case CryptoAlgo.RC2:
                    crypter = new RC2CryptoServiceProvider();
                    break;
                case CryptoAlgo.Rijndael:
                    crypter = new RijndaelManaged();
                    break;
                case CryptoAlgo.TripleDES:
                    crypter = new TripleDESCryptoServiceProvider();
                    break;
                default:
                    break;
            }

            if (crypter != null)
            {
                KeyIVPair = new KeyIVPair(crypter.Key, crypter.IV);
            }
            else
            {
                throw new Exception("Initialization failed.");
            }
        }

        public byte[] EncryptData(byte[] data)
        {
            //ICryptoTransform encryptor = crypter.CreateEncryptor();

            //// Create the streams used for encryption.
            //using (MemoryStream msEncrypt = new MemoryStream())
            //{
            //    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            //    {
            //        csEncrypt.Write(data, 0, data.Length);
            //        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            //        {
            //            //Write all data to the stream.
            //            swEncrypt.Write(plainText);
            //        }
            //        encrypted = msEncrypt.ToArray();
            //    }
            //}
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            throw new NotImplementedException();
        }

    }
}
