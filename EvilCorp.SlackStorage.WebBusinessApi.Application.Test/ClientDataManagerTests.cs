using EvilCorp.SlackStorage.WebBusinessApi.Business;
using EvilCorp.SlackStorage.WebBusinessApi.CrossCutting.Testing;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Data.Test
{
    [TestClass]
    public class ClientDataManagerTests : TestsFor<ClientDataManager>
    {
        private readonly string _userId = "UserID";
        private readonly string _dataStoreId = "DataStoreID";
        private readonly string _result = "value: value1";
        private ExceptionHandler _exceptionHandler;

        protected override void OverrideMocks()
        {
            // Arrange
            var mockedLogger = GetMockFor<ILogger>().Object;
            _exceptionHandler = new ExceptionHandler(mockedLogger);
            Inject<IExceptionHandler>(_exceptionHandler);
        }

        #region ClientDataManage Tests

        [TestMethod]
        public void GetAll_IdIsOK_RepositoryIsCalled()
        {
            // Arrange
            GetMockFor<IValidator>().Setup(v => v.IsValidUserId(_userId)).Returns(true);

            // Act
            var result = Instance.GetAll(_userId);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_userId), Times.Once());
        }

        [TestMethod]
        public void GetAll_IdIsInvalid_RepositoryIsNeverCalled()
        {
            // Act
            var result = Instance.GetAll(_userId);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_userId), Times.Never());
        }

        [TestMethod]
        public void GetOne_IdsAreOK_RepositoryIsCalledK()
        {
            // Arrange
            GetMockFor<IValidator>().Setup(v => v.IsValidUserId(_userId)).Returns(true);

            // Act
            var result = Instance.GetAll(_userId);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_userId), Times.Once());
        }

        [TestMethod]
        public async Task GetOne_IdsAreOK_ClientDataRepositoryAndLoggerThrowsAnException()
        {
            // Arrange
            GetMockFor<IClientDataRespository>().Setup(mock => mock.GetOne(_userId, _dataStoreId)).Throws(new Exception("Mooo"));
            GetMockFor<ILogger>().Setup(mock => mock.Log(It.IsAny<string>(), It.IsAny<LogLevel>())).Throws(new Exception());
            GetMockFor<IValidator>().Setup(v => v.IsValidUserId(It.IsAny<string>())).Returns(true);

            // Act
            var result = await Instance.GetOne(_userId, _dataStoreId);

            // Assert
            Assert.IsNull(result);
        }

        #endregion ClientDataManage Tests
    }
}