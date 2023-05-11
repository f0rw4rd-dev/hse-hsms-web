using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ComponentType
    {
		[DisplayName("ИД")]
		public int Id { get; set; }

        [DisplayName("Название")]
        [StringLength(64, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringLength")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
        public required string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Component> Components { get; private set; } = new ObservableCollection<Component>();
    }
}
