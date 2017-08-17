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
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
using PdfSharp.Pdf.Internal;
using pdfRead.pdfObject;
using Microsoft.Ocr;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using PdfExtractor;
using PdfiumViewer;
using Spire.Pdf;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {

            //Console.WriteLine("\u0033");
            //Console.WriteLine("\u0055");
            //Console.WriteLine("\u004C");
            //Console.WriteLine("\u0051");
            //Console.WriteLine("\u0046");
            //Console.WriteLine("\u004C");
            //Console.WriteLine("\u0053");

            //string filePathKey = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testKey.txt";
            string filePath = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\test4.pdf";
            //string filePathDeco = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testDecode.txt";
            string fileFold = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\";

            string fileTime = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\comTime.txt";

            string fileocr = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\ocr.txt";

            string filesharp = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\sharp.txt";


            byte[] fileIn = FileToByteArray(fileFold + 3 + ".pdf");

            AuditLetterExtractor doc = new AuditLetterExtractor();
            ExtractedAuditLetterText extractedAuditLetterText = new ExtractedAuditLetterText();



            for(int i = 130; i < 131; i++) {
                byte[] filebytes = FileToByteArray(fileFold + 50 + ".pdf");
                DateTime dt1 = System.DateTime.Now;
                //var test1 = AuditLetterExtractor.ExtractTextFromRawPdf(filebytes, out extractedAuditLetterText);
                DateTime dt2 = System.DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                StringBuilder sb = new StringBuilder();
                //Console.WriteLine(test1);
                sb.Append(i + "    Ocr:     " + ts.TotalMilliseconds.ToString() + " ");
                //File.WriteAllText(fileocr, test1);
                dt1 = System.DateTime.Now;
                try {
                    ExtractTextFromRawPdf(filebytes, out extractedAuditLetterText, ts, dt1, i);
                } catch(Exception e) {
                 
                }
                var test = ExtractTextFromRawPdf(filebytes, out extractedAuditLetterText, ts, dt1, i);
                //Console.WriteLine(test);
                dt2 = System.DateTime.Now;
                ts = dt2.Subtract(dt1);
                File.WriteAllText(filesharp, test);
                sb.Append("Reader:     " + ts.TotalMilliseconds.ToString() + "\n");
                Console.WriteLine("finish");
                //File.AppendAllText(fileTime, sb.ToString());

            }

            //PdfExtractor.PdfInfoExtractorPdfSharp document = new PdfInfoExtractorPdfSharp();
            //var test4 = document.ExtractText(fileIn);

            //pdfRead.pdfObject.PdfDocument doc = new pdfRead.pdfObject.PdfDocument(fileIn);
            ////var test = doc.pages;
            ////var test2 = test[2];
            ////var test3 = test2.Contents.CreateSingleContent();
            ////Console.WriteLine(test3.Stream);
            //var test2 = doc.ExtractImages();
            //Console.WriteLine(test2);
            //var test = doc.ExtractImages();
            //List<PdfTextLine> textLines;
            //for(int i = 0; i < doc.pages.Count; i++) 
            //    textLines = doc.PageTextLine(i);
            //var t = doc.lineFontSize;
            //foreach(var i in t) {
            //    Console.WriteLine(i.Key + "hello world");
            //    foreach(var j in i.Value) {
            //        File.AppendAllText(@"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\testwrite.txt", j.text);
            //        Console.WriteLine(j.text + "\n");
            //    }
            //}

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



        public static string ExtractTextFromRawPdf(byte[] pdfFile, out ExtractedAuditLetterText extractedAuditLetterText, TimeSpan ts, DateTime dt1, int num) {
            //const string testReadPath = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\testread.txt";
            //const string testimageReadPath = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\testimageread.txt";



            List<MergedTraversedLine> txtFormattedLines = new List<MergedTraversedLine>();
            List<MergedTraversedLine> imageFormattedLines = new List<MergedTraversedLine>();
            List<int> txtFormattedNum = new List<int>();
            List<int> imageFormattedNum = new List<int>();
            //try {
            //    pdfRead.pdfObject.PdfDocument document = new pdfRead.pdfObject.PdfDocument(pdfFile);
            //} catch(Exception e) {
            //    throw e;
            //}

            //Merge image reader


            Spire.Pdf.PdfDocument imgDoc = new Spire.Pdf.PdfDocument(pdfFile);

            pdfRead.pdfObject.PdfDocument doc = new pdfRead.pdfObject.PdfDocument(pdfFile);
            List<PdfTextLine> textLines;
            doc.PageTextLine(doc.pages.Count - 1);
            for(int i = 0; i < doc.pages.Count; i++) {
                textLines = doc.PageTextLine(i);
                if(textLines.Count > 2) {
                    txtFormattedNum.Add(i);
                } else {
                    imageFormattedNum.Add(i);
                }
            }


            ExtractedAuditLetterText extractedTexts = new ExtractedAuditLetterText();
            ExtractedAuditLetterText extractedImageTexts = new ExtractedAuditLetterText();


            /// <summary>
            /// Get text from txt-formatted pdf
            /// </summary>
            if(txtFormattedNum.Count != 0) {
                //Get lines from pdf and they are grouped by their fontsizes.
                Dictionary<double, List<PdfTextLine>> linesKeyValue = doc.lineFontSize;
                int index = 0;
                foreach(var key in linesKeyValue) {
                    foreach(var value in key.Value) {
                        var bdcLines = new MergedTraversedLine();
                        bdcLines.Index = index;
                        bdcLines.Text = value.text;
                        index++;
                        txtFormattedLines.Add(bdcLines);
                    }
                }
                ExtractedAuditLetterText extractedTxtedTexts = PdfExtractor.Utilities.ConvertToExtractedAuditLetterTexts(txtFormattedLines);
                var littleImages = doc.ExtractImages();
                foreach(var img in littleImages) {
                    var lines = Utilities.ExtractLinesFromImage(img);
                    foreach(var line in lines) {
                        string other = string.Join(" ", line.Words.Select(r => r.Text));
                        if(other == "auren")
                            other = "Auren";
                        extractedTexts.Others.Add(other);
                        //Console.WriteLine(other);
                    }
                }

                //foreach(int i in txtFormattedNum) {
                //    var littleImages = imgDoc.Pages[i].ExtractImages();
                //    foreach(var img in littleImages) {
                //        var lines = Utilities.ExtractLinesFromImage(img);
                //        foreach(var line in lines) {
                //            extractedTexts.Others.Add(string.Join(" ", line.Words.Select(r => r.Text)));
                //            Console.WriteLine(string.Join(" ", line.Words.Select(r => r.Text)));
                //        }
                //    }

                //}
                

                //string serialzedAuditLetterTxtedText = extractedTxtedTexts.SerializeExtractedAuditLetterText();
                //extractedAuditLetterText = extractedTxtedTexts;
                //return serialzedAuditLetterTxtedText;
            }


            /// <summary>
            /// Get text from txt-image-formatted pdf
            /// </summary>
            if(imageFormattedNum.Count != 0) {

                int titlePageStartIndexNum = 0;
                int titlePageEndIndexNum = -1;

                List<Image> imagePdf = new List<Image>();
                PdfiumViewer.PdfDocument document = PdfiumViewer.PdfDocument.Load(new MemoryStream(pdfFile));
                foreach(int i in imageFormattedNum) {
                    Image image = document.Render(i, Consts.DpiX, Consts.DpiY, PdfRenderFlags.CorrectFromDpi);
                    imagePdf.Add(image);
                }

                List<List<Line>> linesOfImagePdf = new List<List<Line>>();
                foreach(var img in imagePdf) {
                    linesOfImagePdf.Add(Utilities.ExtractLinesFromImage(img));
                }

                extractedTexts.Others.AddRange(Utilities.GetRedundantLines(imagePdf, linesOfImagePdf));

                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < imagePdf.Count; i++) {
                    //Add small region text to ExtractedAuditLetterText.others
                    extractedTexts.Others.AddRange(Utilities.RemoveSmallRegion(imagePdf[i]));

                    //Get raw context in main body
                    List<TraversedLine> rawImageTexts = PdfExtractor.Utilities.GetContents(imagePdf[i]);

                    foreach(var line in rawImageTexts) {
                        if(line.Text.IndexOf("sha-", StringComparison.OrdinalIgnoreCase) >= 0 || (line.Text.IndexOf("thumb", StringComparison.OrdinalIgnoreCase) >= 0)) {
                            line.Text = line.Text.Replace("O", "0").Replace("o", "0").Replace("i", "1").Replace("I", "1").Replace("l", "1");
                        }
                    }

                    //Merge raw context by paragraph
                    List<MergedTraversedLine> mergedImageTexts = PdfExtractor.Utilities.MergeTraversedLines(rawImageTexts);

                    titlePageEndIndexNum += mergedImageTexts.Count;
                    List<MergedTraversedLine> titleLines = mergedImageTexts.Where(x => x.IsTitle == true).ToList<MergedTraversedLine>();

                    //If this is a title page, add title page start index and end index to ExtractedAuditLetterText.TitlePageRanges
                    //If this is a title page, add the title index to ExtractedAuditLetterText.TitleRanges
                    if(titleLines.Count > 0) {
                        extractedImageTexts.TitlePageRanges.Add(new KeyValuePair<int, int>(titlePageStartIndexNum, titlePageEndIndexNum));
                        foreach(MergedTraversedLine title in titleLines) {
                            extractedImageTexts.TitleRanges.Add(new KeyValuePair<int, int>(title.Index + titlePageStartIndexNum, title.Index + titlePageStartIndexNum));
                        }
                    }
                    titlePageStartIndexNum += mergedImageTexts.Count;

                    //Add titles, contents 
                    ExtractedAuditLetterText tempText = PdfExtractor.Utilities.ConvertToExtractedAuditLetterTexts(mergedImageTexts);

                    extractedImageTexts.Titles.AddRange(tempText.Titles);
                    extractedImageTexts.Contents.AddRange(tempText.Contents);
                }
            }

            if(imageFormattedNum.Count == 0) {
                ExtractedAuditLetterText tempText = PdfExtractor.Utilities.ConvertToExtractedAuditLetterTexts(txtFormattedLines);
                extractedTexts.Titles.AddRange(tempText.Titles);
                extractedTexts.Contents.AddRange(tempText.Contents);
                StringBuilder sb = new StringBuilder();
                sb.Append(num + "Ocr:     " + ts.TotalMilliseconds.ToString() + "  ");

                string serialzedAuditLetterText2 = extractedTexts.SerializeExtractedAuditLetterText();
                extractedAuditLetterText = extractedTexts;
                DateTime dt2 = System.DateTime.Now;
                ts = dt2.Subtract(dt1);

                sb.Append("   Reader:     " + ts.TotalMilliseconds.ToString() + "\n");
                string fileTime = @"C:\Users\t-holu\Documents\AuditLetter\JixiProjectData\comTextTime.txt";
                File.AppendAllText(fileTime, sb.ToString());
                return serialzedAuditLetterText2;

            } else if(txtFormattedNum.Count == 0) {
                extractedTexts.Titles.AddRange(extractedImageTexts.Titles);
                extractedTexts.Contents.AddRange(extractedImageTexts.Contents);
                extractedTexts.TitleRanges.AddRange(extractedImageTexts.TitleRanges);
            } else {
                if(txtFormattedNum[0] < imageFormattedNum[0]) {
                    ExtractedAuditLetterText tempText = PdfExtractor.Utilities.ConvertToExtractedAuditLetterTexts(txtFormattedLines);
                    extractedTexts.Titles.AddRange(tempText.Titles);
                    extractedTexts.Contents.AddRange(tempText.Contents);
                    foreach(var line in extractedImageTexts.Titles) {
                        extractedTexts.Titles.Add(new KeyValuePair<int, string>(line.Key, line.Value));
                    }
                    foreach(var line in extractedImageTexts.Contents) {
                        extractedTexts.Contents.Add(new KeyValuePair<int, string>(line.Key, line.Value));
                    }
                    foreach(var line in extractedImageTexts.TitleRanges) {
                        extractedTexts.TitleRanges.Add(new KeyValuePair<int, int>(line.Key, line.Value));
                    }
                } else {
                    foreach(var line in extractedImageTexts.Titles) {
                        extractedTexts.Titles.Add(new KeyValuePair<int, string>(line.Key, line.Value));
                    }
                    foreach(var line in extractedImageTexts.Contents) {
                        extractedTexts.Contents.Add(new KeyValuePair<int, string>(line.Key, line.Value));
                    }
                    foreach(var line in extractedImageTexts.TitleRanges) {
                        extractedTexts.TitleRanges.Add(new KeyValuePair<int, int>(line.Key, line.Value));
                    }
                    ExtractedAuditLetterText tempText = PdfExtractor.Utilities.ConvertToExtractedAuditLetterTexts(txtFormattedLines);
                    extractedTexts.Titles.AddRange(tempText.Titles);
                    extractedTexts.Contents.AddRange(tempText.Contents);
                }
            }

            string serialzedAuditLetterText = extractedTexts.SerializeExtractedAuditLetterText();
            extractedAuditLetterText = extractedTexts;

            return serialzedAuditLetterText;
        }
    }
}
