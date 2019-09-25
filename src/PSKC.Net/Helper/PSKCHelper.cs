using PSKC.Net.Xml;
using System;
using System.IO;

namespace PSKC.Net.Helper
{
    public class PSKCHelper
    {
        public static string Base64EncodedBinaryToHex(string base64Encoded)
        {
            var data = Convert.FromBase64String(base64Encoded);
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        public static string HexToBase64EncodedBinary(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                throw new ArgumentNullException("Input parameter: hex can not be null or empty");
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Invalid hex length");

            var numberOfChars = hex.Length;
            byte[] bytes = new byte[numberOfChars / 2];
            for (int i = 0; i < numberOfChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return Convert.ToBase64String(bytes);
        }

        public static KeyContainer ToKeyContainer(string filePath)
        {

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(KeyContainer));
                var keyContainer = (KeyContainer) serializer.Deserialize(streamReader);
                return keyContainer;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
            return null;
        }
    }
}
