using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Runtime.Versioning;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class Component
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("ИД категории")]
        public int ComponentTypeId { get; set; }

        [DisplayName("Категория"), JsonIgnore]
        public virtual ComponentType? ComponentType { get; set; }

        [DisplayName("Название")]
        [StringLength(256, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string Name { get; set; }

        [DisplayName("Гарантия (мес)")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int Warranty { get; set; }

        public virtual ICollection<ComponentDetail> ComponentDetails { get; private set; } = new ObservableCollection<ComponentDetail>();
        public virtual ICollection<ComponentStorage> ComponentStorages { get; private set; } = new ObservableCollection<ComponentStorage>();
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();
        public virtual ICollection<Configuration> Configurations { get; private set; } = new ObservableCollection<Configuration>();
        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
