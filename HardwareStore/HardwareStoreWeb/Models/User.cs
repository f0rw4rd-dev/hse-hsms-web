using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using HardwareStoreWeb.Utilities;

namespace HardwareStoreWeb.Models
{
    public enum Group : int
    {
        [Description("Продавец-консультант")]
        Consultant = 0,

        [Description("Менеджер по закупкам")]
        PurchasingManager = 1,

        [Description("Складской работник")]
        WarehouseWorker = 2,

        [Description("Аналитик")]
        Analyst = 3,

        [Description("Администратор")]
        Admin = 4,
    }

    public class User
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Пароль")]
        public required string Password { get; set; }

        [DisplayName("Дата регистрации")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Дата последнего входа")]
        public DateTime? LastVisitDate { get; set; }

        [DisplayName("Группа прав")]
        public Group Group { get; set; }
    }
}
