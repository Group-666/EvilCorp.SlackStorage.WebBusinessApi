using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApi.CrossCutting.Testing
{
    [TestClass]
    public abstract class TestsFor<TEntity> where TEntity : class
    {
        protected TEntity Instance;
        protected MoqAutoMocker<TEntity> AutoMock;

        [TestInitialize]
        public void BeforeEachUnitTest()
        {
            AutoMock = new MoqAutoMocker<TEntity>();

            OverrideMocks();

            Instance = AutoMock.ClassUnderTest;
        }

        protected virtual void OverrideMocks()
        {
        }

        protected void Inject<TContract>(TContract with) where TContract : class
        {
            AutoMock.Container.Inject<TContract>(with);
        }

        protected Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }
    }
}