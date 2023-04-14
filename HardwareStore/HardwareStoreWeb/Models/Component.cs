using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class Component
    {
        public int Id { get; set; }

        public int ComponentTypeId { get; set; }
        public virtual ComponentType ComponentType { get; set; } = null!;

        [StringLength(256)]
        public required string Name { get; set; }
        public int Warranty { get; set; }

        [JsonIgnore]
        public virtual ICollection<ComponentDetail> ComponentDetails { get; private set; } = new ObservableCollection<ComponentDetail>();

        [JsonIgnore]
        public virtual ICollection<ComponentStorage> ComponentStorages { get; private set; } = new ObservableCollection<ComponentStorage>();

        [JsonIgnore]
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();

        [JsonIgnore]
        public virtual ICollection<Configuration> Configurations { get; private set; } = new ObservableCollection<Configuration>();

        [JsonIgnore]
        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
