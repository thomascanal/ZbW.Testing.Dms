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
        public void MetadatenSchreiben(MetadataItem metadataItem)
        {
            //var inputFilePath = metadataItem.FilePfad;
            var outputFilePath = @"c:\temp\GUID_Metadata.xml";
            var xmlserializer = new XmlSerializer(typeof(MetadataItem));

            FileStream datei = File.Create(outputFilePath);

            xmlserializer.Serialize(datei, metadataItem);
            datei.Close();
        }

        //public Metadaten LesenMetadten(string pfad)
        //{

        //}

        //public void XmlSpeichern()
        //{

        //}
        //public void AlsXmlSpeichern (string seriali)
    }
}
