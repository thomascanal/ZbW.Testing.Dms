using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.UnitTests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using ZbW.Testing.Dms.Client.Model;

    [TestFixture]
    class MetadataItemTests
    {
        private const string TESTING_TEXT = "Test Something";
        private readonly DateTime _testDateTime = DateTime.Now;
        [Test]
        public void MetadataItem_Bezeichnung_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(TESTING_TEXT, _testDateTime) { Bezeichnung = TESTING_TEXT };

            // Act
            var name = metadataItem.Bezeichnung;
            var valutaDate = metadataItem.ValutaDatum;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(name, Is.EqualTo(TESTING_TEXT));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(keyword, Is.EqualTo(null));
        }
        [Test]
        public void MetadataItem_FullConstructor_GetTestingTextsAndDates()
        {
            // Arrange and Act
            var metadataItem = new MetadataItem(TESTING_TEXT, TESTING_TEXT, _testDateTime, TESTING_TEXT, TESTING_TEXT, _testDateTime, TESTING_TEXT, false);

            // Assert
            Assert.That(metadataItem.FilePfad, Is.EqualTo(TESTING_TEXT));
            Assert.That(metadataItem.Bezeichnung, Is.EqualTo(TESTING_TEXT));
            Assert.That(metadataItem.ValutaDatum, Is.EqualTo(_testDateTime));
            Assert.That(metadataItem.Typ, Is.EqualTo(TESTING_TEXT));
            Assert.That(metadataItem.Stichwoerter, Is.EqualTo(TESTING_TEXT));
            Assert.That(metadataItem.Erfassungsdatum, Is.EqualTo(_testDateTime));
            Assert.That(metadataItem.Benutzer, Is.EqualTo(TESTING_TEXT));
            Assert.That(metadataItem.DateiAnschliessendLöschen, Is.False);
        }
    }
}
