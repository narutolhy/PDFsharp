using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;
using ZLibNet;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
using PdfSharp.Pdf.Internal;
using System.Security.Cryptography;


namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            string filePathKey = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testKey.txt";
            string filePath = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\test4.pdf";
            string filePathDeco = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testDecode.txt";
            PdfDocument document = PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly);
            byte[] key = File.ReadAllBytes(filePathKey);
            //byte[] res = ZLibCompressor.DeCompress(testzip);
            byte[] decrpt = new byte[25];
            Array.Copy(key, 0, decrpt, 0, 16);
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes("19100sAlT");
            Array.Copy(byteArray, 0, decrpt, 16, 9);
            PdfStandardSecurityHandler securityHandler = document.SecurityHandler;
            var test = securityHandler._encryptionKey;
            MD5 _md5 = new MD5CryptoServiceProvider();
            byte[] testHash = SetHashKey(key, 191, 0);


            _md5.Initialize();
            //Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            _md5.TransformFinalBlock(testHash, 0, testHash.Length);

            //_md5.TransformFinalBlock(decrpt, 0, decrpt.Length);
            //Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            byte[] hashRes = _md5.Hash;
            byte[] decrp = File.ReadAllBytes(filePathDeco);

            byte[] iv = new byte[16];
            byte[] buff = new byte[decrp.Length - 16];
            Array.Copy(decrp, 0, iv, 0, 16);
            Array.Copy(decrp, 16, buff, 0, buff.Length);
            string plaintext = null;
            Aes myAes = Aes.Create();
            myAes.Key = hashRes;
            myAes.IV = iv;
           
            ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);
            using(MemoryStream msDecrypt = new MemoryStream(buff)) {
                using(CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                    List<byte> tmp = new List<byte>();
                    byte b = (byte)csDecrypt.ReadByte();
                    while((int)b != -1) {
                        tmp.Add(b);
                        b = (byte)csDecrypt.ReadByte();
                    }

                    byte[] link = tmp.ToArray();

                    Console.WriteLine(Encoding.UTF8.GetString(link));
                    byte[] res = ZLibCompressor.DeCompress(link);
                    Console.WriteLine(Encoding.ASCII.GetString(res));

                }
            }
            //link = MyAES.Aes.Decrypt(buff, hashRes, MyAES.Aes.Mode.CBC, iv, MyAES.Aes.Padding.PKCS7);
    
            string dec = DecryptStringFromBytes_Aes(buff, hashRes, iv);
            Console.WriteLine(dec);
            //File.WriteAllText(@"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\decompressResult.txt", System.Text.Encoding.ASCII.GetString(res));



            Console.ReadKey();
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key
, byte[] IV) {
            // Check arguments.
            if(cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if(Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if(IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using(Aes aesAlg = Aes.Create()) {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
, aesAlg.IV);

                // Create the streams used for decryption.
                using(MemoryStream msDecrypt = new MemoryStream(cipherText)) {
                    using(CryptoStream csDecrypt = new CryptoStream(msDecrypt
, decryptor, CryptoStreamMode.Read)) {
                        using(StreamReader srDecrypt = new StreamReader(
csDecrypt)) {

                            // Read the decrypted bytes from the decrypting 
                                                        // and place them in a string.
                                                        plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }


        static public byte[] SetHashKey(byte[] globalKey, int number, int generation) {
            byte[] salt = { (byte)0x73, (byte)0x41, (byte)0x6c, (byte)0x54 };
            byte[] extra = new byte[5];
            MD5 _md5 = new MD5CryptoServiceProvider();
            _md5.Initialize();
            extra[0] = (byte)number;
            extra[1] = (byte)(number >> 8);
            extra[2] = (byte)(number >> 16);
            extra[3] = (byte)generation;
            extra[4] = (byte)(generation >> 8);
            byte[] key = new byte[globalKey.Length + 9];
            Array.Copy(globalKey, 0, key, 0, globalKey.Length);
            Array.Copy(extra, 0, key, globalKey.Length, 5);
            Array.Copy(salt, 0, key, globalKey.Length + 5, 4);
            return key;
        }

        static public byte[] Decrypt(byte[] originalStream, byte[] key, int version) {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            md5.TransformFinalBlock(key, 0, key.Length);
            byte[] DecKey = md5.Hash;

            byte[] iv = new byte[16];
            byte[] buff = new byte[originalStream.Length - 16];
            Array.Copy(originalStream, 0, iv, 0, 16);
            Array.Copy(originalStream, 16, buff, 0, buff.Length);
            byte[] unzipStream;
            if(version == 1)
                unzipStream = MyAES.Aes.Decrypt(buff, DecKey, MyAES.Aes.Mode.CBC, iv, MyAES.Aes.Padding.PKCS7);
            else
                unzipStream = new byte[20];
            byte[] stream = ZLibCompressor.DeCompress(unzipStream);
            return stream;
        }
    }
}
