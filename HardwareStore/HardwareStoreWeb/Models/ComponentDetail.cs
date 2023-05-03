using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(DetailTypeId), nameof(ComponentId), IsUnique = true)]
    public class ComponentDetail
    {
        public int Id { get; set; }

        [DisplayName("ИД типа характеристики")]
        public int DetailTypeId { get; set; }

		[DisplayName("Тип характеристики"), JsonIgnore]
		public virtual DetailType? DetailType { get; set; }

        [DisplayName("ИД комплектующего")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее"), JsonIgnore]
        public virtual Component? Component { get; set; }

        [DisplayName("Значение"), StringLength(128)]
        public required string Value { get; set; }
    }
}
