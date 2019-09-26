using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]
[assembly: InternalsVisibleTo("ZbW.Testing.Dms.IntegrationTests")]

namespace ZbW.Testing.Dms.Client.Services
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    using ZbW.Testing.Dms.Client.Model;

    class DataToXml
    {
        public void MetadatenSchreiben(MetadataItem metadataItem, Guid guid, string outputFolderPath)
        {
            //var inputFilePath = metadataItem.FilePfad;
            var filePathMethadata = Path.Combine(outputFolderPath, $"{guid}_Metadata.xml");
            var filePathDocument = Path.Combine(outputFolderPath, $"{guid}_{Path.GetFileName(metadataItem.FilePfad)}");
            var xmlserializer = new XmlSerializer(typeof(MetadataItem));

            FileStream datei = File.Create(filePathMethadata);
            metadataItem.FilePfad = filePathDocument;

            xmlserializer.Serialize(datei, metadataItem);
            datei.Close();
        }

        public MetadataItem LesenMetadten(string path)
        {
            var serializer = new XmlSerializer(typeof(MetadataItem));
            var reader = new StreamReader(path);
            var metadataItem = (MetadataItem)serializer.Deserialize(reader);
            reader.Close();
            return metadataItem;
        }

        public void XmlSpeichern(string serializeXml, string path)
        {
            var xdoc = new XmlDocument();
            xdoc.LoadXml(serializeXml);
            xdoc.Save(path);
        }

        //    public string GetFileExtension(string fileName)
        //    {
        //        var splittedByPoint = fileName.Split('.');
        //        return splittedByPoint[splittedByPoint.Length - 1];
        //    }
    }
}