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
        [Display(Name = "Создан")]
        Created = 0,

        [Display(Name = "В обработке")]
        Processing = 1,

        [Display(Name = "Готов")]
        Ready = 2,

        [Display(Name = "Получен")]
        Received = 3,

        [Display(Name = "Отменен")]
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

        [JsonIgnore]
        public virtual ICollection<OrderComponent> OrderComponents { get; private set; } = new ObservableCollection<OrderComponent>();
    }
}
