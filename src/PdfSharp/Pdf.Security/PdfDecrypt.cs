using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace PdfSharp.Pdf.Security {
    class PdfDecrypt {
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
    }
}
