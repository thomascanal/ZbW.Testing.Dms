namespace ZbW.Testing.Dms.UnitTests
{
    using NUnit.Framework;

    using ZbW.Testing.Dms.Client.ViewModels;

    [TestFixture]
    class MainViewModelTests
    {
        private const string Username = "Thomas";

        [Test]
        public void Main_getLoggedInUser_ValidUser()
        {
            // Arrange
            var mainViewModel = new MainViewModel(Username);

            // Act
            var username = mainViewModel.Benutzer;

            // Assert
            Assert.That(username, Is.EqualTo(Username));
        }
    }
}