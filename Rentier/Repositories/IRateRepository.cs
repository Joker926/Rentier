using Rentier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Repositories
{
    public interface IRateRepository
    {
        public Rate GetRate(RateType type, DateOnly date);
        

    }
}
