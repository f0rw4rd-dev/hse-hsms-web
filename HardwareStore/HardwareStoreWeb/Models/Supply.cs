using HardwareStoreWeb.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class Supply
    {
        public int Id { get; set; }

        [DisplayName("Цена поставки (руб)")]
        public float SupplyPrice { get; set; }

        [DisplayName("Количество (шт)")]
        public int Amount { get; set; }

        [DisplayName("Дата поставки")]
        public long Date { get; set; }

        [NotMapped]
        public DateTime DateHandler
        {
            get
            {
                return DateTimeHelper.UnixTimeStampToDateTime(Date);
            }
            set
            {
                Date = DateTimeHelper.DateTimeToUnixTimeStamp(value);
            }
        }

        [DisplayName("ИД поставщика")]
        public int SupplierId { get; set; }

        [DisplayName("Поставщик"), JsonIgnore]
        public virtual Supplier? Supplier { get; set; }

        [DisplayName("ИД комплектующего")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее"), JsonIgnore]
        public virtual Component? Component { get; set; }

        [DisplayName("ИД склада")]
        public int WarehouseId { get; set; }

        [DisplayName("Склад"), JsonIgnore]
        public virtual Warehouse? Warehouse { get; set; }
    }
}
