using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication_MongoDb_Example.Models
{
    public class TodoItem : MongoDbEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
