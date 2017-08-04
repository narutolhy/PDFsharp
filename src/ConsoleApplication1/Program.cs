using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//using PdfSharp.Pdf;
//using PdfSharp.Pdf.Content;
//using PdfSharp.Pdf.Content.Objects;
//using PdfSharp.Pdf.IO;
using ZLibNet;
//using PdfSharp.Pdf.Advanced;
//using PdfSharp.Pdf.Security;
//using PdfSharp.Pdf.Internal;
using pdfRead.pdfObject;
using Microsoft.Ocr;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
//using PdfExtractor;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            //string filePathKey = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testKey.txt";
            string filePath = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\test4.pdf";
            //string filePathDeco = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testDecode.txt";

            byte[] fileIn = FileToByteArray(filePath);
            PdfDocument doc = new PdfDocument(fileIn);
            //var test2 = doc.ExtractPageImages(2);
            var test = doc.ExtractImages();
            List<PdfTextLine> textLines;
            for(int i = 0; i < doc.pages.Count; i++)
                textLines = doc.PageTextLine(0);
            var t = doc.lineFontSize;
            foreach(var i in t) {
                Console.WriteLine(i.Key + "    hello world");
                foreach(var j in i.Value) {
                    Console.WriteLine(j.text);
                }
            }
        
            //StringBuilder sb = new StringBuilder();
            //foreach(var line in textLines) {
            //    sb.Append(line.text);
            //}
            //File.WriteAllText(@"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testRead.pdf", sb.ToString());
            //Console.WriteLine(sb.ToString());

            //PdfDocument document = PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly);
            //var page = document.Pages;
            //var resources = page[0].Elements.GetDictionary("/Resources");
            //var xObjects = resources.Elements.GetDictionary("/XObject");
            //if(xObjects != null) {
            //    var items = xObjects.Elements.Values;
            //    foreach(PdfItem item in items) {
            //        var reference = item as PdfReference;
            //        if(reference != null) {
            //            var xObject = reference.Value as PdfDictionary;
            //            if(xObject.IsImage()) {

            //                var lines = ExtractLinesFromImage(xObject.ToImage());
            //                var im = xObject.ToImage();
            //                foreach(var line in lines) {

            //                    Console.WriteLine(string.Join(" ", line.Words.Select(r => r.Text)));
            //                }
            //            }
            //        }
            //    }
            //}

            //PdfReference[] irefs = document._irefTable.AllReferences;
            //var image = irefs[5].Value as PdfDictionary;
            //var imagebytes = image.Stream.Value;
            ////Console.WriteLine(image);
            //var test = page[0].Contents.CreateSingleContent();
            ////PdfContent content = page.Contents.CreateSingleContent();
            //byte[] bytes = test.Stream.Value;
            //Console.WriteLine(Encoding.ASCII.GetString(bytes));
            //var test2 = test.Stream;
            ////Console.WriteLine(test2.ToString());
            ////Console.WriteLine(test.ToString());
            //byte[] key = File.ReadAllBytes(filePathKey);
            ////byte[] res = ZLibCompressor.DeCompress(testzip);
            //byte[] decrpt = new byte[25];
            //Array.Copy(key, 0, decrpt, 0, 16);
            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes("19100sAlT");
            //Array.Copy(byteArray, 0, decrpt, 16, 9);
            ////PdfStandardSecurityHandler securityHandler = document.SecurityHandler;
            ////var test = securityHandler._encryptionKey;
            //MD5 _md5 = new MD5CryptoServiceProvider();
            //byte[] testHash = SetHashKey(key, 191, 0);


            ////_md5.Initialize();
            //////Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            ////_md5.TransformFinalBlock(testHash, 0, testHash.Length);

            //////_md5.TransformFinalBlock(decrpt, 0, decrpt.Length);
            //////Console.WriteLine(System.Text.Encoding.ASCII.GetString(decrpt));
            ////byte[] hashRes = _md5.Hash;
            //byte[] decrp = File.ReadAllBytes(filePathDeco);

            //byte[] iv = new byte[16];
            //byte[] buff = new byte[decrp.Length - 16];
            //Array.Copy(decrp, 0, iv, 0, 16);
            //Array.Copy(decrp, 16, buff, 0, buff.Length);
            //Aes myAes = Aes.Create();
            //myAes.Key = testHash;
            //myAes.IV = iv;
            //byte[] stream = new byte[0];
            //int streamSize = 0;
            //ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);
            //using(MemoryStream msDecrypt = new MemoryStream(buff)) {
            //    using(CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
            //        using (var reader = new BinaryReader(csDecrypt)) {
            //            byte[] tmp = reader.ReadBytes(256);
            //            while(tmp.Length > 0) {
            //                streamSize += tmp.Length;
            //                byte[] streamBuff = new byte[streamSize];
            //                if(stream.Length > 0)
            //                    Array.Copy(stream, 0, streamBuff, 0, stream.Length);
            //                Array.Copy(tmp, 0, streamBuff, stream.Length, tmp.Length);
            //                stream = new byte[streamSize];
            //                Array.Copy(streamBuff, 0, stream, 0, streamSize);
            //                tmp = reader.ReadBytes(256);
            //            }

            //        }

            //    }
            //}
            ////link = MyAES.Aes.Decrypt(buff, hashRes, MyAES.Aes.Mode.CBC, iv, MyAES.Aes.Padding.PKCS7);
            //stream = ZLibCompressor.DeCompress(stream);
            //Console.WriteLine(Encoding.ASCII.GetString(stream));
            //byte[] streamtest = Decrypt(decrp, testHash, 0);
            //stream = ZLibCompressor.DeCompress(streamtest);
            //Console.WriteLine(Encoding.ASCII.GetString(stream));
            //Console.WriteLine(stream);
            ////File.WriteAllText(@"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\decompressResult.txt", System.Text.Encoding.ASCII.GetString(res));



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

            _md5.TransformFinalBlock(key, 0, key.Length);

            byte[] objKey = _md5.Hash;
            return objKey;
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
            Aes myAes = Aes.Create();
            myAes.Key = key;
            myAes.IV = iv;

            byte[] stream = new byte[0];
            int streamSize = 0;
            ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);
            using (MemoryStream msDecrypt = new MemoryStream(buff)) {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                    using (var reader = new BinaryReader(csDecrypt)) {
                        byte[] tmp = reader.ReadBytes(256);
                        while (tmp.Length > 0) {
                            streamSize += tmp.Length;
                            byte[] streamBuff = new byte[streamSize];
                            if (stream.Length > 0)
                                Array.Copy(stream, 0, streamBuff, 0, stream.Length);
                            Array.Copy(tmp, 0, streamBuff, stream.Length, tmp.Length);
                            stream = new byte[streamSize];
                            Array.Copy(streamBuff, 0, stream, 0, streamSize);
                            tmp = reader.ReadBytes(256);
                        }

                    }

                }
            }
            //if (version == 1)
            //    unzipStream = MyAES.Aes.Decrypt(buff, DecKey, MyAES.Aes.Mode.CBC, iv, MyAES.Aes.Padding.PKCS7);
            //else
            //    unzipStream = new byte[20];
       
            return stream;
        }
        public static byte[] FileToByteArray(string fileName) {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);

            return buff;
        }

        public static List<Line> ExtractLinesFromImage(Image image) {
            List<Line> result = new List<Line>();

            string resourceRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            resourceRoot = resourceRoot.Substring(6);

            using(Ocr ocrEngine = new Ocr(resourceRoot)) {
                try {
                    Bitmap bitmap = new Bitmap(image);
                    OcrParams ocrParams = new OcrParams {
                        CheckOrientation = true,
                        Language = Language.English
                    };

                    OcrResults ocrResults = ocrEngine.Recognize(bitmap, ocrParams);

                    using(var graphics = Graphics.FromImage(bitmap)) {
                        foreach(var region in ocrResults.Regions) {
                            foreach(var line in region.Lines) {
                                result.Add(line);
                            }
                        }
                    }
                } catch(Exception ex) {
                    Trace.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
