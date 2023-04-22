using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public class OrderComponent
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public bool IsPartOfConfiguration { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }

        public int WarehouseId { get; set; }

        [JsonIgnore]
        public virtual Warehouse? Warehouse { get; set; }

        public int ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component? Component { get; set; }
    }
}
