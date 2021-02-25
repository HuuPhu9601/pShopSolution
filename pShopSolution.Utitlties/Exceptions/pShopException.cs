using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Utitlties.Exceptions
{
    public class pShopException: Exception
    {
        public pShopException()
        {

        }

        public pShopException(string message):base(message)
        {

        }

        public pShopException(string message,Exception inner) : base(message,inner)
        {

        }
    }
}
