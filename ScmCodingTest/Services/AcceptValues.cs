using ScmCodingTest.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScmCodingTest
{
    class AcceptValues : IAcceptInputs
    {
        public int NumberOfOrderPlaced()
        {
            Console.WriteLine("total number of order");
            int numberOfOrder = Convert.ToInt32(Console.ReadLine());
            return numberOfOrder;
        }

        public string OrderType()
        {
            Console.WriteLine("enter the type of product:A,B,C or D");
            string orderType = Console.ReadLine().ToUpper();
            return orderType;
        }
    }    
}
