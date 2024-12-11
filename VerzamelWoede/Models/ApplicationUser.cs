using Microsoft.AspNetCore.Identity;

namespace VerzamelWoede.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Collection>? Collections { get; set; }
    }
}
