using Rentier.DTO;
using Rentier.Repositories;
using System.ComponentModel;

namespace Rentier.Domain
{
    public class RealEstate
    {
        private readonly IRateRepository _rateRepo;

        public RealEstate(IRateRepository rateRepo)
        {
            _rateRepo = rateRepo;
        }
        [DefaultValue(RealEstateStatus.Draft)]
        public RealEstateStatus Status { get; set; }
        public Guid Id { get; set; }
        /// <summary>
        /// Фиксированная часть стоимости аренды
        /// </summary>
        public decimal FixPrice { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
        public required List<Meter> MeterList { get; set; }

        public required List<RateType> Rates { get; set; }

        public ComputedResult Compute(DateOnly date)
        {
            var result = new ComputedResult
            {
                SummaryText = string.Empty,
                Result = FixPrice
            };
            foreach (Meter meter in MeterList)
            {
                var itmResult = meter.Compute(Rates, date) ;
                result.Result += itmResult.Result;
                result.SummaryText += itmResult.SummaryText;
                result.SummaryText += "\r\n";
            }
            var canalizationResult = ComputeCanalization(date);
            result.SummaryText += canalizationResult.SummaryText;
            result.SummaryText += "\r\n";
            result.Result += canalizationResult.Result;
            return result;
        }

        public ComputedResult ComputeCanalization(DateOnly date)
        {
            var waterMeters = MeterList.Where(m => m.GetType() == typeof(ColdWaterMeter) || m.GetType() == typeof(HotWaterMeter));
            decimal waterValueSum = 0;
            foreach (Meter meter in waterMeters)
            {
                var currentVal = meter.GetCurrentValue(date);
                var beforeVal = meter.GetBeforeValue(date);
                waterValueSum += currentVal - beforeVal;

            }
            var rate = _rateRepo.GetRate(RateType.Canalization, date);
            var result = waterValueSum * rate.Value;
            return new ComputedResult { 
                SummaryText = $"Водоотведение {waterValueSum} куб.М. тариф {rate.Value} р. стоимость: {result} р.",
                Result = result };
        }

    }
}