using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(City), nameof(Street), nameof(House), IsUnique = true)]
    public class Warehouse
    {
        public int Id { get; set; }

        [StringLength(64)]
        public required string City { get; set; }

        [StringLength(64)]
        public required string Street { get; set; }

        [StringLength(8)]
        public required string House { get; set; }

        public int Zip { get; set; }

        [JsonIgnore]
        public virtual ICollection<ComponentStorage> ComponentStorages { get; private set; } = new ObservableCollection<ComponentStorage>();

        [JsonIgnore]
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();

        [JsonIgnore]
        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
