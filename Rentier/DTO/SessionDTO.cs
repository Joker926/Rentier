using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.DTO
{
    [BsonIgnoreExtraElements]
    public class SessionDTO
    {
        [BsonId]
        public string ChatId { get; set; }
        public string ChatName { get; set; }
    }
}
