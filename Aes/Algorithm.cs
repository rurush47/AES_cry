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
        public static string EncryptBlock(string messageString, string keyString)
        {
            byte[] inputKey = StringToHex(keyString);
            byte[] inputPlain = AsciiToByte(messageString);

            if (Key.IsValid(inputKey))
            {
                Key key = new Key(inputKey);
                State initState = new State(inputPlain);

                int numberOfRounds = key.GetNumberOfRounds();
                //Initial round
                State currentState = initState.AddRoundKey(key, 0);

                for (int i = 1; i < numberOfRounds; i++)
                {
                    currentState = currentState.SubBytes();
                    currentState = currentState.ShiftRows();
                    currentState = currentState.MixColumns();
                    currentState = currentState.AddRoundKey(key, i);
                }

                //Final round
                currentState = currentState.SubBytes();
                currentState = currentState.ShiftRows();
                currentState = currentState.AddRoundKey(key, numberOfRounds);

                return currentState.ToString();
            }

            return null;
        }

        public static string DecryptBolock(string cypher, string keyString)
        {
            byte[] inputKey = StringToHex(keyString);
            byte[] inputPlain = StringToHex(cypher);

            if (Key.IsValid(inputKey))
            {
                Key key = new Key(inputKey);
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

            return null;
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
    }
}
