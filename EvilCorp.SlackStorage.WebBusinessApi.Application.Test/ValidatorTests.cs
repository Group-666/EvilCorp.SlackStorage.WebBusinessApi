using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EvilCorp.SlackStorage.WebApi.CrossCutting.Testing;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebApi.Business.Test
{
    [TestClass]
    public class ValidatorTests : TestsFor<Validator>
    {
        private const int DataStoreIdMaxLength = 105;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - new Guid().ToString().Length - 1;

        private readonly string _validGuid = new Guid().ToString();
        private readonly string _validObjectId = "507f191e810c19729de860ea";
        private static readonly string LongString = new string('a', 5000);
        private static readonly string DataStoreIdMaxLengthString = new string('a', DataStoreIdMaxLength);
        private static readonly JObject ValidJson = JObject.Parse(@"{dataStoreName:'values'}");
        private static readonly JObject LongJson = JObject.Parse(@"{dataStoreName:'" + LongString + "'}");

        private static readonly JObject DataStoreIdMaxLengthJson = JObject.Parse(@"{dataStoreName:'" + new string('a', DataStoreNameMaxLength) + "'}");

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidLengthError = "Length cannot be more than {0}. Value: {1}.";

        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string InvalidObjectIdError = "Invalid Object ID. Value: {0}";

        #region ValidatorTests Tests

        #region IsValidUserId Tests

        [TestMethod]
        public void IsValidUserId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidUserId(_validGuid);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidUserId_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidUserId(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: userId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidUserId_IdIsEmpty_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidUserId(""));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: userId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidUserId_IdIsNotAGuid_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidUserId(DataStoreIdMaxLengthString));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: userId", string.Format(InvalidGuidError, DataStoreIdMaxLengthString)), exception.Message);
        }

        #endregion IsValidUserId Tests

        #region IsValidElementId Tests

        [TestMethod]
        public void IsValidElementId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidElementId(_validObjectId);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidElementId_IdIsNull_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsEmpty_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(""));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsNotAGuid_ThrowsArgumentExceptionInvalidLength()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(DataStoreIdMaxLengthString));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", string.Format(InvalidObjectIdError, DataStoreIdMaxLengthString)), exception.Message);
        }

        #endregion IsValidElementId Tests

        #region IsValidDataStoreId Tests

        [TestMethod]
        public void IsValidDataStoreId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidDataStoreId(_validGuid);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsEmpty_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(""));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsAboveMaxLength_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(LongString));

            // Assert
            var a = string.Format(InvalidLengthError, DataStoreIdMaxLength, LongString);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreId", a), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsAtMaxLength_ThrowsArgumentException()
        {
            // Act
            var isValid = Instance.IsValidDataStoreId(DataStoreIdMaxLengthString);

            // Assert
            Assert.IsTrue(isValid);
        }

        #endregion IsValidDataStoreId Tests

        #region IsValidDataStoreName Tests

        [TestMethod]
        public void IsValidDataStoreName_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidDataStoreName(ValidJson);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidDataStoreName_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreNameJson", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreName_IdIsEmpty_ThrowsArgumentExceptionFieldNullOrEmpty()
        {
            // Act
            var emptyJObject = new JObject();
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(emptyJObject));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreName", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreName_IdIsAboveMaxLength_ThrowsArgumentExceptionInvalidLength()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(LongJson));

            // Assert
            var errorMessage = string.Format(InvalidLengthError, DataStoreNameMaxLength, LongJson["dataStoreName"]);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreName", errorMessage), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreName_IdIsAtMaxLength_ThrowsArgumentException()
        {
            // Act
            var isValid = Instance.IsValidDataStoreName(DataStoreIdMaxLengthJson);

            // Assert
            Assert.IsTrue(isValid);
        }

        #endregion IsValidDataStoreName Tests

        #region IsValidJson Tests

        [TestMethod]
        public void IsValidJson_JsonIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidJson(ValidJson);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidJson_JsonIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidJson(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: json", FieldNullOrEmptyError), exception.Message);
        }

        #endregion IsValidJson Tests

        #endregion ValidatorTests Tests
    }
}