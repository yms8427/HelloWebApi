using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeAdam.WebApi.Services
{
    public interface INumberService
    {
        int Increase();
    }

    public class NumberService : INumberService
    {
        public NumberService()
        {

        }
        private int number;
        public int Increase()
        {
            return ++number;
        }
    }
}
