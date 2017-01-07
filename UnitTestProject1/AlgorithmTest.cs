using System;
using System.Collections.Generic;
using Aes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void AlgorithmWorkTest()
        {
            string message = "12345789abcdexyza";
            string key = "112233445566778899aabbccddeeff00";

            string result = Algorithm.EncryptMessage(message, key);
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
                0x61, 0x62, 0x63, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x22
            };

            List<byte[]> blocks = Algorithm.SplitToBlocks(initData);

            Assert.AreEqual(blocks.Count, 2);
            Assert.AreEqual(blocks[1][0], 0x22);
        }
    }
}
