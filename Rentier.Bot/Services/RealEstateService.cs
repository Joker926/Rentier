using Rentier.Bot.Model;
using Rentier.Domain;
using Rentier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Bot.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IRealEstateRepository _realEstRepo;
        private readonly IRateRepository _rateRepo;
        public RealEstateService(IRealEstateRepository realEstRepo, IRateRepository rateRepo) {
            _realEstRepo = realEstRepo;
            _rateRepo = rateRepo;
        }

        public Task AddLastInvoicePhoto(Guid reId, string login)
        {
            throw new NotImplementedException();
        }

        public Task AddMeter(string serialNumber, string login, Model.MeterType meterType)
        {
            throw new NotImplementedException();
        }
        public async Task<Guid> AddRealEstate(string name, string login)
        {
            var realEst = new RealEstate(_rateRepo) {
                Name = name, 
                MeterList = new List<Meter>(), 
                Rates = new List<RateType>(),
                Owner = login
            };
            var result = await _realEstRepo.CreateRealEstate(realEst);
            var newRealEstId = result.Id;
            return newRealEstId;
        }

        public Task<Guid> CreateMeter(Guid reId, string meterTypeName, string serialNumber, string login)
        {
            throw new NotImplementedException();
        }

        public Task<List<RealEstate>> GetAllRealEstates(string login)
        {
            var re = _realEstRepo.GetMyRealEstates(login);
            return re;
        }

        public List<string> GetMetersTypes(string login)
        {
            throw new NotImplementedException();
        }

        public async Task<RealEstate> GetRealEstate(Guid id, string login)
        {
            var re = await _realEstRepo.GetRealEstate(id, login);
            return re;
        }

        public Task SetDayToPshMeterValues(Guid id, string login, string MetersValueDay)
        {
            throw new NotImplementedException();
        }

        public Task SetFixRent(Guid id, string login, string fixRent)
        {
            throw new NotImplementedException();
        }

        public Task SetMeterStartValue(Guid reId, Guid meterId, string login, string value)
        {
            throw new NotImplementedException();
        }

        public Task SetPayDay(Guid id, string login, string payDay)
        {
            throw new NotImplementedException();
        }

        public Task SetTenantLogin(Guid reId, string login, string tenantLogin)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRealEstate(RealEstate realEstate, string login)
        {
            throw new NotImplementedException();
        }
    }
}
