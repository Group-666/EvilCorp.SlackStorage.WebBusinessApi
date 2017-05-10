using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.CrossCutting.Testing;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class AccountManagerTests : TestsFor<AccountManager>
    {
        private readonly Account _validAccount = new Account { Id = Guid.NewGuid(), Nickname = "Nickname", Password = "Password", Username = "Username" };
        private static readonly Guid _validGuid = Guid.NewGuid();
        private readonly string _validGuidString = _validGuid.ToString();

        private ExceptionHandler _exceptionHandler;

        protected override void OverrideMocks()
        {
            // Arrange
            var mockedLogger = GetMockFor<ILogger>().Object;
            _exceptionHandler = new ExceptionHandler(mockedLogger);
            Inject<IExceptionHandler>(_exceptionHandler);
        }

        #region ClientDataManage Tests

        //TODO write tests

        #region Create Tests

        [TestMethod]
        public async Task Create_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Create(_validAccount);

            // Assert
            GetMockFor<IAccountRepository>().Verify(r => r.Create(It.IsAny<Account>()), Times.Once);
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_ValidatorPositive_ReturnsJson()
        {
            // Arrange
            GetMockFor<IAccountRepository>().Setup(r => r.Create(_validAccount)).Returns(() => Task.FromResult(_validAccount));

            // Act
            var result = await Instance.Create(_validAccount);

            // Assert
            Assert.AreEqual(result, _validAccount);
        }

        [TestMethod]
        public async Task Create_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Create(_validAccount);
            }
            catch
            {
                // Assert
                GetMockFor<IAccountRepository>().Verify(r => r.Create(_validAccount), Times.Never);
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion Create Tests

        #region GetAll Tests

        [TestMethod]
        public async Task GetAll_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.GetAll();

            // Assert
            GetMockFor<IAccountRepository>().Verify(r => r.GetAll(), Times.Once);
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
        }

        [TestMethod]
        public async Task GetAll_ReturnsAccount()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>
            {
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"},
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"}
            };

            GetMockFor<IAccountRepository>().Setup(r => r.GetAll()).Returns(() => Task.FromResult(accounts));

            // Act
            var result = await Instance.GetAll();

            // Assert
            Assert.AreEqual(result, accounts);
        }

        [TestMethod]
        public async Task GetAll_ValidatorNegative_RepositoryNeverCalled_LoggerCalledTwice()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.GetAll();
            }
            catch
            {
                // Assert
                GetMockFor<IAccountRepository>().Verify(r => r.GetAll(), Times.Never);
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion GetAll Tests

        #region Get Tests

        [TestMethod]
        public async Task Get_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Get(_validGuidString);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IAccountRepository>().Verify(r => r.Get(_validGuid), Times.Once);
        }

        [TestMethod]
        public async Task Get_ValidatorPositive_ReturnAccount()
        {
            // Arrange
            GetMockFor<IAccountRepository>().Setup(r => r.Get(_validGuid)).Returns(() => Task.FromResult(_validAccount));

            // Act
            var result = await Instance.Get(_validGuidString);

            // Assert
            Assert.AreEqual(result, _validAccount);
        }

        [TestMethod]
        public async Task Get_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Get(_validGuidString);
            }
            catch
            {
                // Assert
                GetMockFor<IAccountRepository>().Verify(r => r.Get(_validGuid), Times.Never);
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion Get Tests

        #region Update Tests

        [TestMethod]
        public async Task Update_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Update(_validAccount);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IAccountRepository>().Verify(r => r.Update(_validAccount), Times.Once);
        }

        [TestMethod]
        public async Task Update_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Update(_validAccount);
            }
            catch
            {
                // Assert
                GetMockFor<IAccountRepository>().Verify(r => r.Update(_validAccount), Times.Never);
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion Update Tests

        #region Delete Tests

        [TestMethod]
        public async Task Delete_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Delete(_validGuidString);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IAccountRepository>().Verify(r => r.Delete(_validGuid), Times.Once);
        }

        [TestMethod]
        public async Task Delete_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Delete(_validGuidString);
            }
            catch
            {
                // Assert
                GetMockFor<IAccountRepository>().Verify(r => r.Delete(_validGuid), Times.Never);
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion Delete Tests

        private void SetupValidatorToThrowExpection()
        {
            GetMockFor<IValidator>().Setup(v => v.IsValidGuid(It.IsAny<string>())).Throws(new ArgumentException("invalid user id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreId(It.IsAny<string>())).Throws(new ArgumentException("invalid datastore id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidElementId(It.IsAny<string>())).Throws(new ArgumentException("invalid element id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreName(It.IsAny<JObject>())).Throws(new ArgumentException("invalid datastore name"));
        }

        #endregion ClientDataManage Tests
    }
}