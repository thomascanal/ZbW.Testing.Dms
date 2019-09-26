using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.UnitTests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using ZbW.Testing.Dms.Client.ViewModels;

    [TestFixture]
    class DocumentDetailViewModelTests
    {
        private const string Username = "Thomas";
        private readonly DateTime _testDateTime = DateTime.Now;
        [Test]
        public void DocumentDetail_IsAbleToSave_AbleToSave()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var ableToSave = documentDetailViewModel.CmdSpeichern.CanExecute();

            // Assert
            Assert.That(ableToSave, Is.True);
        }
        [Test]
        public void DocumentDetail_IsAbleToSearch_AbleToSearch()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var ableToSearch = documentDetailViewModel.CmdDurchsuchen.CanExecute();

            // Assert
            Assert.That(ableToSearch, Is.True);
        }
        [Test]
        public void DocumentDetail_IsValidUsername_UsernameIsValid()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var username = documentDetailViewModel.Benutzer;

            // Assert
            Assert.That(username, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_IsRemoveFileEnabled_RemoveFileIsEnabled()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            documentDetailViewModel.IsRemoveFileEnabled = true;
            var ableToRemoveFile = documentDetailViewModel.IsRemoveFileEnabled;

            // Assert
            Assert.That(ableToRemoveFile, Is.True);
        }
        [Test]
        public void DocumentDetail_IsTypItemSelected_TypeItemUsername()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);
            documentDetailViewModel.SelectedTypItem = Username;

            // Act
            var typeItem = documentDetailViewModel.SelectedTypItem;

            // Assert
            Assert.That(typeItem, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_GetName_IsUsername()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null) { Bezeichnung = Username };

            // Act
            var name = documentDetailViewModel.Bezeichnung;

            // Arrange
            Assert.That(name, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_Erfassungsdatum_IsDateMin()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null) { Erfassungsdatum = DateTime.MinValue };

            // Act
            var create = documentDetailViewModel.Erfassungsdatum;

            // Arrange
            Assert.That(create, Is.EqualTo(DateTime.MinValue));
        }
        [Test]
        public void DocumentDetail_GetKeyword_IsUsername()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null) { Stichwoerter = Username };

            // Act
            var keyword = documentDetailViewModel.Stichwoerter;

            // Assert
            Assert.That(keyword, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_GetValutaDateTime_IsEqualToNow()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null) { ValutaDatum = _testDateTime };

            // Act
            var valutaDate = documentDetailViewModel.ValutaDatum;

            // Assert
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
        }
    }

}
