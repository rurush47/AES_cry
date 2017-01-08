using System;
using System.Collections.Generic;
using Aes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class AlgorithmTest
    {
        [TestMethod]
        public void EncryptionTest()
        {
            string message = "12345789abcdexyz";
            string key = "112233445566778899aabbccddeeff00";

            string expectedResult = "6A19566351E9F22CB4508563C59073A7";

            string result = Algorithm.EncryptMessage(message, key);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DecryptionTest()
        {
            string cypher = "6A19566351E9F22CB4508563C59073A7";
            string key = "112233445566778899aabbccddeeff00";

            string expectedResult = "12345789abcdexyz";

            string result = Algorithm.DecryptMessage(cypher, key);

            Assert.AreEqual(result, expectedResult);
        }


        // Expected Ciphertexts from http://aes.online-domain-tools.com/

        [TestMethod]
        public void AlgorithmWorkTest()
        {
            string message = "123456789abcdexyza";
            string key = "00112233445566778899aabbccddeeff";
            string expectedCiphertext = "05c2d3ebcb277c1c3d3f20fc232ba0982dc7b7e0efd53fa5aaf863220cfbd260".ToUpper();

            string result = Algorithm.EncryptMessage(message, key);
            Assert.AreEqual(expectedCiphertext, result);
            string decryptionResult = Algorithm.DecryptMessage(result, key);
            Assert.AreEqual(message, decryptionResult);
        }

        [TestMethod]
        public void KeyOf192BitsWorkTest()
        {
            string message = "123456789abcdexyza";
            string key = "00112233445566778899aabbccddeeff0011223344556677";
            string expectedCiphertext = "ccad5c2cee752982963287c8ab637d846c63d1102d406d9a03ec99f9d24b04af".ToUpper();

            string result = Algorithm.EncryptMessage(message, key);
            Assert.AreEqual(expectedCiphertext, result);
            string decryptionResult = Algorithm.DecryptMessage(result, key);
            Assert.AreEqual(message, decryptionResult);
        }

        [TestMethod]
        public void KeyOf256BitsWorkTest()
        {
            string message = "123456789abcdexyza";
            string key = "00112233445566778899aabbccddeeff00112233445566778899aabbccddeeff";
            string expectedCiphertext = "122a44da6227e3a012831f7214e2d916a2f153b1c828baaa40952d7705b90da4".ToUpper();

            string result = Algorithm.EncryptMessage(message, key);
            Assert.AreEqual(expectedCiphertext, result);
            string decryptionResult = Algorithm.DecryptMessage(result, key);
            Assert.AreEqual(message, decryptionResult);
        }

        [TestMethod]
        public void SplitMessageTest()
        {
            string message = "12345789abcdexyzabc";
            byte[] expectedResult =
            {
                0x61, 0x62, 0x63, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };

            List<byte[]> bytes = Algorithm.SplitToBlocks(message);

            Assert.AreEqual(bytes.Count, 2);
            CollectionAssert.AreEqual(bytes[1], expectedResult);
        }

        [TestMethod]
        public void SplitByteArrayTest()
        {
            byte[] initData =
            {
                0x61, 0x62, 0x63, 0x64,
                0x61, 0x62, 0x63, 0x64,
                0x61, 0x62, 0x63, 0x64,
                0x61, 0x62, 0x63, 0x64,
                0x22
            };

            List<byte[]> blocks = Algorithm.SplitBytesToBlocks(initData);
            
            Assert.AreEqual(blocks.Count, 2);
            Assert.AreEqual(blocks[1][0], 0x22);
            Assert.AreEqual(blocks[1][1], 0x00);
        }

        [TestMethod]
        public void CFBEncryptsAndDecryptsTest()
        {
            string key = "00112233445566778899aabbccddeeff";
            string iv = "0123456789abcdef0123456789abcdef";
            string message = "1234567890qwertyuiopasdfghjklzxcvbnm1234567890qwertyuiopasdfghjklzxcvbnm";

            string ciphertext = Algorithm.EncryptMessageCFB(message, iv, key);
            string plaintext = Algorithm.DecryptMessageCFB(ciphertext, iv, key);

            Assert.AreEqual(message, plaintext);
        }
    }
}
