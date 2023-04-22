using HardwareStoreWeb.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Supplier? Supplier { get; set; }

        public int ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component? Component { get; set; }

        public int WarehouseId { get; set; }

        [JsonIgnore]
        public virtual Warehouse? Warehouse { get; set; }
    }
}
