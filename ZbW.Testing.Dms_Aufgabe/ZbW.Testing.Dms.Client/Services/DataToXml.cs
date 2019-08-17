using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    using ZbW.Testing.Dms.Client.Model;

    class DataToXml
    {
        public string MetadatenSchreiben(MetadataItem metadataItem)
        {
            var xmlserializer = new XmlSerializer(typeof(MetadataItem)); //Objekt MetadataIteam schreiben
            //var stringWriter = new StringWriter();
            //var datei = XmlWriter.Create(stringWriter);

            var filePfad = metadataItem.FilePfad;
            FileStream datei = File.Create(filePfad);
            //var xmlSchreiben = stringWriter.ToString();

            xmlserializer.Serialize(datei, metadataItem);
            datei.Close();

            return filePfad;
        }

        //public Metadaten LesenMetadten(string pfad)
        //{

        //}

        //public void XmlSpeichern()
        //{

        //}
        //public void AlsXmlSpeichern (string seriali)



        /****************Beispiel aus MSDN!*************************/
        //public static void WriteXML()
        //{
        //    Book metadataItem = new Book();
        //    metadataItem.title = "Serialization Overview";
        //    XmlSerializer xmlserializer = new XmlSerializer(typeof(Book));

        //    var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        //    FileStream datei = File.Create(path);

        //    xmlserializer.Serialize(datei, metadataItem);
        //    datei.Close();
        //}
    }
}
