using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi.CrossCutting.Testing;

namespace WebApi.Data.IntergationTests
{
    [TestClass]
    public class AccountRepositoryTests : TestsFor<AccountRepository>
    {
        private const string _stringValue = "SomeString";

        #region AccountRepository Tests

        #region Create Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Create_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange
            var _validJson = JObject.Parse(@"{username:'values', password:'values', nickname:'values'}");
            var xmlIn = JsonConvert.DeserializeXNode(_validJson.ToString(), "User");
            var yourResult = new XDocument(new XElement("RegisterUser", xmlIn.Root));

            // Act
            var result = await Instance.Create(yourResult);

            // Assert
            var guid = XElement.Parse(result).Value;
            Assert.IsTrue(Guid.TryParse(guid, out _));
        }

        #endregion Create Tests

        #region Login Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Login_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.Login(_stringValue, _stringValue);

            // Assert
            var guid = XElement.Parse(result).Value;
            Assert.IsTrue(Guid.TryParse(guid, out _));
        }

        #endregion Login Tests

        #region GetAll Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.GetAll();
            var doc = XDocument.Parse(result);

            //TODO: make xml pretty
            //var docsDocument = new XmlDocument();
            //docsDocument.LoadXml(result);

            //var query = from data in doc.Descendants("a:User")
            //            select new User
            //            {
            //                UserId = (Guid)data.Parent.Attribute("a:UserId"),
            //                Nickname = (string)data.Attribute("a:NickName"),
            //                Username = (string)data.Attribute("a:Username"),
            //                Password = (string)data.Attribute("a:Password"),
            //                IsActive = (bool)data.Attribute("a:IsActive"),
            //                IsDeleted = (bool)data.Attribute("a:IsDeleted"),
            //                CreatedDate = (DateTime)data.Attribute("a:CreatedDate"),
            //                DeletedDate = (DateTime)data.Attribute("a:DeletedDate"),
            //                UserRole = (int)data.Attribute("a:UserRole"),
            //            };

            //var list = query.ToList();

            // Assert
            var json = JsonConvert.SerializeXNode(doc, Formatting.None, true);
            Assert.IsNotNull(json);
        }

        #endregion GetAll Tests

        #region GetOne Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetOne_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.GetOne(_stringValue);
            var doc = XDocument.Parse(result);

            // Assert

            var json = JsonConvert.SerializeXNode(doc, Formatting.None, true);
            Assert.IsNotNull(json);
        }

        #endregion GetOne Tests

        #region Disable Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Disable_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.Disable(_stringValue);

            // Assert
            var guid = XElement.Parse(result).Value;
            Assert.IsTrue(Guid.TryParse(guid, out _));
        }

        #endregion Disable Tests

        #region Enable Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Enable_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.Enable(_stringValue);

            // Assert
            var guid = XElement.Parse(result).Value;
            Assert.IsTrue(Guid.TryParse(guid, out _));
        }

        #endregion Enable Tests

        #region Delete Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_IdsAreValid_RepositoryIsCalled()
        {
            // Act
            var result = await Instance.Delete(_stringValue);

            // Assert
            var guid = XElement.Parse(result).Value;
            Assert.IsTrue(Guid.TryParse(guid, out _));
        }

        #endregion Delete Tests

        #endregion AccountRepository Tests
    }
}