using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(City), nameof(Street), nameof(House), IsUnique = true)]
    public class Warehouse
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Город")]
        [StringLength(64, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string City { get; set; }

        [DisplayName("Улица")]
        [StringLength(64, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string Street { get; set; }

        [DisplayName("Дом")]
        [StringLength(8, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string House { get; set; }

        [DisplayName("Индекс")]
        [StringLength(8, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string Zip { get; set; }

        [NotMapped]
        public string Address 
        { 
            get
            {
                return $"{City}, {Street}, {House}";
            } 
        }

        public virtual ICollection<ComponentStorage> ComponentStorages { get; private set; } = new ObservableCollection<ComponentStorage>();

        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();

        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
