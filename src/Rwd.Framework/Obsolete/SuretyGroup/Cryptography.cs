using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rwd.Framework.Obsolete.SuretyGroup
{
    public static class Cryptography
    {
        private static string _key = "&%#@?,:*";
        // Encrypt the text
        public static string EncryptText(string strText)
        {

            if (string.IsNullOrEmpty(strText))
                return string.Empty;
            else
                return Encrypt(strText, _key);
        }

        //Decrypt the text 
        public static string DecryptText(string strText)
        {
            if (string.IsNullOrEmpty(strText))
                return string.Empty;
            else
                return Decrypt(strText, _key);
        }

        //The function used to encrypt the text
        private static string Encrypt(string strText, string strEncrKey)
        {
            byte[] byKey = { };
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey);
                
                var des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        //The function used to decrypt the text
        private static string Decrypt(string strText, string sDecrKey)
        {
            if (strText == null) return string.Empty;

            byte[] byKey = { };
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            var inputByteArray = new byte[strText.Length + 1];

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey);
                var des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                var encoding = Encoding.UTF8;

                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }




    }
}
