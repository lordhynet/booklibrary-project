﻿using System.ComponentModel.DataAnnotations;

namespace PersonalProjectBookLibraryApi.Model
{
    public class Address
    {
        [Key]
        public string AppUserId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public AppUser AppUser { get; set; }

    }
}
