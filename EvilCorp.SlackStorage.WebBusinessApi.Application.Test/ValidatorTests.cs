using EvilCorp.SlackStorage.WebBusinessApi.CrossCutting.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business.Test
{
    [TestClass]
    public class ValidatorTests : TestsFor<Validator>
    {
        private readonly string _validGuid = new Guid().ToString();
        private readonly string _validJson = "{name:'values'}";
        private readonly string _invalidGuid = "InvalidGuid";
        private readonly string _longString = new string('a', 5000);
        private readonly string _105CharsLongString = new string('a', 105);

        private const int DataStoreIdMaxLength = 105;
        private const int UserIdMaxLength = 12;
        private const int JsonMaxLength = 2000;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - UserIdMaxLength - 1;

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidGuidError = "Invalid GUID.";
        private const string InvalidJsonError = "Invalid JSON.";
        private const string InvalidLengthError = "Length cannot be more than {0}.";

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
        public void IsValidUserId_IdIsNotAGuid_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidUserId(_invalidGuid));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: userId", InvalidGuidError), exception.Message);
        }

        #endregion IsValidUserId Tests

        #region IsValidElementId Tests

        [TestMethod]
        public void IsValidElementId_IdIsValid_ReturnTrue()
        {
            // Act
            var isValid = Instance.IsValidElementId(_validGuid);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidElementId_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsEmpty_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(""));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", FieldNullOrEmptyError), exception.Message);
        }

        [TestMethod]
        public void IsValidElementId_IdIsNotAGuid_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidElementId(_invalidGuid));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: elementId", InvalidGuidError), exception.Message);
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
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreId(_longString));

            // Assert
            var a = string.Format(InvalidLengthError, DataStoreIdMaxLength);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreId", a), exception.Message);
        }

        [TestMethod]
        public void IsValidDataStoreId_IdIsAtMaxLength_ThrowsArgumentException()
        {
            // Act
            var isValid = Instance.IsValidDataStoreId(_105CharsLongString);

            // Assert
            Assert.IsTrue(isValid);
        }

        #endregion IsValidDataStoreId Tests

        #region IsValidDataStoreName Tests

        //[TestMethod]
        //public void IsValidDataStoreName_IdIsValid_ReturnTrue()
        //{
        //    // Act
        //    var isValid = Instance.IsValidDataStoreName(_validJson);

        //    // Assert
        //    Assert.IsTrue(isValid);
        //}

        [TestMethod]
        public void IsValidDataStoreName_IdIsNull_ThrowsArgumentException()
        {
            // Act
            var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(null));

            // Assert
            Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreName", FieldNullOrEmptyError), exception.Message);
        }

        //[TestMethod]
        //public void IsValidDataStoreName_IdIsEmpty_ThrowsArgumentException()
        //{
        //    // Act
        //    var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(""));

        //    // Assert
        //    Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreName", FieldNullOrEmptyError), exception.Message);
        //}

        //[TestMethod]
        //public void IsValidDataStoreName_IdIsAboveMaxLength_ThrowsArgumentException()
        //{
        //    // Act
        //    var exception = Assert.ThrowsException<ArgumentException>(() => Instance.IsValidDataStoreName(_longString));

        //    // Assert
        //    var errorMessage = string.Format(InvalidLengthError, DataStoreNameMaxLength);
        //    Assert.AreEqual(string.Format("{0}\r\nParameter name: dataStoreName", errorMessage), exception.Message);
        //}

        //[TestMethod]
        //public void IsValidDataStoreName_IdIsAtMaxLength_ThrowsArgumentException()
        //{
        //    // Act
        //    var isValid = Instance.IsValidDataStoreName(_105CharsLongString);

        //    // Assert
        //    Assert.IsTrue(isValid);
        //}

        #endregion IsValidDataStoreName Tests

        #endregion ValidatorTests Tests
    }
}