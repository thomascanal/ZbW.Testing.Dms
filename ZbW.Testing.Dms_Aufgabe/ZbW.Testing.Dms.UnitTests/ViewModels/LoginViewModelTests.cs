namespace ZbW.Testing.Dms.UnitTests
{
    using NUnit.Framework;

    using ZbW.Testing.Dms.Client.ViewModels;

    [TestFixture]
    class LoginViewModelTests
    {
        private const string USERNAME = "Thomas";
        private readonly string _invalidUsername = string.Empty;
        [Test]
        public void Login_WithUsername_ReturnsTrue()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null) {Benutzername = USERNAME};

            // Act
            var loginPossible = loginViewModel.CmdLogin.CanExecute();

            // Assert
            Assert.That(loginPossible, Is.True);
        }
        [Test]
        public void Login_NoUsername_IsFalse()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null) { Benutzername = _invalidUsername };

            // Act
            var ableToLogin = loginViewModel.CmdLogin.CanExecute();

            // Assert
            Assert.That(ableToLogin, Is.False);
        }
        [Test]
        public void Login_NoUsername_ReturnsTrue()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null) { Benutzername = _invalidUsername };

            // Act
            var ableToLogin = loginViewModel.NoUsername();

            // Assert
            Assert.That(ableToLogin, Is.True);
        }
        [Test]
        public void Login_CmdCancel_IsEnabled()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null) { Benutzername = USERNAME};

            // Act
            var ableToLogin = loginViewModel.CmdAbbrechen.CanExecute();

            // Assert
            Assert.That(ableToLogin, Is.True);
        }
    }
}