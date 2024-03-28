using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Rentier.Api.DTO
{
    public class RealEstateDto
    {
        public Guid? Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
