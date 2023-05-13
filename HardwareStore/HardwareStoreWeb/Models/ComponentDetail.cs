using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(DetailTypeId), nameof(ComponentId), IsUnique = true)]
    public class ComponentDetail
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("ИД типа характеристики")]
        public int DetailTypeId { get; set; }

		[DisplayName("Тип характеристики")]
		public virtual DetailType? DetailType { get; set; }

        [DisplayName("ИД комплектующего")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public int ComponentId { get; set; }

        [DisplayName("Комплектующее")]
        public virtual Component? Component { get; set; }

        [DisplayName("Значение")]
        [StringLength(128, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string Value { get; set; }
    }
}
