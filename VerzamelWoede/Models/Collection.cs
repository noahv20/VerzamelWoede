using System.ComponentModel.DataAnnotations;

namespace VerzamelWoede.Models
{
    public class Collection
    {
        public int? ItemId {  get; set; }
        public Item? Item { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
