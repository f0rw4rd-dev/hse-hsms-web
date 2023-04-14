using HardwareStoreWeb.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardwareStoreWeb.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public float SupplyPrice { get; set; }
        public int Amount { get; set; }
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

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public int ComponentId { get; set; }
        public virtual Component Component { get; set; } = null!;

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
