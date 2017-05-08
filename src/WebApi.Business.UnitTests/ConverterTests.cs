using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebApi.CrossCutting.Testing;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class ConverterTests : TestsFor<Converter>
    {
        private readonly string _validGuid = Guid.NewGuid().ToString();
        private readonly string _invalidGuid = "InvalidGuid";

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";

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

        #region StringToJson Tests

        [TestMethod]
        public void StringToJson_IdIsValid_ReturnsGuid()
        {
            // Act
            var result = Instance.StringToJson(@"{id:'" + Guid.NewGuid() + "'}");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StringToJson_IdIsNull_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToJson(null));

            // Assert
            AssertThrowsInvalidGuidError(null, exception.Message);
        }

        //[TestMethod]
        //public void StringToJson_IdIsEmpty_ThrowsArgumentExceptionInvalidGuid()
        //{
        //    // Act
        //    var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToJson(""));

        //    // Assert
        //    AssertThrowsInvalidGuidError("", exception.Message);
        //}

        //[TestMethod]
        //public void StringToJson_IdIsNotAGuid_ThrowsArgumentExceptionInvalidGuid()
        //{
        //    // Act
        //    var exception = Assert.ThrowsException<ArgumentException>(() => Instance.StringToJson(_invalidGuid));

        //    // Assert
        //    AssertThrowsInvalidGuidError(_invalidGuid, exception.Message);
        //}

        //private static void AssertThrowsInvalidGuidError(string value, string exceptionMessage)
        //{
        //    Assert.AreEqual($"{string.Format(InvalidGuidError, value)}\r\nParameter name: userId", exceptionMessage);
        //}

        #endregion StringToJson Tests

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
        public void JsonToObject_JsonIsNull_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.JsonToObject<Account>(null));

            // Assert
            Assert.IsTrue(exception.Message.Contains(FieldNullOrEmptyError));
        }

        [TestMethod]
        public void JsonToObject_JsonIsEmpty_ReturnEmptyAccount()
        {
            // Arrange
            var emptyJson = JObject.Parse(@"{}");

            // Act
            var account = Instance.JsonToObject<Account>(emptyJson);

            // Assert
            Assert.IsNotNull(account);
            Assert.IsNull(account.Nickname);
            Assert.IsNull(account.Password);
        }

        #endregion JsonToObject Tests

        #region ObjectToJson Tests

        [TestMethod]
        public void ObjectToJson_ObjectIsValid_ReturnsObject()
        {
            // Arrange
            var validAccount = new Account { Id = Guid.NewGuid(), Nickname = "nickanme", Username = "Username", Password = "pasword" };

            // Act
            var account = Instance.ObjectToJson<Account>(validAccount);

            // Assert
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void ObjectToJson_ObjectIsNull_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.ObjectToJson<Account>(null));

            // Assert
            AssertExceptionIsNullOrEmpty(exception.Message);
        }

        private static void AssertExceptionIsNullOrEmpty(string exception)
        {
            Assert.IsTrue(exception.Contains(FieldNullOrEmptyError));
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

        #region ObjectsToJson Tests

        [TestMethod]
        public void ObjectsToJson_ObjectIsValid_ReturnsObject()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>
            {
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"},
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"}
            };

            // Act
            var result = Instance.ObjectsToJson(accounts);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObjectsToJson_IdIsNull_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.ObjectsToJson<IEnumerable<Account>>(null));

            // Assert
            Assert.IsTrue(exception.Message.Contains(FieldNullOrEmptyError));
        }

        [TestMethod]
        public void ObjectsToJson_StringIsNull_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>
            {
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"},
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"}
            };
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.ObjectsToJson(accounts, null));

            // Assert
            Assert.IsTrue(exception.Message.Contains(FieldNullOrEmptyError));
        }

        [TestMethod]
        public void ObjectsToJson_StringIsEmpty_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>
            {
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"},
                new Account {Id = Guid.NewGuid(), Nickname = "nickname"}
            };
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.ObjectsToJson(accounts, ""));

            // Assert
            Assert.IsTrue(exception.Message.Contains(FieldNullOrEmptyError));
        }

        [TestMethod]
        public void ObjectsToJson_ObjectIsEmpty_ReturnEmptyObject()
        {
            // Arrange
            IEnumerable<Account> accounts = new List<Account>();

            // Act
            var account = Instance.ObjectsToJson(accounts);

            // Assert
            Assert.IsNotNull(account);
        }

        #endregion ObjectsToJson Tests

        private static void AssertThrowsException(string errorMessage, string value, string parameterName, string exceptionMessage)
        {
            Assert.AreEqual($"{string.Format(errorMessage, value)}\r\nParameter name: " + parameterName, exceptionMessage);
        }

        #endregion ConverterTests Tests
    }
}