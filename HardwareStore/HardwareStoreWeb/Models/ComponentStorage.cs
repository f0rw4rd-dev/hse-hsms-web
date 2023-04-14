namespace HardwareStoreWeb.Models
{
    public class ComponentStorage
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;

        public int ComponentId { get; set; }
        public virtual Component Component { get; set; } = null!;
    }
}
