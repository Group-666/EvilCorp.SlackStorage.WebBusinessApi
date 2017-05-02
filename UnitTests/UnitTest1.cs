using System;
using System.Linq;
using System.Threading.Tasks;
using EvilCorp.AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Data;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var proxy = new AccountClient();

            try
            {
                var task = proxy.GetAll();
                task.Wait();

                Assert.AreEqual(1, task.Result.Count());
            }
            finally
            {
                proxy.Close();
            }
        }
    }
}