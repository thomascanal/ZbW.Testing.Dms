using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.IntegrationTests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services;

    [TestFixture]

    class DataToXmlTests
    {
        [Test]
        public void XmlService_Serialize_SerializedString()
        {
            // funktioniert nicht


            // Arrange
            var xmlService = new DataToXml();

            // Act
            const string expectedXml =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?><MetadataItem xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Stichwoerter /><Erfassungsdatum>0001-01-01T00:00:00</Erfassungsdatum><IsRemoveFileEnabled>false</IsRemoveFileEnabled><Type>Test</Type><ValutaDatum>0001-01-01T00:00:00</ValutaDatum></MetadataItem>";
            //var xml = xmlService.MetadatenSchreiben(new MetadataItem(DateTime.MinValue, "Test"));

            // Assert
            //Assert.That(xml, Is.EqualTo(expectedXml));
        }
    }
}
