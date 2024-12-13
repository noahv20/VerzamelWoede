using System.ComponentModel.DataAnnotations;

namespace VerzamelWoede.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(400)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Worth {  get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int? Year { get; set; }
        [Required]
        public DateTime CollectionDate { get; set; }
        public string? ImageFileName { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Collection>? Collections { get; set; } = new List<Collection>();
    }
}
