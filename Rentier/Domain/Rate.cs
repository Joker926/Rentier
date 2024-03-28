using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Domain
{
    public class Rate
    {
        public decimal Value { get; set; }
        public RateType Type { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set;}
    }

    public enum RateType
    {
        ElectricityWithGas = 0,
        ElectricityWithoutGas = 1,
        ColdWater = 2,
        HotWater = 3,
        /// <summary>
        /// Для приготовления пищи и нагрева воды с использованием газовой плиты
        /// </summary>
        GasForCooking = 4,
        /// <summary>
        /// Для приготовления пищи с использованием газовой плиты и нагрева воды с использованием газового нагревателя
        /// </summary>
        GasForCookingAndHotWater = 5,
        /// <summary>
        /// Отопление индивидуальное в пределах нормативной площади жилых помещений с использованием газа по направлениям приготовления пищи и нагрева воды
        /// </summary>
        GasForHeating = 6,
        /// <summary>
        /// Водоотведение
        /// </summary>
        Canalization = 7,
    }
}
