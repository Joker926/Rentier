using Rentier.DTO;
using Rentier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Domain
{
    public class Meter
    {
        public readonly IRateRepository _rateRepo;
        public Meter(IRateRepository rateRepo) {
            Values = new List<MeterValue>();
            _rateRepo = rateRepo;
        }

        protected string _name;
        protected string _unitType;

        /// <summary>
        /// Серийный номер
        /// </summary>
        public string? SerialNumber { get; set; }
        public List<MeterValue> Values { get; set; }

        private const string noCurrentValueMsg = "Не введены показания счетчика для текущего периода";
        private const string noBeforeValueMsg = "Не введены показания счетчика для предыдущего периода";

        public virtual decimal SelectRate(List<RateType> availableRates, DateOnly date) 
        { throw new NotImplementedException(); }
        public ComputedResult Compute(List<RateType> availableRates,DateOnly date)
        {
            var beforePeriodDate = date.AddMonths(-1);
            var countOfValuesForThisMonth = Values.Where(v => v.Year == date.Year && v.Month == date.Month)
                .Count();
            if (countOfValuesForThisMonth < 1) throw new ApplicationException(noCurrentValueMsg);
            var countOfValuesForMonthBefore = Values.Where(v => v.Year == beforePeriodDate.Year && v.Month == beforePeriodDate.Month).Count();
            if(countOfValuesForThisMonth<1) throw new ApplicationException(noBeforeValueMsg);
            var currentValue = GetCurrentValue(date);
            var beforeValue = Values.Where(v => v.Year == beforePeriodDate.Year && v.Month == beforePeriodDate.Month).FirstOrDefault();
            var diffValues =  currentValue - beforeValue.Value;
            var rate = SelectRate(availableRates, date);
            var result = diffValues * rate;
            var sumText = $"{_name} c номером {SerialNumber} было потрачено {diffValues} {_unitType} по тарифу {rate} стоимость составляет {result} р.";
            return new ComputedResult { Result = result, SummaryText = sumText };
        }

        internal decimal GetCurrentValue(DateOnly date)
        {
            var currentValue = Values.Where(v => v.Year == date.Year && v.Month == date.Month).FirstOrDefault();
            if (currentValue == null) throw new ApplicationException(noCurrentValueMsg);
            return currentValue.Value;
        }
        internal decimal GetBeforeValue(DateOnly date)
        {
            var beforePeriodDate = date.AddMonths(-1);
            var beforeValue = Values.Where(v => v.Year == beforePeriodDate.Year && v.Month == beforePeriodDate.Month).FirstOrDefault();
            if (beforeValue == null) throw new ApplicationException(noBeforeValueMsg);
            return beforeValue.Value;
        }

    }
}
