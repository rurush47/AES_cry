using System;
using System.Collections;
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

            return EncryptBlocks(blocks, key)
                    .Select<State,string>(b => b.ToString())
                    .Aggregate(String.Concat);
        }

        public static string DecryptMessage(string cypher, string keyString)
        {
            if (string.IsNullOrEmpty(cypher) || !IsKeyValid(keyString) 
                || !OnlyHexInString(cypher)) return null;

            Key key = new Key(StringToHex(keyString));
            List<byte[]> blocks = SplitToBlocks(cypher, true);

            return DecryptBlocks(blocks, key)
                    .Select<State, string>(b => b.ToAsciiString())
                    .Aggregate(String.Concat);
        }

        public static byte[] EncryptBytes(List<byte[]> blocks, Key key)
        {
            IEnumerable<byte[]> encryptedBlocks = EncryptBlocks(blocks, key)
                                                    .Select<State,byte[]>(b => b.ToBytesArray());
            return FlattenToArray(encryptedBlocks);
        }

        public static byte[] EncryptBytesCFB(List<byte[]> blocks, byte[] iv, Key key)
        {
            IEnumerable<byte[]> encryptedBlocks = EncryptBlocksCFB(blocks, iv, key)
                                                    .Select<State, byte[]>(b => b.ToBytesArray());
            return FlattenToArray(encryptedBlocks);
        }

        public static byte[] DecryptBytes(List<byte[]> blocks, Key key)
        {
            IEnumerable<byte[]> decryptedBlocks = DecryptBlocks(blocks, key)
                                                    .Select<State, byte[]>(b => b.ToBytesArray());
            return FlattenToArray(decryptedBlocks);
        }

        public static byte[] DecryptBytesCFB(List<byte[]> blocks, byte[] iv, Key key)
        {
            IEnumerable<byte[]> decryptedBlocks = DecryptBlocksCFB(blocks, iv, key)
                                                    .Select<State, byte[]>(b => b.ToBytesArray());
            return FlattenToArray(decryptedBlocks);
        }

        private static T[] FlattenToArray<T>(IEnumerable<IEnumerable<T>> enumerable)
        {
            return enumerable
                    .SelectMany(b => b)
                    .ToArray();
        }


        // ============= CFB encryption / decryption =========

        public static string EncryptMessageCFB(string message, string ivString, string keyString)
        {
            if (string.IsNullOrEmpty(message) || !IsKeyValid(keyString)
                || !IsIvValid(ivString)) return null;

            Key key = new Key(StringToHex(keyString));
            byte[] iv = StringToHex(ivString);
            List<byte[]> blocks = SplitToBlocks(message);

            return EncryptBlocksCFB(blocks, iv, key)
                    .Select<State, string>(b => b.ToString())
                    .Aggregate(String.Concat);
        }

        public static string DecryptMessageCFB(string cypher, string ivString, string keyString)
        {
            if (string.IsNullOrEmpty(cypher) || !IsKeyValid(keyString)
                || !OnlyHexInString(cypher) || !IsIvValid(ivString)) return null;

            Key key = new Key(StringToHex(keyString));
            byte[] iv = StringToHex(ivString);
            List<byte[]> blocks = SplitToBlocks(cypher, true);

            return DecryptBlocksCFB(blocks, iv, key)
                    .Select<State, string>(b => b.ToAsciiString())
                    .Aggregate(String.Concat);
        }


        // ============= Blocks Enc / Dec =============

        public static List<State> EncryptBlocksCFB(List<byte[]> blocks, byte[] iv, Key key)
        {
            // CFB encryption is sequential
            List<State> result = new List<State>();
            State ciphertext = new State(iv);

            foreach (var block in blocks)
            {
                State plaintext = new State(block);
                ciphertext = EncryptBlock(ciphertext, key);
                ciphertext.Xor(plaintext);
                result.Add(ciphertext);
            }

            return result;
        }

        public static List<State> DecryptBlocksCFB(List<byte[]> blocks, byte[] iv, Key key)
        {
            blocks.Insert(0, iv);
            List<State> blocksStates = blocks.AsParallel()
                                        .Select(b => new State(b))
                                        .ToList();
            // Parallel block encryption enabled by CFB
            List<State> encrypted = blocksStates.AsParallel()
                                        .Select(bs => EncryptBlock(bs, key))
                                        .ToList();

            // Parallel XORing of encrypted blocks and ciphertexts
            return encrypted
                    .AsParallel()
                    .Zip( blocksStates.Skip(1).AsParallel()
                        , (enc, ciph) =>
                            {
                                enc.Xor(ciph);
                                return enc;
                            }
                        )
                    .ToList();
        }

        public static List<State> EncryptBlocks(List<byte[]> blocks, Key key)
        {
            return blocks.Select(b => EncryptBlock(b, key)).ToList();
        }

        public static List<State> DecryptBlocks(List<byte[]> blocks, Key key)
        {
            return blocks.Select(b => DecryptBlock(b, key)).ToList();
        }

        // ============== Single Block Encryption / Decryption =================

        public static State EncryptBlock(byte[] inputPlain, Key key)
        {
            State initState = new State(inputPlain);
            return EncryptBlock(initState, key);
        }

        private static State EncryptBlock(State initState, Key key)
        {
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
            return DecryptBlock(initState, key);
        }

        private static State DecryptBlock(State initState, Key key)
        {
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

        public static List<byte[]> SplitBytesToBlocks(byte[] byteArray)
        {
            List<byte[]> blocks = new List<byte[]>();
            int arraySize = byteArray.Length;
            int counter = 0;

            while (counter < arraySize)
            {
                byte[] block = new byte[16];
                int toCopy = Math.Min(arraySize - counter, 16);
                Array.Copy(byteArray, counter, block, 0, toCopy);
                blocks.Add(block);
                counter += 16;
            }

            return blocks;
        }


        public static bool IsIvValid(string ivString)
        {
            return OnlyHexInString(ivString) && ivString.Length == 32; // 16 bytes -> one block size
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

        public static Bitmap ProcessBitmap(string bitmapPath, string keyString, bool decrypt = false)
        {
            if (string.IsNullOrEmpty(bitmapPath) || !IsKeyValid(keyString)) return null;

            Bitmap image = new Bitmap(bitmapPath);
            Key key = new Key(StringToHex(keyString));
            byte[] byteArray = BitmapToByteArray(image);

            List<byte[]> blocks = SplitBytesToBlocks(byteArray);

            var processedPixels = decrypt ? DecryptBytes(blocks, key) : EncryptBytes(blocks, key);

            ApplyBytesToBitmap(image, processedPixels);

            return image;
        }

        public static Bitmap ProcessBitmapCFB(string bitmapPath, string keyString, string ivString, bool decrypt = false)
        {
            if (string.IsNullOrEmpty(bitmapPath) || !IsKeyValid(keyString)
                || !IsIvValid(ivString)) return null;

            Bitmap image = new Bitmap(bitmapPath);
            Key key = new Key(StringToHex(keyString));
            byte[] byteArray = BitmapToByteArray(image);
            byte[] iv = StringToHex(ivString);
            List<byte[]> blocks = SplitBytesToBlocks(byteArray);

            var processedPixels = decrypt ? DecryptBytesCFB(blocks, iv, key) : EncryptBytesCFB(blocks, iv, key);

            ApplyBytesToBitmap(image, processedPixels);

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
