using System;
using PSKC.Net.Helper;
using Xunit;

namespace PSKC.Net.Tests
{
    public class PskcHelperTests
    {

        [Theory]
        [InlineData("qrvM3e7/ABEiM0RVZneImQ==", "AABBCCDDEEFF00112233445566778899")]
        [InlineData("mYh3ZlVEMyIRAP/u3cy7qg==", "99887766554433221100FFEEDDCCBBAA")]

        public void Base64_Binary_To_Hexstring(string b64string, string expected)
        {
            var result= PSKCHelper.Base64EncodedBinaryToHex(b64string);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null)]
        public void Base64_Binary_To_Hexstring_Null_Input(string b64string)
        {
            
            Assert.Throws<ArgumentNullException>(() => PSKCHelper.Base64EncodedBinaryToHex(b64string));

        }

        [Theory]
        [InlineData("invalidBase64===")]
        public void Base64_Binary_To_Hexstring_Invalid_Input(string b64string)
        {
            Assert.Throws<FormatException>(() => PSKCHelper.Base64EncodedBinaryToHex(b64string));


        }

        [Theory]
        [InlineData("AABBCCDDEEFF00112233445566778899", "qrvM3e7/ABEiM0RVZneImQ==")]
        [InlineData("99887766554433221100FFEEDDCCBBAA", "mYh3ZlVEMyIRAP/u3cy7qg==")]
        public void Hexstring_To_Base64_Binary(string hex, string expected)
        {
            var result = PSKCHelper.HexToBase64EncodedBinary(hex);
            Assert.Equal(expected, result);


        }

        [Theory]
        [InlineData(null)]
        public void Hexstring_To_Base64_Binary_Null_Input(string hex)
        {
            Assert.Throws<ArgumentNullException>(() => PSKCHelper.HexToBase64EncodedBinary(hex));
        }
        [Theory]
        [InlineData("ABC")]
        public void Hexstring_To_Base64_Binary_Invalid_Length(string hex)
        {
            Assert.Throws<ArgumentException>(() => PSKCHelper.HexToBase64EncodedBinary(hex));
        }
        [Theory]
        [InlineData("UUVVWWXXYYZZ")]
        public void Hexstring_To_Base64_Binary_Invalid_Input(string hex)
        {
            Assert.Throws<FormatException>(() => PSKCHelper.HexToBase64EncodedBinary(hex));
        }

        [Theory]
        [InlineData("Pskc.xml")]
        public void File_To_KeyContainer(string path)
        {
            var container = PSKCHelper.ToKeyContainer(path);
            Assert.True(container.KeyPackages.Count == 2);
        }
    }
}
