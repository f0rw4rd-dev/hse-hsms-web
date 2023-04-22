using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(DetailTypeId), nameof(ComponentId), IsUnique = true)]
    public class ComponentDetail
    {
        public int Id { get; set; }

        public int DetailTypeId { get; set; }

        [JsonIgnore]
        public virtual DetailType? DetailType { get; set; }

        public int ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component? Component { get; set; }

        [StringLength(128)]
        public required string Value { get; set; }
    }
}
