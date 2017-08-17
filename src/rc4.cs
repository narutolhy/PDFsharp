                                    objectStreams.Add(objectNumber, null);
                                    PdfObjectID objectID = new PdfObjectID((int)item.Field2);
                                    PdfDictionary pdfObject = (PdfDictionary)parser.ReadObject(null, objectID, false, false);
                                    PdfStandardSecurityHandler securityHandler = document.SecurityHandler;
                                    securityHandler.EncryptObject(pdfObject);
                                    parser.ReadIRefsFromCompressedObject(objectID);