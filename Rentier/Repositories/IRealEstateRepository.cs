using Rentier.Domain;
using Rentier.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Repositories
{
    public interface IRealEstateRepository
    {
        public Task<List<RealEstate>>  GetMyRealEstates(string login);
        public Task<List<RealEstate>> GetSomeoneElseRealEstates(string login);
        public Task<RealEstate> GetRealEstate(Guid id, string login);
        public Task<RealEstate> CreateRealEstate(RealEstate realEstate);
        public Task DeleteRealEstate(Guid id);
        public Task UpdateRealEstate(RealEstate realEstate, string login);
    }
}
