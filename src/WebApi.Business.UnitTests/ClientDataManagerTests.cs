using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using WebApi.CrossCutting.Testing;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class ClientDataManagerTests : TestsFor<ClientDataManager>
    {
        private readonly string _stringValue = "SomeString";
        private readonly JObject _validJson = JObject.Parse(@"{name:'values'}");

        private ExceptionHandler _exceptionHandler;

        protected override void OverrideMocks()
        {
            // Arrange
            var mockedLogger = GetMockFor<ILogger>().Object;
            _exceptionHandler = new ExceptionHandler(mockedLogger);
            Inject<IExceptionHandler>(_exceptionHandler);
        }

        #region ClientDataManage Tests

        #region Create Tests

        [TestMethod]
        public async Task Create_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Create(_stringValue, _validJson);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.Create(_stringValue, _validJson), Times.Once);
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.Create(_stringValue, _validJson);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task Create_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Create(_stringValue, _validJson);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.Create(_stringValue, _validJson), Times.Never());
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
            }
        }

        #endregion Create Tests

        #region Post Tests

        [TestMethod]
        public async Task Post_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Post(_stringValue, _stringValue, _validJson);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.Post(_stringValue, _stringValue, _validJson), Times.Once());
        }

        [TestMethod]
        public async Task Post_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.Post(_stringValue, _stringValue, _validJson);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task Post_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Post(_stringValue, _stringValue, _validJson);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.Post(_stringValue, _stringValue, _validJson), Times.Never());
            }
        }

        #endregion Post Tests

        #region GetAll Tests

        [TestMethod]
        public async Task GetAll_IdIsInvalid_RepositoryIsCalled()
        {
            // Act
            await Instance.GetAll(_stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once());
            GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetAll_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.GetAll(_stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task GetAll_IdIsInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();

            // Act
            try
            {
                await Instance.GetAll(_stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_stringValue), Times.Never());
            }
        }

        #endregion GetAll Tests

        #region Get Tests

        [TestMethod]
        public async Task Get_ValidatorPositive_RepositoryIsCalledK()
        {
            // Act
            await Instance.Get(_stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.Get(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task Get_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.Get(_stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task Get_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();

            // Act
            try
            {
                await Instance.Get(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.Get(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion Get Tests

        #region GetElementAll Tests

        [TestMethod]
        public async Task GetElementAll_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.GetElementAll(_stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.GetElementAll(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetElementAll_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.GetElementAll(_stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task GetElementAll_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.GetElementAll(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.GetElementAll(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion GetElementAll Tests

        #region GetElement Tests

        [TestMethod]
        public async Task GetElement_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.GetElement(_stringValue, _stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.GetElement(_stringValue, _stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetElement_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.GetElement(_stringValue, _stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task GetElement_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.GetElement(_stringValue, _stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.GetElement(_stringValue, _stringValue, _stringValue), Times.Never());
            }
        }

        #endregion GetElement Tests

        #region DeleteAll Tests

        [TestMethod]
        public async Task DeleteAll_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.DeleteAll(_stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteAll(_stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteAll_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.DeleteAll(_stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task DeleteAll_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.DeleteAll(_stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteAll(_stringValue), Times.Never());
            }
        }

        #endregion DeleteAll Tests

        #region Delete Tests

        [TestMethod]
        public async Task Delete_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Delete(_stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.Delete(_stringValue, _stringValue), Times.Once);
        }

        [TestMethod]
        public async Task Delete_ValidatorPositive_ReturnsId()
        {
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);
            // Act
            var result = await Instance.Delete(_stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task Delete_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Delete(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.Delete(_stringValue, _stringValue), Times.Never);
            }
        }

        #endregion Delete Tests

        #region DeleteElementAll Tests

        [TestMethod]
        public async Task DeleteElementAll_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.Delete(_stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.Delete(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteElementAll_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.DeleteElementAll(_stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task DeleteElementAll_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.DeleteElementAll(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElementAll(_stringValue, _stringValue), Times.Never);
            }
        }

        #endregion DeleteElementAll Tests

        #region DeleteElement Tests

        [TestMethod]
        public async Task DeleteElement_ValidatorPositive_RepositoryIsCalled()
        {
            // Act
            await Instance.DeleteElement(_stringValue, _stringValue, _stringValue);

            // Assert
            GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Once);
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElement(_stringValue, _stringValue, _stringValue), Times.Once);
        }

        [TestMethod]
        public async Task DeleteElement_ValidatorPositive_ReturnsId()
        {
            // Arrange
            var excpectedValue = JObject.Parse(@"{id:'" + Guid.NewGuid() + "'}");
            GetMockFor<IConverter>().Setup(r => r.StringToJson(It.IsAny<string>())).Returns(() => excpectedValue);

            // Act
            var result = await Instance.DeleteElement(_stringValue, _stringValue, _stringValue);

            // Assert
            Assert.AreEqual(result, excpectedValue);
        }

        [TestMethod]
        public async Task DeleteElement_ValidatorNegative_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.DeleteElement(_stringValue, _stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<ILogger>().Verify(r => r.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), Times.Exactly(2));
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElement(_stringValue, _stringValue, _stringValue), Times.Never);
            }
        }

        #endregion DeleteElement Tests

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