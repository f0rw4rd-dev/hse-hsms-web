using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(ConfigurationId), nameof(ComponentId), IsUnique = true)]
    public class Configuration
    {
        public int Id { get; set; }

        [DisplayName("ИД конфигурации")]
        public int ConfigurationId { get; set; }

        [DisplayName("Количество комплектующего (шт)")]
        public int Amount { get; set; }

        [DisplayName("ИД комплектующего")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее"), JsonIgnore]
        public virtual Component? Component { get; set; }
    }
}
