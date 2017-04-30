using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Moq;
using WebApi.CrossCutting.Testing;

namespace WebApi.Data.IntergationTests
{
    [TestClass]
    public class AccountRepositoryTests : TestsFor<AccountRepository>
    {
        private readonly string _stringValue = "SomeString";

        protected override void OverrideMocks()
        {
            // Arrange
        }

        [TestMethod]
        public async Task Create_IdsAreValid_RepositoryIsCalled()
        {
            // Arrange

            // Act
            var result = await Instance.Login(_stringValue, _stringValue);

            // Assert
        }
    }
}