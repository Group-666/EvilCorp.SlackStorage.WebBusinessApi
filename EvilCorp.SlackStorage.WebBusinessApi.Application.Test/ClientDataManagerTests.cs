using EvilCorp.SlackStorage.WebBusinessApi.CrossCutting.Testing;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business.Test
{
    [TestClass]
    public class ClientDataManagerTests : TestsFor<ClientDataManager>
    {
        private readonly string _stringValue = "SomeString";
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
        public async Task Create_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.Create(_stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.Create(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task Create_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Create(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.Create(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion Create Tests

        #region Post Tests

        [TestMethod]
        public async Task Post_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.Post(_stringValue, _stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.Post(_stringValue, _stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task Post_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.Post(_stringValue, _stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.Post(_stringValue, _stringValue, _stringValue), Times.Never());
            }
        }

        #endregion Post Tests

        #region GetAll Tests

        [TestMethod]
        public async Task GetAll_IdIsInvalid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.GetAll(_stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_stringValue), Times.Once());
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
                GetMockFor<IClientDataRespository>().Verify(r => r.GetAll(_stringValue), Times.Never());
            }
        }

        #endregion GetAll Tests

        #region GetOne Tests

        [TestMethod]
        public async Task GetOne_IdsAreValid_RepositoryIsCalledK()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.GetOne(_stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetOne(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetOne_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();

            // Act
            try
            {
                await Instance.GetOne(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.GetOne(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion GetOne Tests

        #region GetElementAll Tests

        [TestMethod]
        public async Task GetElementAll_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.GetElementAll(_stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetElementAll(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetElementAll_IdsAreInvalid_RepositoryIsNeverCalled()
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
                GetMockFor<IClientDataRespository>().Verify(r => r.GetElementAll(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion GetElementAll Tests

        #region GetElementOne Tests

        [TestMethod]
        public async Task GetElementOne_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.GetElementOne(_stringValue, _stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.GetElementOne(_stringValue, _stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task GetElementOne_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.GetElementOne(_stringValue, _stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.GetElementOne(_stringValue, _stringValue, _stringValue), Times.Never());
            }
        }

        #endregion GetElementOne Tests

        #region DeleteAll Tests

        [TestMethod]
        public async Task DeleteAll_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.DeleteAll(_stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteAll(_stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteAll_IdsAreInvalid_RepositoryIsNeverCalled()
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
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteAll(_stringValue), Times.Never());
            }
        }

        #endregion DeleteAll Tests

        #region DeleteOne Tests

        [TestMethod]
        public async Task DeleteOne_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.DeleteOne(_stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteOne(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteOne_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.DeleteOne(_stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteOne(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion DeleteOne Tests

        #region DeleteElementAll Tests

        [TestMethod]
        public async Task DeleteElementAll_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.DeleteOne(_stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteOne(_stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteElementAll_IdsAreInvalid_RepositoryIsNeverCalled()
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
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElementAll(_stringValue, _stringValue), Times.Never());
            }
        }

        #endregion DeleteElementAll Tests

        #region DeleteElementOne Tests

        [TestMethod]
        public async Task DeleteElementOne_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            SetupValidatorToBeValid();

            // Act
            await Instance.DeleteElementOne(_stringValue, _stringValue, _stringValue);

            // Assert
            GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElementOne(_stringValue, _stringValue, _stringValue), Times.Once());
        }

        [TestMethod]
        public async Task DeleteElementOne_IdsAreInvalid_RepositoryIsNeverCalled()
        {
            // Arrange
            SetupValidatorToThrowExpection();
            // Act
            try
            {
                await Instance.DeleteElementOne(_stringValue, _stringValue, _stringValue);
            }
            catch
            {
                // Assert
                GetMockFor<IClientDataRespository>().Verify(r => r.DeleteElementOne(_stringValue, _stringValue, _stringValue), Times.Never());
            }
        }

        #endregion DeleteElementOne Tests

        private void SetupValidatorToBeValid()
        {
            GetMockFor<IValidator>().Setup(v => v.IsValidUserId(_stringValue)).Returns(true);
        }

        private void SetupValidatorToThrowExpection()
        {
            GetMockFor<IValidator>().Setup(v => v.IsValidUserId(It.IsAny<string>())).Throws(new ArgumentException("invalid user id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreId(It.IsAny<string>())).Throws(new ArgumentException("invalid datastore id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidElementId(It.IsAny<string>())).Throws(new ArgumentException("invalid element id"));
            GetMockFor<IValidator>().Setup(v => v.IsValidJson(It.IsAny<string>())).Throws(new ArgumentException("invalid json"));
            GetMockFor<IValidator>().Setup(v => v.IsValidDataStoreName(It.IsAny<string>())).Throws(new ArgumentException("invalid datastore name"));
        }

        #endregion ClientDataManage Tests
    }
}