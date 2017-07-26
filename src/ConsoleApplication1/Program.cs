using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            string filePath = @"C:\Users\t-holu\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\data\test4.pdf";
            PdfDocument document = PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly);

        }
    }
}
