using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments
{
    public class TestPayment : IPayment
    {
        public bool Pay { set => throw new NotImplementedException(); }
    }
}
