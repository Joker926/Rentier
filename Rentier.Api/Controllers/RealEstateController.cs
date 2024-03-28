using Microsoft.AspNetCore.Mvc;
using Rentier.Domain;
using Rentier.Repositories;

namespace Rentier.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstateController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<RealEstateController> _logger;
        private readonly IRateRepository _rateRepository;

        public RealEstateController(ILogger<RealEstateController> logger, IRateRepository rateRepository)
        {
            _logger = logger;
            _rateRepository = rateRepository;
        }

        //[HttpPost]
        //public IEnumerable<RealEstate> Post([FromBody] )
        //{
        //    return Enumerable.Range(1, 5).Select(index => new RealEstate(_rateRepository)
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}