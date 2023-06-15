using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace glasnost_back.Entities
{
    public class BaseEntity
    {
        [NotMapped]
        [JsonIgnore]
        public EntityState PreviousState { get; set; }
    }
}
