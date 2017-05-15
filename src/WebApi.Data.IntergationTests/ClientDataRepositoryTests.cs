using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebApi.CrossCutting.Testing;

namespace WebApi.Data.IntergationTests
{
    [TestClass]
    public class ClientDataRepositoryTests : TestsFor<ClientDataRepository>
    {
        private readonly JObject _validJson = JObject.Parse(@"{name:'values'}");
        private readonly string _validGuid = Guid.NewGuid().ToString();
        private string _validElementsId = ObjectId.GenerateNewId().ToString();
        private string _validDataStoreId = ObjectId.GenerateNewId() + "_Muffins";

        #region ClientDataRepository Tests

        #region Create Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Create_ValidParameters_ReturnsDataStoreId()
        {
            // Arrange
            var validDataStoreName = JObject.Parse(@"{dataStoreName :'Bubbles'}");

            // Act
            var result = await Instance.Create(_validGuid, validDataStoreName);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
            var dataStoreId = (string)json["dataStoreId"];
            Assert.IsNotNull(dataStoreId);

            _validDataStoreId = dataStoreId;
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Create_InvalidParameters_Throws()
        {
            // Arrange
            var invalidDataStoreName = JObject.Parse(@"{Notme :'Bubbles'}");

            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.Create(_validGuid, invalidDataStoreName));

            // Assert
            Assert.AreEqual(exception.GetHttpCode(), (int)HttpStatusCode.BadRequest);
        }

        #endregion Create Tests

        #region Post Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Post_ValidParameters_ReturnsElementId()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Post(_validGuid, _validDataStoreId, _validJson);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));

            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
            var elementId = (string)json["elementId"];
            Assert.IsNotNull(elementId);

            _validElementsId = elementId;
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Post_InvalidParameters_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.Post(_validGuid, _validDataStoreId, _validJson));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion Post Tests

        #region Get Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Get_ValidParameter_ResultIsJson()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Get(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Get_InvalidParameters_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.Get(_validGuid, _validDataStoreId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion Get Tests

        #region GetAll Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_ValidParameters_ValidJson()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.GetAll(_validGuid);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_InvalidParameters_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.GetAll(_validGuid));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion GetAll Tests

        #region GetAllElement Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetAllElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.GetAll(_validGuid);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAllElement_InvalidParameters_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.GetAllElement(_validGuid, _validDataStoreId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion GetAllElement Tests

        #region GetElement Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetElement_ValidParameter_ReturnsJson()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.GetElement(_validGuid, _validDataStoreId, _validElementsId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetElement_InvalidParameters_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.GetElement(_validGuid, _validDataStoreId, _validElementsId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion GetElement Tests

        #region UpdateElement Tests

        [TestMethod, TestCategory("Integration")]
        public async Task UpdateElement_ValidParameter_ResultNotNull()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.UpdateElement(_validGuid, _validDataStoreId, _validElementsId, _validJson);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task UpdateElement_InvalidParameter_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.UpdateElement(_validGuid, _validDataStoreId, _validElementsId, _validJson));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion UpdateElement Tests

        #region DeleteAll Tests

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAll_ValidParameter_ReturnsJson()
        {
            //TODO WHAT DOES RESULT : 1 MEAN?
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.DeleteAll(_validGuid);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAll_ValidParameter_DeletesAllDataStores()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            await Instance.DeleteAll(_validGuid);

            // Assert
            await GetAll_InvalidParameters_Throws();
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAll_InvalidParameter_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.DeleteAll(_validGuid));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion DeleteAll Tests

        #region Delete Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_ValidParameter_ReturnsJson()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            var result = await Instance.Delete(_validGuid, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_ValidParameters_DeletesADatastore()
        {
            //Arrange
            await Create_ValidParameters_ReturnsDataStoreId();

            // Act
            await Instance.Delete(_validGuid, _validDataStoreId);

            // Assert
            await Get_InvalidParameters_Throws();
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_InvalidParameter_Throws()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.Delete(_validGuid, _validDataStoreId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion Delete Tests

        #region DeleteAllElement Tests

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAllElement_ValidParameter_ReturnsJson()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.DeleteAllElement(_validGuid, _validElementsId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteAllElement_ValidParameters_DeleteAllElements()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            await Instance.DeleteAllElement(_validGuid, _validDataStoreId);

            // Assert
            await GetElement_InvalidParameters_Throws();
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DDeleteAllElement_InvalidParameter_ThrowsNotFound()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.DeleteAllElement(_validGuid, _validDataStoreId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion DeleteAllElement Tests

        #region DeleteElement Tests

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteElement_ValidParameter_ReturnsJson()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            var result = await Instance.DeleteElement(_validGuid, _validElementsId, _validDataStoreId);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
            var json = JObject.Parse(result);
            Assert.IsNotNull(json);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteElement_ValidParameters_DeleteAllElements()
        {
            //Arrange
            await Post_ValidParameters_ReturnsElementId();

            // Act
            await Instance.DeleteAllElement(_validGuid, _validDataStoreId);

            // Assert
            await GetAllElement_InvalidParameters_Throws();
        }

        [TestMethod, TestCategory("Integration")]
        public async Task DeleteElement_InvalidParameter_ThrowsNotFound()
        {
            // Act
            var exception = await Assert.ThrowsExceptionAsync<HttpException>(async () => await Instance.DeleteAllElement(_validGuid, _validDataStoreId));

            // Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, exception.GetHttpCode());
        }

        #endregion DeleteElement Tests

        #endregion ClientDataRepository Tests
    }
}