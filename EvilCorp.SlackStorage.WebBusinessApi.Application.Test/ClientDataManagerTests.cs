using EvilCorp.SlackStorage.WebBusinessApi.Business;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Data.Test
{
    [TestClass]
    public class ClientDataManagerTests
    {
        private Mock<IClientDataRespository> _clientDataRespositoryMock;
        private Mock<IValidator> _validatorMock;
        private Mock<IExceptionHandler> _exceptionHandlerMock;
        private Mock<ILogRepository> _logRepositoryMock;
        private Mock<ILogger> _loggerMock;
        private ClientDataManager _clientDataManagerMock;
        private readonly string _userId = "UserID";
        private readonly string _dataStoreId = "DataStoreID";
        private readonly string _result = "value: value1";

        [TestInitialize]
        public void Generate_DatesAreNullListIsEmpty_ResultIsNoEventsUploaded()
        {
            // Arrange
            _clientDataRespositoryMock = new Mock<ClientDataRespository>() { CallBase = true }.As<IClientDataRespository>();
            _logRepositoryMock = new Mock<LogRepository>() { CallBase = true }.As<ILogRepository>();

            _validatorMock = new Mock<Validator>() { CallBase = true }.As<IValidator>();
            _loggerMock = new Mock<Logger>(_logRepositoryMock.Object) { CallBase = true }.As<ILogger>();
            _exceptionHandlerMock = new Mock<ExceptionHandler>(_loggerMock.Object) { CallBase = true }.As<IExceptionHandler>();

            _clientDataManagerMock = new ClientDataManager(_clientDataRespositoryMock.Object, _validatorMock.Object, _exceptionHandlerMock.Object);
        }

        #region ClientDataManage Tests

        [TestMethod]
        public void GetAll_IdIsOK_ResultIsOK()
        {
            // Arrange
            _clientDataRespositoryMock.Setup(mock => mock.GetAll(_userId)).Returns(Task.FromResult<string>(_result));

            // Act

            var result = _clientDataManagerMock.GetAll(_userId);

            // Assert

            Assert.AreEqual(result.Result, _result);
        }

        [TestMethod]
        public void GetOne_IdsAreOK_ResultIsOK()
        {
            // Arrange
            _clientDataRespositoryMock.Setup(mock => mock.GetOne(_userId, _dataStoreId)).Returns(Task.FromResult<string>(_result));
            // Act

            var result = _clientDataManagerMock.GetOne(_userId, _dataStoreId);

            // Assert

            Assert.AreEqual(result.Result, _result);
        }

        [TestMethod]
        public void GetOne_IdsAreOK_ExceptionHandlerThrowsAnException()
        {
            // Arrange
            //_exceptionHandlerMock.Setup(mock => mock.Run(It.IsAny<Func<object>>())).Throws(new Exception());
            _clientDataRespositoryMock.Setup(mock => mock.GetOne(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
            // Act

            //var result = _clientDataManagerMock.GetOne(_userId, _dataStoreId);

            _loggerMock.Object.Log("No", Domain.Entities.LogLevel.Critical);

            // Assert

            //Assert.AreEqual(result.Result, _result);
        }

        #endregion ClientDataManage Tests
    }
}