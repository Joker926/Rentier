using Rentier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Domain
{
    public class ColdWaterMeter: Meter
    {
        public ColdWaterMeter(IRateRepository repRep): base(repRep) {
            _name = "Счетчик холодной воды ";
            _unitType = "Кубических метра ";
    }
        public override decimal SelectRate(List<RateType> availableRates, DateOnly date)
        {
            var rateType = availableRates.Where(x => x.Equals(RateType.ColdWater)).FirstOrDefault();
            
            var rate = _rateRepo.GetRate(rateType, date);
            return rate.Value;
        }

    }
}
