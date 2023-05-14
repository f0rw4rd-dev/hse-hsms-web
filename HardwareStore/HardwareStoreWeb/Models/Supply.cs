using HardwareStoreWeb.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class Supply
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Цена поставки (руб)")]
        [Range(0, float.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public float SupplyPrice { get; set; }

        [DisplayName("Количество (шт)")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int Amount { get; set; }

        [DisplayName("Дата поставки")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public DateTime Date { get; set; }

        [DisplayName("ИД поставщика")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int SupplierId { get; set; }

        [DisplayName("Поставщик")]
		[JsonIgnore]
		public virtual Supplier? Supplier { get; set; }

        [DisplayName("ИД комплектующего")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее")]
		[JsonIgnore]
		public virtual Component? Component { get; set; }

        [DisplayName("ИД склада")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int WarehouseId { get; set; }

        [DisplayName("Склад")]
        [JsonIgnore]
        public virtual Warehouse? Warehouse { get; set; }
    }
}
