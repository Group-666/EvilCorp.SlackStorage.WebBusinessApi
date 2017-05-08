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

        #region AccountRepository Tests

        [TestMethod, TestCategory("Integration")]
        public async Task Create_ValidParameters_ReturnsAccount()
        {
            // Act
            var result = await Instance.Create(_validAccount);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GetAll_ReturnsAny()
        {
            // Act
            var result = await Instance.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Get_ValidParameters_ReturnsAccount()
        {
            // Act
            var result = await Instance.Get(_validGuid);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Update_ValidParameter_TaskCompleted()
        {
            // Act
            await Instance.Update(_validAccount);
        }

        [TestMethod, TestCategory("Integration")]
        public async Task Delete_ValidParameter_TaskCompleted()
        {
            // Act
            await Instance.Delete(_validGuid);
        }

        #endregion AccountRepository Tests
    }
}