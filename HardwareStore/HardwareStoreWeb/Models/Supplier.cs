using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HardwareStoreWeb.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Supplier
    {
        public int Id { get; set; }

        [DisplayName("Название"), StringLength(128)]
        public required string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Supply> Supplies { get; private set; } = new ObservableCollection<Supply>();
    }
}
