using ScmCodingTest.UserInputs;
using Unity;
using Unity.Lifetime;

namespace ScmCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IAcceptInputs, AcceptValues>();
            container.RegisterType<IProductServices, ProductServices>();
            var product = container.Resolve<ProductServices>();
            product.ProductCheckOut();
        }       
    }
}
