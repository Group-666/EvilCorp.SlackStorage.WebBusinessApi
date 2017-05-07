using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using EvilCorp.AccountService;
using WebApi.CrossCutting.Testing;
using WebApi.Domain.Entities;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class ConverterTests : TestsFor<Converter>
    {
        private readonly string _validGuid = Guid.NewGuid().ToString();
        private readonly string _invalidGuid = "InvalidGuid";

        private const string InvalidJsonError = "Invalid Json. Value: {0}";
        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string ErrorDeserializing = "Deserializing error. Value: {0}";

        #region ConverterTests Tests

        #region StringToGuid Tests

        [TestMethod]
        public void StringToGuid_IdIsValid_ReturnsGuid()
        {
            // Act
            var guid = Instance.StringToGuid(_validGuid);

            // Assert
            Assert.IsNotNull(guid);
        }

        [TestMethod]
        public void StringToGuid_IdIsNull_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToGuid(null));

            // Assert
            AssertThrowsInvalidGuidError(null, exception.Message);
        }

        [TestMethod]
        public void StringToGuid_IdIsEmpty_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToGuid(""));

            // Assert
            AssertThrowsInvalidGuidError("", exception.Message);
        }

        [TestMethod]
        public void StringToGuid_IdIsNotAGuid_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToGuid(_invalidGuid));

            // Assert
            AssertThrowsInvalidGuidError(_invalidGuid, exception.Message);
        }

        private static void AssertThrowsInvalidGuidError(string value, string exceptionMessage)
        {
            Assert.AreEqual($"{string.Format(InvalidGuidError, value)}\r\nParameter name: userId", exceptionMessage);
        }

        #endregion StringToGuid Tests

        #region JsonToObject Tests

        [TestMethod]
        public void JsonToObject_JsonIsValid_ReturnsAccount()
        {
            // Arrange
            var _validJson = JObject.Parse(@"{username:'values', password:'values', nickname:'values'}");

            // Act
            var account = Instance.JsonToObject<Account>(_validJson);

            // Assert
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void JsonToObject_JsonIsNull_ThrowsArgumentExceptionInvalidJson()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.JsonToObject<Account>(null));

            // Assert
            AssertThrowsException(InvalidJsonError, null, "body", exception.Message);
        }

        [TestMethod]
        public void JsonToObject_JsonIsEmpty_ReturnEmptyAccount()
        {
            // Arrange
            var _emptyJson = JObject.Parse(@"{}");

            // Act
            var account = Instance.JsonToObject<Account>(_emptyJson);

            // Assert
            Assert.IsNotNull(account);
            Assert.IsNull(account.Nickname);
            Assert.IsNull(account.Password);
        }

        #endregion JsonToObject Tests

        #region ObjectToJson Tests

        [TestMethod]
        public void ObjectToJson_IdIsValid_ReturnsAccount()
        {
            // Arrange
            var validAccount = new Account { Id = Guid.NewGuid(), Nickname = "nickanme", Username = "Username", Password = "pasword" };

            // Act
            var account = Instance.ObjectToJson<Account>(validAccount);

            // Assert
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void ObjectToJson_IdIsNull_ThrowsArgumentExceptionInvalidJson()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.ObjectToJson<Account>(null));

            // Assert
            AssertThrowsException(ErrorDeserializing, null, "request", exception.Message);
        }

        [TestMethod]
        public void ObjectToJson_ObjectIsEmpty_ReturnEmptyObject()
        {
            // Arrange
            var emptyAccount = new Account();

            // Act
            var account = Instance.ObjectToJson<Account>(emptyAccount);

            // Assert
            Assert.IsNotNull(account);
        }

        #endregion ObjectToJson Tests

        private static void AssertThrowsException(string errorMessage, string value, string parameterName, string exceptionMessage)
        {
            Assert.AreEqual($"{string.Format(errorMessage, value)}\r\nParameter name: " + parameterName, exceptionMessage);
        }

        #endregion ConverterTests Tests
    }
}