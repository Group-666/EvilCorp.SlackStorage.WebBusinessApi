using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using WebApi.CrossCutting.Testing;

namespace WebApi.Business.UnitTests
{
    [TestClass]
    public class ValidatorTests : TestsFor<Validator>
    {
        private const int DataStoreIdMaxLength = 105;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - Guid.NewGuid().ToString().Length - 1;

        private readonly string _validGuid = Guid.NewGuid().ToString();
        private readonly string _validDataStoreId = Guid.NewGuid().ToString() + "AA";
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
        private const string InvalidDataStoreIdError = "Invalid ID. Value: {0}";

        #region ValidatorTests Tests

        #region IsValidGuid Tests

        [TestMethod]
        public void IsValidUserId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidGuid(_validGuid);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidUserId_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidGuid(null));

            // Assert
            AssertThrowsInvalidGuidError(null, exception.Message);
        }

        [TestMethod]
        public void IsValidUserId_IdIsEmpty_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidGuid(""));

            // Assert
            AssertThrowsInvalidGuidError("", exception.Message);
        }

        [TestMethod]
        public void IsValidUserId_IdIsNotAGuid_ThrowsArgumentExceptionInvalidGuid()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidGuid(DataStoreIdMaxLengthString));

            // Assert
            AssertThrowsInvalidGuidError(DataStoreIdMaxLengthString, exception.Message);
        }

        private void AssertThrowsInvalidGuidError(string value, string exceptionMessage)
        {
            Assert.AreEqual(string.Format("{0}\r\nParameter name: userId", string.Format(InvalidGuidError, value)), exceptionMessage);
        }

        #endregion IsValidGuid Tests

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
        public void IsValidElementId_IdIsNull_ThrowsArgumentExceptionInvalidObjectId()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(null));

            // Assert
            AssertThrowsInvalidObjectIdError(null, exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsEmpty_ThrowsArgumentExceptionInvalidObjectId()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(""));

            // Assert
            AssertThrowsInvalidObjectIdError("", exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsNotAGuid_ThrowsArgumentExceptionInvalidObjectId()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(DataStoreIdMaxLengthString));

            // Assert
            AssertThrowsInvalidObjectIdError(DataStoreIdMaxLengthString, exception.Message);
        }

        private void AssertThrowsInvalidObjectIdError(string value, string exceptionMessage)
        {
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", string.Format(InvalidObjectIdError, value)), exceptionMessage);
        }

        #endregion IsValidElementId Tests

        #region IsValidDataStoreId Tests

        [TestMethod]
        public void IsValidDataStoreId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidDataStoreId(_validDataStoreId);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsNull_ThrowsArgumentExceptionInvalidId()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(null));

            // Assert
            AssertThrowsInvalidIdError(null, exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsEmpty_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(""));

            // Assert
            AssertThrowsInvalidIdError("", exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsAboveMaxLength_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(LongString));

            // Assert
            AssertThrowsInvalidIdError(LongString, exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsAtMaxLength_ThrowsArgumentException()
        {
            // Act
            var isValid = Instance.IsValidDataStoreId(DataStoreIdMaxLengthString);

            // Assert
            Assert.IsTrue(isValid);
        }

        private void AssertThrowsInvalidIdError(string value, string exceptionMessage)
        {
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreId", string.Format(InvalidDataStoreIdError, value)), exceptionMessage);
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
            Assert.AreEqual(string.Format("{0}\r\nParameter name: body", FieldNullOrEmptyError), exception.Message);
        }

        #endregion IsValidJson Tests

        #endregion ValidatorTests Tests
    }
}