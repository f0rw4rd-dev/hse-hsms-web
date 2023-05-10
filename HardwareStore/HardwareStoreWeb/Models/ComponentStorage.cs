using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class ComponentStorage
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

		[DisplayName("Цена (руб)")]
		public float Price { get; set; }

		[DisplayName("Количество (шт)")]
		public int Amount { get; set; }

        [DisplayName("ИД склада")]
        public int WarehouseId { get; set; }

        [DisplayName("Склад"), JsonIgnore]
        public virtual Warehouse? Warehouse { get; set; }

        [DisplayName("ИД комплектующего")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее"), JsonIgnore]
        public virtual Component? Component { get; set; }
    }
}
