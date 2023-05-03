using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class OrderComponent
    {
        public int Id { get; set; }

        [DisplayName("Цена (руб)")]
        public float Price { get; set; }

        [DisplayName("Количество (шт)")]
        public int Amount { get; set; }

        [DisplayName("Часть конфигурации")]
        public bool IsPartOfConfiguration { get; set; }

        [DisplayName("ИД заказа")]
        public int OrderId { get; set; }

        [DisplayName("Заказ"), JsonIgnore]
        public virtual Order? Order { get; set; }

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
