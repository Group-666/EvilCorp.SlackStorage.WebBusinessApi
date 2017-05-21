using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.CrossCutting.Testing;

namespace WebApi.Data.IntergationTests
{
    [TestClass]
    public class AccountRepositoryTests : TestsFor<AccountRepository>
    {
        private readonly Account _validAccount = new Account { Id = Guid.NewGuid(), Nickname = "Nickname", Password = "Password", Username = "Username" };
        private readonly Guid _validGuid = Guid.NewGuid();
        private Account _createdAccount = null;

        #region AccountRepository Tests

        #region Create Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Create_ValidParameters_ReturnsAccount()
        {
            // Act
            var result = await Instance.Create(_validAccount);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Id, Guid.Empty);

            _createdAccount = result;
        }

        #endregion Create Tests

        #region GetAll Tests

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_ReturnsAny()
        {
            // Act
            var result = await Instance.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_ReturnsCreatedAccount()
        {
            //Arrange
            await Create_ValidParameters_ReturnsAccount();

            // Act
            var result = await Instance.GetAll();

            // Assert
            Assert.AreEqual(result.FirstOrDefault(acc => acc == _createdAccount), _createdAccount);
        }

        #endregion GetAll Tests

        #region Get Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Get_ValidParameters_ReturnsEmptyAccount()
        {
            // Act
            var result = await Instance.Get(_validGuid);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, Guid.Empty);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Get_ValidParameters_ReturnCreatedAccount()
        {
            //Arrange
            await Create_ValidParameters_ReturnsAccount();

            // Act
            var result = await Instance.Get(_createdAccount.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_createdAccount, result);
        }

        #endregion Get Tests

        #region Update Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Update_ValidParameter_TaskCompleted()
        {
            // Act
            await Instance.Update(_validAccount);
        }

        #endregion Update Tests

        #region Delete Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_ValidParameter_TaskCompleted()
        {
            // Act
            await Instance.Delete(_validGuid);
        }

        #endregion Delete Tests

        #endregion AccountRepository Tests
    }
}