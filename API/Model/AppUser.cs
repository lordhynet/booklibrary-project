using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProjectBookLibraryApi.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(15, ErrorMessage = "Must be between 3 and 15")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Must be between 3 and 15")]
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; }
        public List<Photo> Photos { get; set; }

        public AppUser()
        {

            Address = new Address();
            Photos = new List<Photo>();

        }


    }
}
