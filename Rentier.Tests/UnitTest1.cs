using Rentier.Domain;
using Rentier.Repositories;
using Xunit.Abstractions;

namespace Rentier.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void Test1()
        {
            IRateRepository rateRepo = new RateMockRepository();
            
            var meters = new List<Meter>();
            var hotWM1 = new ColdWaterMeter(rateRepo) { SerialNumber = "491409893" };
            hotWM1.Values.Add(new MeterValue { Year = 2024, Month = 03, Value = 208.69M });
            hotWM1.Values.Add(new MeterValue { Year = 2024, Month = 02, Value = 201.20M });
            hotWM1.Values.Add(new MeterValue { Year = 2024, Month = 01, Value = 194.33M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 12, Value = 187.77M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 11, Value = 181.18M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 10, Value = 174.88M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 09, Value = 169.88M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 08, Value = 164.13M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 07, Value = 157.37M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 06, Value = 151.15M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 05, Value = 142.71M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 04, Value = 135.18M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 03, Value = 123.94M });
            hotWM1.Values.Add(new MeterValue { Year = 2023, Month = 02, Value = 114.22M });
            var hotWM2 = new ColdWaterMeter(rateRepo) { SerialNumber = "491409908" };
            hotWM2.Values.Add(new MeterValue { Year = 2024, Month = 03, Value = 18.31M });
            hotWM2.Values.Add(new MeterValue { Year = 2024, Month = 02, Value = 17.62M });
            hotWM2.Values.Add(new MeterValue { Year = 2024, Month = 01, Value = 16.94M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 12, Value = 16.32M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 11, Value = 15.79M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 10, Value = 15.08M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 09, Value = 14.15M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 08, Value = 13.09M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 07, Value = 11.81M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 06, Value = 10.47M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 05, Value = 9.64M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 04, Value = 8.8M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 03, Value = 7.91M });
            hotWM2.Values.Add(new MeterValue { Year = 2023, Month = 02, Value = 7.45M });
            //------
            var coldWM1 = new HotWaterMeter(rateRepo) { SerialNumber = "BC730756" };
            coldWM1.Values.Add(new MeterValue { Year = 2024, Month = 03, Value = 30.44M });
            coldWM1.Values.Add(new MeterValue { Year = 2024, Month = 02, Value = 28.85M });
            coldWM1.Values.Add(new MeterValue { Year = 2024, Month = 01, Value = 27.71M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 12, Value = 26.32M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 11, Value = 24.67M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 10, Value = 23.06M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 09, Value = 21.66M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 08, Value = 20.09M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 07, Value = 18.37M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 06, Value = 17.09M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 05, Value = 15.57M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 04, Value = 13.69M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 03, Value = 11.89M });
            coldWM1.Values.Add(new MeterValue { Year = 2023, Month = 02, Value = 11.26M });
            var coldWM2 = new HotWaterMeter(rateRepo) { SerialNumber = "BC730741" };
            coldWM2.Values.Add(new MeterValue { Year = 2024, Month = 03, Value = 18.55M });
            coldWM2.Values.Add(new MeterValue { Year = 2024, Month = 02, Value = 17.65M });
            coldWM2.Values.Add(new MeterValue { Year = 2024, Month = 01, Value = 16.69M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 12, Value = 15.57M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 11, Value = 14.18M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 10, Value = 13.06M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 09, Value = 12.08M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 08, Value = 11.21M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 07, Value = 10.49M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 06, Value = 9.82M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 05, Value = 9.03M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 04, Value = 8.31M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 03, Value = 7.31M });
            coldWM2.Values.Add(new MeterValue { Year = 2023, Month = 02, Value = 6.58M });
            //----
            var electroM = new ElectricityMeter(rateRepo) { SerialNumber = "07789148413628" };
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 02, Value = 3135M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 03, Value = 3235.2M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 04, Value = 3335.8M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 05, Value = 3418.4M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 06, Value = 3510.2M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 07, Value = 3609.1M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 08, Value = 3716.3M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 09, Value = 3810.8M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 10, Value = 3900.5M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 11, Value = 3992.0M });
            electroM.Values.Add(new MeterValue { Year = 2023, Month = 12, Value = 4090.8M });
            electroM.Values.Add(new MeterValue { Year = 2024, Month = 01, Value = 4181.4M });
            electroM.Values.Add(new MeterValue { Year = 2024, Month = 02, Value = 4246.0M });
            electroM.Values.Add(new MeterValue { Year = 2024, Month = 03, Value = 4301.9M });
            meters.Add(hotWM1);
            meters.Add(hotWM2);
            meters.Add(electroM);
            meters.Add(coldWM1 );
            meters.Add(coldWM2);

            var rateTypes = new List<RateType>();
            rateTypes.Add(RateType.ColdWater);
            rateTypes.Add(RateType.HotWater);
            rateTypes.Add(RateType.ElectricityWithGas);
            rateTypes.Add(RateType.Canalization);

            var realEst = new RealEstate(rateRepo) { FixPrice = 16000, MeterList = meters, Rates = rateTypes };
            var result = realEst.Compute(new DateOnly(2024,03,15));
            _output.WriteLine(result.SummaryText);
            _output.WriteLine($"Итого: {result.Result} р.");
        }
    }
}