using MongoDB.Driver;
using Rentier.Domain;
using Rentier.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly MongoClientSettings _settings;
        private readonly MongoClient _client;
        private readonly IRateRepository _rateRepository;
        private readonly string _database = "Rentier";
        private readonly string _collectionName = "RealEstates";
        public RealEstateRepository(string connStr, IRateRepository rateRepository)
        {
            _settings = MongoClientSettings.FromConnectionString(connStr);
            _client = new MongoClient(_settings);
            _rateRepository = rateRepository;
        }
        public async Task<RealEstate> CreateRealEstate(RealEstate realEstate)
        {
            var reColl = _client.GetDatabase(_database).GetCollection<RealEstateDto>(_collectionName);
            realEstate.Id= Guid.NewGuid();
            await reColl.InsertOneAsync(Map<RealEstateDto>(realEstate));
            return realEstate;
        }

        private To Map<To>(object objFrom) where To: class
        {
            if (typeof(To) == typeof(RealEstateDto))
            {
                var reDto = new RealEstateDto()
                {
                    Name = ((RealEstate)objFrom).Name,
                    Id = ((RealEstate)objFrom).Id.ToString(),
                    Owner = ((RealEstate)objFrom).Owner,
                    Status = RealEstateStatusDtoMap(((RealEstate)objFrom).Status)
                };
                return reDto as To;
            }
            else
            {
                var reDto = new RealEstate(_rateRepository)
                {
                    Name = ((RealEstateDto)objFrom).Name,
                    Id = Guid.Parse(((RealEstateDto)objFrom).Id),
                    Owner = ((RealEstateDto)objFrom).Owner,
                    Status = RealEstateStatusMap(((RealEstateDto)objFrom).Status),
                    MeterList = new List<Meter>(),
                    Rates = new List<RateType>()
                    
                };
                return reDto as To;
            }
        }

        private RealEstateStatusDto RealEstateStatusDtoMap(RealEstateStatus realEstateStatus)
        {
            switch (realEstateStatus)
            {
                case RealEstateStatus.Draft: return RealEstateStatusDto.Draft;
                case RealEstateStatus.Ready: return RealEstateStatusDto.Ready;
            }
            throw new NotImplementedException();
        }

        private RealEstateStatus RealEstateStatusMap(RealEstateStatusDto realEstateStatus)
        {
            switch (realEstateStatus)
            {
                case RealEstateStatusDto.Draft: return RealEstateStatus.Draft;
                case RealEstateStatusDto.Ready: return RealEstateStatus.Ready;
            }
            throw new NotImplementedException();
        }

        public Task DeleteRealEstate(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RealEstate>> GetRealEstates(string login)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRealEstate(RealEstate realEstate, string login)
        {
            var builder = Builders<RealEstateDto>.Filter;
            var filter = builder.Eq("Owner", login) & builder.Eq("_id", realEstate.Id);
            var replaceObj = Map<RealEstateDto>(realEstate);
            var re = await _client.GetDatabase(_database).
                GetCollection<RealEstateDto>(_collectionName).
                FindOneAndReplaceAsync<RealEstateDto>(filter, replaceObj);
        }

        public async Task<RealEstate> GetRealEstate(Guid id, string login)
        {
            var builder = Builders<RealEstateDto>.Filter;
            var filter = builder.Eq("Owner", login) & builder.Eq("_id", id.ToString());

            var re = await _client.GetDatabase(_database).
                GetCollection<RealEstateDto>(_collectionName).
                Find<RealEstateDto>(filter).
                FirstOrDefaultAsync();

            return Map<RealEstate>(re);
        }

        public async Task<List<RealEstate>> GetMyRealEstates(string login)
        {
            var builder = Builders<RealEstateDto>.Filter;
            var filter = builder.Eq("Owner", login);

            var reDtoL = await _client.GetDatabase(_database).
                GetCollection<RealEstateDto>(_collectionName).
                Find<RealEstateDto>(filter).ToListAsync();
            var reList = new List<RealEstate>();
            foreach (var item in reDtoL) {
                var re = Map<RealEstate>(item);
                reList.Add(re);
            }
            return reList;
        }

        public Task<List<RealEstate>> GetSomeoneElseRealEstates(string login)
        {
            throw new NotImplementedException();
        }
    }
}
