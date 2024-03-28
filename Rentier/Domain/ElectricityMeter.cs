using Rentier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Domain
{
    public class ElectricityMeter: Meter
    {
        public ElectricityMeter(IRateRepository repRep) : base(repRep)
        {
            _name = "Счетчик электричества ";
            _unitType = "КВт*ч ";
        }
        public override decimal SelectRate(List<RateType> availableRates, DateOnly date)
        {
            var rateType = availableRates.Where(x => 
            x.Equals(RateType.ElectricityWithGas) ||
            x.Equals(RateType.ElectricityWithoutGas)
            ).FirstOrDefault();

            var rate = _rateRepo.GetRate(rateType, date);
            return rate.Value;
        }
    }
}
