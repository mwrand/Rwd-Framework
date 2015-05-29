using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Rwd.Framework.Security
{
    public class Cryptography
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string base64Encode(string sData)
        {
            try
            {
                var encData_byte = Encoding.UTF8.GetBytes(sData);
                return Convert.ToBase64String(encData_byte);
            }
            catch(Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string base64Decode(string sData)
        {
            try
            {
                sData = sData.Replace("%3D", "=");
                var utf8Decode = (new System.Text.UTF8Encoding()).GetDecoder();
                var todecode_byte = Convert.FromBase64String(sData);

                var charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                var decoded_char = new char[charCount];

                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                return new String(decoded_char);
            }
            catch(Exception ex)
            {
                throw new Exception("Error in base64Decode: " + ex.Message +  " sdata: " + sData + " stack trace: " + ex.StackTrace);
            }

        }

        /// <summary>
        /// Creates a hash that can then used to compare...no decrypt.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] Md5Encrypt(string text)
        {
            var encoder = new UTF8Encoding();
            var md5Hasher = new MD5CryptoServiceProvider();
            return md5Hasher.ComputeHash(encoder.GetBytes(text));
        }

    }
}
