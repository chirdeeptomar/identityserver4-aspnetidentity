using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auth.Server
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}