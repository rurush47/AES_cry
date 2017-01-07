using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
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
                cypher += EncryptBlock(block, key).ToString();
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
                message += DecryptBlock(block, key).ToString();
            }

            return message;
        }

        public static byte[] EncryptBytes(List<byte[]> blocks, Key key)
        {
            List<byte> result = new List<byte>();

            foreach (var block in blocks)
            {
                result.AddRange(EncryptBlock(block, key).ToBytesArray());
            }

            return result.ToArray();
        }

        public static byte[] DecryptBytes(List<byte[]> blocks, Key key)
        {
            List<byte> result = new List<byte>();

            foreach (var block in blocks)
            {
                result.AddRange(DecryptBlock(block, key).ToBytesArray());
            }

            return result.ToArray();
        }

        public static State EncryptBlock(byte[] inputPlain, Key key)
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

                return currentState;
        }

        public static State DecryptBlock(byte[] inputPlain, Key key)
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

                return currentState;
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

        public static List<byte[]> SplitToBlocks(byte[] byteArray)
        {
            List<byte[]> blocks = new List<byte[]>();
            int arraySize = byteArray.Length;
            int counter = 0;

            while (counter < arraySize)
            {
                if (arraySize - counter >= 16)
                {
                    byte[] block = new byte[16];
                    Array.Copy(byteArray, counter, block, 0, 16);
                    blocks.Add(block);
                    counter += 16;
                }
                else
                {
                    List<byte> bytes = byteArray.Take(arraySize - counter).ToList();
                    for (int i = bytes.Count; i < 16; i++)
                    {
                        bytes.Add(0x00);
                    }
                    blocks.Add(bytes.ToArray());
                    byteArray = new byte[0];
                    counter += 16;
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

        public static Bitmap EncryptBitmap(string bitmapPath, string keyString)
        {
            if (string.IsNullOrEmpty(bitmapPath) || !IsKeyValid(keyString)) return null;

            Bitmap image = new Bitmap(bitmapPath);
            Key key = new Key(StringToHex(keyString));
            byte[] byteArray = BitmapToByteArray(image);

            List<byte[]> blocks = SplitToBlocks(byteArray);

            byte[] encryptedPixels = EncryptBytes(blocks, key);
            ApplyBytesToBitmap(image, encryptedPixels);

            return image;
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
        }

        public static void ApplyBytesToBitmap(Bitmap bitmap, byte[] bytes)
        {
            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(bytes, 0, ptr, numbytes);
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
        }
    }
}
