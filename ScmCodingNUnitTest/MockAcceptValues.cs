using ScmCodingTest.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScmCodingNUnitTest
{
    class MockAcceptValues : IAcceptInputs
    {
        public int NumberOfOrderPlaced()
        {
            return 3;
        }

        public string OrderType()
        {
            return "A";
        }
    }
}
