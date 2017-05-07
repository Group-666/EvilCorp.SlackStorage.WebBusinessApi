using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private readonly JObject _validJson = JObject.Parse(@"{name:'values', password:'values'}");

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
        public async Task Create_JsonIsValid_RepositoryIsCalled()
        {
            // Act
            await Instance.Create(_validJson);

            // Assert
            GetMockFor<IAccountRepository>().Verify(r => r.Create(It.IsAny<Account>()), Times.Once);
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_JsonIsNull_RepositoryIsCalled()
        {
            // Act
            await Instance.Create(_validJson);

            // Assert
            GetMockFor<IAccountRepository>().Verify(r => r.Create(It.IsAny<Account>()), Times.Once);
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
        }

        #endregion Create Tests

        private void SetupValidatorToThrowExpection()
        {
            GetMockFor<IValidator>().Setup(v => v.IsValidGuid(It.IsAny<string>())).Throws(new ArgumentException("invalid user id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreId(It.IsAny<string>())).Throws(new ArgumentException("invalid datastore id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidElementId(It.IsAny<string>())).Throws(new ArgumentException("invalid element id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidJson(It.IsAny<JObject>())).Throws(new ArgumentException("invalid json"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreName(It.IsAny<JObject>())).Throws(new ArgumentException("invalid datastore name"));
        }

        #endregion ClientDataManage Tests
    }
}