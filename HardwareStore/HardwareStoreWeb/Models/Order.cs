using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using HardwareStoreWeb.Utilities;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

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
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Дата заказа")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public DateTime Date { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();
    }
}
