using ScmCodingTest.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScmCodingTest
{
    public class ProductServices : IProductServices
    {
        private readonly IAcceptInputs _acceptinputs;
        public ProductServices(IAcceptInputs acceptInputs)
        {
            _acceptinputs=acceptInputs;
        }

        public void ProductCheckOut()
        {
            List<Products> products = new List<Products>();
            int numberOfOrder = _acceptinputs.NumberOfOrderPlaced();

            for (int i = 0; i<numberOfOrder; i++)
            {
                string orderType = _acceptinputs.OrderType();
                if (orderType.Equals("A")||orderType.Equals("B")||orderType.Equals("C")||orderType.Equals("D"))
                {
                    products.Add(new Products() { Id=orderType, Price= GetPriceByType(orderType) });
                }
                else
                {
                    Console.WriteLine("Wrong product!!!");
                    numberOfOrder++;
                }
            }

            int totalPrice = GetTotalPrice(products);
            Console.WriteLine("Total Cart Value: {0}", totalPrice);
            Console.ReadLine();
        }
        private static int GetPriceByType(string id)
        {
            int price = 0;
            switch (id)
            {
                case "A":
                    price=50;
                    break;
                case "B":
                    price=30;
                    break;
                case "C":
                    price=20;
                    break;
                case "D":
                    price=2015;
                    break;
            }
            return price;
        }

        private static int GetTotalPrice(List<Products> products)
        {
            int totalPriceOfA = 0,
                totalPriceOfB = 0,
                totalPriceOfC = 0,
                totalPriceOfD = 0,
                countC = 0,
                countD = 0;

            var productCounter = products.GroupBy(a => a.Id)
                    .Select(x => new { key = x.Key, val = x.Count() });

            foreach (var count in productCounter)
            {
                if (count.val>0)
                {
                    if (count.key=="A")
                        totalPriceOfA=(count.val/3)*130+(count.val%3*Constants.PriceOfA);
                    if (count.key=="B")
                        totalPriceOfB=(count.val/2)*45+(count.val%2*Constants.PriceOfB);
                    if (count.key=="C")
                    {
                        countC=count.val;
                        totalPriceOfC=(countC*Constants.PriceOfC);
                    }
                    if (count.key=="D")
                    {
                        countD=count.val;
                        totalPriceOfD=(countD*Constants.PriceOfD);
                    }
                }
            }
            ProductCAndDOffer(ref totalPriceOfC, ref totalPriceOfD, countC, countD);
            return totalPriceOfA+totalPriceOfB+totalPriceOfC+totalPriceOfD;
        }

        private static void ProductCAndDOffer(ref int totalPriceOfC, ref int totalPriceOfD, int countC, int countD)
        {
            if (countC>0&&countD>0)
            {
                int remainderC = 0,
                    remainderD = 0;
                totalPriceOfC=0;
                totalPriceOfD=0;

                if (countC>countD)
                {
                    remainderC=countC%countD;
                    totalPriceOfC=totalPriceOfC+(remainderC*Constants.PriceOfC);
                    totalPriceOfC=totalPriceOfC+(countD*30);
                }
                else if (countD>countC)
                {
                    remainderD=countD%countC;
                    totalPriceOfD=totalPriceOfD+(remainderD*Constants.PriceOfD);
                    totalPriceOfD=totalPriceOfD+(countC*30);
                }
                else
                    totalPriceOfC=countC*30;
            }
        }
    }
}