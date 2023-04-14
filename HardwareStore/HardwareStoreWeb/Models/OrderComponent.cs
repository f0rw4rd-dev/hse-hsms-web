namespace HardwareStoreWeb.Models
{
    public class OrderComponent
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public bool IsPartOfConfiguration { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;

        public int ComponentId { get; set; }
        public virtual Component Component { get; set; } = null!;
    }
}
