using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.DTO
{
    /// <summary>
    /// Объект, недвижимости, возвращаемый арендатору
    /// </summary>
    public class RealEstateInfoForTenant
    {
        /// <summary>
        /// Число, с которого ты должен подать счетчики
        /// </summary>
        public int RentDay { get; set; }
        /// <summary>
        /// Число, с которого ты должен заплатить ренту
        /// </summary>
        public int PayDay { get; set; }
        //public 
    }
}
