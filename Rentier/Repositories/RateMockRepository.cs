﻿using Rentier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Repositories
{
    public class RateMockRepository : IRateRepository
    {
        public Rate GetRate(RateType type, DateOnly date)
        {
            switch (type) {
                case RateType.ColdWater:
                    return new Rate()
                    {
                        DateFrom = new DateOnly(2022, 01, 01),
                        DateTo = new DateOnly(2023, 12, 31),
                        Type = RateType.ColdWater,
                        Value = 26.94M
                    };
                case RateType.HotWater:
                    return new Rate()
                    {
                        DateFrom = new DateOnly(2022, 01, 01),
                        DateTo = new DateOnly(2023, 12, 31),
                        Type = RateType.HotWater,
                        Value = 232.17M
                    };
                case RateType.ElectricityWithGas:
                    return new Rate()
                    {
                        DateFrom = new DateOnly(2022, 01, 01),
                        DateTo = new DateOnly(2023, 12, 31),
                        Type = RateType.ElectricityWithGas,
                        Value = 6.73M
                    };
                case RateType.ElectricityWithoutGas:
                    return new Rate()
                    {
                        DateFrom = new DateOnly(2022, 01, 01),
                        DateTo = new DateOnly(2023, 12, 31),
                        Type = RateType.ElectricityWithoutGas,
                        Value = 5.05M
                    };
                case RateType.Canalization:
                    return new Rate()
                    {
                        DateFrom = new DateOnly(2022, 01, 01),
                        DateTo = new DateOnly(2023, 12, 31),
                        Type = RateType.Canalization,
                        Value = 22.52M
                    };
                default: throw new NotImplementedException();
            }
       }
    }
}
