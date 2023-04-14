using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ComponentType
    {
        public int Id { get; set; }

        [StringLength(64)]
        public required string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Component> Components { get; private set; } = new ObservableCollection<Component>();
    }
}
