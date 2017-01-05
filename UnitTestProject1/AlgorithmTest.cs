using System;
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

            string result = Algorithm.Encrypt(message, key);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DecryptionTest()
        {
            string cypher = "6A19566351E9F22CB4508563C59073A7";
            string key = "112233445566778899aabbccddeeff00";

            string expectedResult = "3132333435373839616263646578797A";

            string result = Algorithm.Decrypt(cypher, key);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AlgorithmWorkTest()
        {
            string message = "12345789abcdexyz";
            string key = "112233445566778899aabbccddeeff00";

            string result = Algorithm.Encrypt(message, key);
            string decryptionResult = Algorithm.Decrypt(result, key);
            Assert.AreEqual(message, decryptionResult);
        }
    }
}
