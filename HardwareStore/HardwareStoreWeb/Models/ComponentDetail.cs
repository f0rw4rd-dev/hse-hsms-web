using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(DetailTypeId), nameof(ComponentId), IsUnique = true)]
    public class ComponentDetail
    {
        public int Id { get; set; }

        public int DetailTypeId { get; set; }
        public virtual DetailType DetailType { get; set; } = null!;

        public int ComponentId { get; set; }
        public virtual Component Component { get; set; } = null!;

        [StringLength(128)]
        public required string Value { get; set; }
    }
}
