using Rentier.Bot.Services;
using Rentier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Tests
{
    public class BotRealEstateTests
    {
        private readonly RateMockRepository rateRepo = new RateMockRepository();
        private readonly RealEstateRepository rer;
        private readonly string login = "@MikhailSidorov926";
        public BotRealEstateTests() {
            rer = new RealEstateRepository("mongodb://mgadmin:Sun32167!@127.0.0.1:27017", rateRepo);
        }
        [Fact]
        public void CreateRealEstateTest()
        {
            var reService = new RealEstateService(rer, rateRepo);
            var task = reService.AddRealEstate("Некий объект", login);
            task.Wait();
        }
        [Fact]
        public void GetSingleRE()
        {
            var reService = new RealEstateService(rer, rateRepo);
            var task = reService.GetRealEstate(Guid.Parse("6213005a-46f3-47b9-80fc-b5a434ce01e3"), login);
            task.Wait();
        }
    }
}
