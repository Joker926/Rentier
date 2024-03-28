using Rentier.Bot.Model;
using Rentier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Bot.Services
{
    public interface IRealEstateService
    {
        public Task<Guid> AddRealEstate(string name, string login);

        public Task<RealEstate> GetRealEstate(Guid id, string login);
        public Task<List<RealEstate>> GetAllRealEstates(string login);

        public Task SetFixRent(Guid id, string login, string fixRent);
        public Task SetPayDay(Guid id, string login, string payDay);
        public Task SetDayToPshMeterValues(Guid id, string login, string MetersValueDay);

        public List<string> GetMetersTypes(string login);
        public Task<Guid> CreateMeter(Guid reId, string meterTypeName, string serialNumber, string login);
        public Task SetMeterStartValue(Guid reId, Guid meterId, string login, string value);
        public Task SetTenantLogin(Guid reId, string login, string tenantLogin);
        public Task AddLastInvoicePhoto(Guid reId, string login);
        public Task UpdateRealEstate(RealEstate realEstate, string login);

        //public Task AddMeter(string serialNumber, string login, MeterType meterType);

    }
}
