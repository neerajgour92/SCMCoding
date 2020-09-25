using NUnit.Framework;
using ScmCodingTest;

namespace ScmCodingNUnitTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void ScenarioA()
        {
            ProductServices products = new ProductServices(new MockAcceptValues());
            products.ProductCheckOut();
            //Assert.AreEqual();
        }
    }
}
