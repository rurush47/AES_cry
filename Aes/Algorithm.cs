using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Aes
{
    public class Algorithm
    {
        public static string EncryptMessage(string message, string keyString)
        {
            if (string.IsNullOrEmpty(message) || !IsKeyValid(keyString)) return null;

            Key key = new Key(StringToHex(keyString));
            List<byte[]> blocks = SplitToBlocks(message);
            string cypher = "";

            foreach (var block in blocks)
            {
                cypher += EncryptBlock(block, key);
            }

            return cypher;
        }

        public static string DecryptMessage(string cypher, string keyString)
        {
            if (string.IsNullOrEmpty(cypher) || !IsKeyValid(keyString) 
                || !OnlyHexInString(cypher)) return null;

            Key key = new Key(StringToHex(keyString));
            List<byte[]> blocks = SplitToBlocks(cypher, true);
            string message = "";

            foreach (var block in blocks)
            {
                message += DecryptBolock(block, key);
            }

            return message;
        }

        public static string EncryptBlock(byte[] inputPlain, Key key)
        {
                State initState = new State(inputPlain);

                int numberOfRounds = key.GetNumberOfRounds();

                State currentState = initState.AddRoundKey(key, 0);

                for (int i = 1; i < numberOfRounds; i++)
                {
                    currentState = currentState.SubBytes();
                    currentState = currentState.ShiftRows();
                    currentState = currentState.MixColumns();
                    currentState = currentState.AddRoundKey(key, i);
                }

                currentState = currentState.SubBytes();
                currentState = currentState.ShiftRows();
                currentState = currentState.AddRoundKey(key, numberOfRounds);

                return currentState.ToString();
        }

        public static string DecryptBolock(byte[] inputPlain, Key key)
        {
                State initState = new State(inputPlain);

                int numberOfRounds = key.GetNumberOfRounds();

                State currentState = initState.AddRoundKey(key, numberOfRounds);
                currentState = currentState.ShiftRowsInv();
                currentState = currentState.SubBytesInv();


                for (int i = numberOfRounds - 1; i > 0; i--)
                {
                    currentState = currentState.AddRoundKey(key, i);
                    currentState = currentState.MixColumnsInv();
                    currentState = currentState.ShiftRowsInv();
                    currentState = currentState.SubBytesInv();
                }

                currentState = currentState.AddRoundKey(key, 0);

                return currentState.ToAsciiString();
        }

        private static byte[] AsciiToByte(string s)
        {
            byte[] b = new byte[s.Length];
            b = Encoding.ASCII.GetBytes(s);
            return (b);
        }

        private static byte[] StringToHex(string s)
        {
            int size = s.Length / 2;
            byte[] b = new byte[size];

            for (int i = 0; i < size; i++)
            {
                b[i] = Convert.ToByte(s.Substring(2 * i, 2), 16);
            }

            return (b);
        }

        public static List<byte[]> SplitToBlocks(string message, bool isHex = false)
        {
            List<byte[]> blocks = new List<byte[]>();
            int splitPoint = isHex ? 32 : 16;

            while (message.Length != 0)
            {
                if (message.Length >= splitPoint)
                {
                    string blockString = message.Substring(0, splitPoint);
                    var block = isHex ? StringToHex(blockString) : AsciiToByte(blockString);
                    blocks.Add(block);
                    message = message.Remove(0, splitPoint);
                }
                else
                {
                    string blockString = message;
                    var block = isHex ? StringToHex(blockString) : AsciiToByte(blockString);
                    List<byte> bytes = block.ToList();
                    for (int i = bytes.Count; i < 16; i++)
                    {
                        bytes.Add(0x00);
                    }
                    blocks.Add(bytes.ToArray());
                    message = message.Remove(0, message.Length);
                }
            }

            return blocks;
        }



        public static bool IsKeyValid(string keyString)
        {
            return OnlyHexInString(keyString) && IsKeyLengthValid(keyString);
        }

        public static bool OnlyHexInString(string keyString)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(keyString, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static bool IsKeyLengthValid(string keyString)
        {
            return keyString.Length == 32 || keyString.Length == 48 || keyString.Length == 64;
        }
    }
}
