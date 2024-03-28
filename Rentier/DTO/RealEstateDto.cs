using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace Rentier.DTO
{
    [BsonIgnoreExtraElements]
    public class RealEstateDto
    {
        [BsonId]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Owner { get; set; }
        [DefaultValue(RealEstateStatusDto.Draft)]
        public RealEstateStatusDto Status { get; set; }
        
    }

    public enum RealEstateStatusDto
    {
        Draft,
        Ready
    }
}
