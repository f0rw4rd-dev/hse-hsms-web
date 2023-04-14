using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using HardwareStoreWeb.Utilities;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    public enum OrderStatus : int
    {
        [Description("Создан")]
        Created = 0,
        [Description("В обработке")]
        Processing = 1,
        [Description("Готов")]
        Ready = 2,
        [Description("Получен")]
        Received = 3,
        [Description("Отменен")]
        Canceled = 4
    }

    public class Order
    {
        public int Id { get; set; }
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

        public OrderStatus Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();
    }
}
