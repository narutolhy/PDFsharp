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
using MyAES;

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
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            _md5.TransformFinalBlock(testHash, 0, testHash.Length);

            //_md5.TransformFinalBlock(decrpt, 0, decrpt.Length);
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            byte[] hashRes = _md5.Hash;
            byte[] decrp = File.ReadAllBytes(filePathDeco);

            byte[] iv = new byte[16];
            byte[] buff = new byte[decrp.Length - 16];
            Array.Copy(decrp, 0, iv, 0, 16);
            Array.Copy(decrp, 16, buff, 0, buff.Length);

            byte[] link = MyAES.Aes.Decrypt(buff, hashRes, MyAES.Aes.Mode.CBC, iv, MyAES.Aes.Padding.PKCS7);
            byte[] res = ZLibCompressor.DeCompress(link);
            Console.WriteLine(Encoding.ASCII.GetString(res));
            //File.WriteAllText(@"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\decompressResult.txt", System.Text.Encoding.ASCII.GetString(res));



            Console.ReadKey();
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
    }
}
