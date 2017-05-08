using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.CrossCutting.Testing;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class AccountManagerTests : TestsFor<AccountManager>
    {
        private readonly string _stringValue = "SomeString";
        private readonly Account _validAccount = new Account { Id = Guid.NewGuid(), Nickname = "Nickname", Password = "Password", Username = "Username" };

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
            var expectedValue = JObject.FromObject(new Account { Id = Guid.NewGuid(), Nickname = "nickname" });
            GetMockFor<IConverter>().Setup(r => r.ObjectToJson(It.IsAny<Account>())).Returns(() => expectedValue);

            // Act
            var result = await Instance.Create(_validAccount);

            // Assert
            Assert.AreEqual(result, expectedValue);
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
        public async Task GetAll_ValidatorPositive_ReturnsJson()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>
            {
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"},
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"}
            };

            var expectedValue = new JObject { ["accounts"] = JToken.FromObject(accounts) };

            //var jsonlist = JsonConvert.SerializeObject(new
            //{
            //    operations = accounts
            //});

            //var expectedValue = JObject.FromObject(accounts);
            GetMockFor<IAccountRepository>().Setup(r => r.GetAll()).Returns(() => Task.FromResult(accounts));
            GetMockFor<IConverter>().Setup(r => r.ObjectsToJson(accounts, It.IsAny<string>())).Returns(() => expectedValue);
            // Act
            var result = await Instance.GetAll();

            // Assert
            Assert.AreEqual(result, expectedValue);
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