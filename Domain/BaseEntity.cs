using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BaseEntity
    
    {    
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    }
}