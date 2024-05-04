using System.Security.Cryptography;

namespace BTPopriri.GarnishmentManagement.Api.E2ETests.Core
{
    public class AesEncryptionService
    {
        private static readonly byte[] AesKey = { 204, 164, 237, 20, 162, 107, 232, 174, 157, 113, 18, 218, 14, 165, 223, 225, 253, 0, 69, 110, 180, 194, 186, 63, 110, 173, 178, 88, 210, 66, 137, 133 };
        private static readonly byte[] AesIV = { 166, 6, 19, 209, 176, 231, 42, 208, 44, 128, 9, 223, 55, 57, 142, 211 };

        public static string Encrypt(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));

            string encryptedText;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AesKey;
                aesAlg.IV = AesIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    var encrypted = msEncrypt.ToArray();

                    encryptedText = Convert.ToBase64String(encrypted);
                }
            }

            return encryptedText;
        }

        public static string Decrypt(string encryptedText)
        {
            if (encryptedText == null || encryptedText.Length <= 0)
                throw new ArgumentNullException(nameof(encryptedText));

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AesKey;
                aesAlg.IV = AesIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    plaintext = srDecrypt.ReadToEnd();
                }
            }

            return plaintext;
        }
    }
}
