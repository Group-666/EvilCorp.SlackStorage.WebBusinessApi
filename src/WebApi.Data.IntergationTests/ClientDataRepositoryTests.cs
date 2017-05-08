using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using WebApi.CrossCutting.Testing;

namespace WebApi.Data.IntergationTests
{
    [TestClass]
    public class ClientDataRepositoryTests : TestsFor<ClientDataRepository>
    {
        private readonly JObject _validJson = JObject.Parse(@"{name:'values'}");
        private readonly string _validGuid = Guid.NewGuid().ToString();
        private string _validDataStoreId = "507f191e810c19729de860ea";
        private string _validElementId = "507f191e810c19729de860ea_Values";

        #region AccountRepository Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Create_ValidParameters_ReturnsDataStoreId()
        {
            // Arrange
            var validDataStoreName = JObject.Parse(@"{DataStoreName :'Bubbles'}");

            // Act
            var result = await Instance.Create(_validGuid, validDataStoreName);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            _validDataStoreId = result;
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Post_ValidParameters_ReturnsElementId()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Post(_validGuid, _validDataStoreId, _validJson);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            _validElementId = result;
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_ValidParameters_ResultNotNull()
        {
            // Act
            var result = await Instance.GetAll(_validGuid);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Get_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Get(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAllElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.GetAllElement(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.GetElement(_validGuid, _validDataStoreId, _validElementId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task UpdateElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.UpdateElement(_validGuid, _validDataStoreId, _validElementId, _validJson);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAll_ValidParameter_ResultNotNull()
        {
            // Act
            var result = await Instance.DeleteAll(_validGuid);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_ValidParameters_ResultNotNull()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Delete(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAllElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.DeleteAllElement(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.DeleteElement(_validGuid, _validDataStoreId, _validElementId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        #endregion AccountRepository Tests
    }
}