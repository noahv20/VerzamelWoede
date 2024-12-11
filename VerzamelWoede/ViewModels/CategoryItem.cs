using VerzamelWoede.Models;

namespace VerzamelWoede.ViewModels
{
    public class CategoryItem
    {
        public List<Item>? Items { get; set; }   
        public IEnumerable<Category>? Categories { get; set; }
    }
}
