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
    class SearchViewModelTests
    {
        [Test]
        public void SearchViewModel_GetSet_Suchwort()
        {
            // Arrange
            var searchViewModel = new SearchViewModel { Suchbegriff = "asdf" };

            // Act
            var suchbegriff = searchViewModel.Suchbegriff;

            // Arrange
            Assert.That(suchbegriff, Is.EqualTo("asdf"));
        }
        [Test]
        public void SearchViewModel_Reset_ResetsAll()
        {
            // Arrange
            var searchViewMode = new SearchViewModel();

            // Act
            searchViewMode.CmdReset.Execute();

            // Asert
            Assert.That(searchViewMode.Suchbegriff, Is.EqualTo(""));
            Assert.That(searchViewMode.SelectedTypItem, Is.Null);
        }
    }
}
