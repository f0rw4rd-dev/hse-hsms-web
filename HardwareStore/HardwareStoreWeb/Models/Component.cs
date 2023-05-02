using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class Component
    {
        public int Id { get; set; }

        [DisplayName("Категория")]
        public int ComponentTypeId { get; set; }

        [DisplayName("Категория")]
        public virtual ComponentType? ComponentType { get; set; }

        [DisplayName("Название"), StringLength(256)]
        public required string Name { get; set; }

        [DisplayName("Гарантия")]
        public int Warranty { get; set; }

        public virtual ICollection<ComponentDetail> ComponentDetails { get; private set; } = new ObservableCollection<ComponentDetail>();
        public virtual ICollection<ComponentStorage> ComponentStorages { get; private set; } = new ObservableCollection<ComponentStorage>();
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();
        public virtual ICollection<Configuration> Configurations { get; private set; } = new ObservableCollection<Configuration>();
        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
