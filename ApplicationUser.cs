﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BooksSpring2024_sec02
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public  string? StreetAddress { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? State { get; set; }
    }
}
