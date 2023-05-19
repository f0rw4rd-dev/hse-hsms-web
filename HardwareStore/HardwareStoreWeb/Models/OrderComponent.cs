using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class OrderComponent
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Цена (руб)")]
        [Range(0.1, float.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public float Price { get; set; }

        [DisplayName("Количество (шт)")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Range")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int Amount { get; set; }

        [DisplayName("Часть конфигурации")]
        public bool IsPartOfConfiguration { get; set; }

        [DisplayName("ИД заказа")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int OrderId { get; set; }

        [DisplayName("Заказ")]
        public virtual Order? Order { get; set; }

        [DisplayName("ИД склада")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int WarehouseId { get; set; }

        [DisplayName("Склад")]
        public virtual Warehouse? Warehouse { get; set; }

        [DisplayName("ИД комплектующего")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее")]
        public virtual Component? Component { get; set; }
    }
}
