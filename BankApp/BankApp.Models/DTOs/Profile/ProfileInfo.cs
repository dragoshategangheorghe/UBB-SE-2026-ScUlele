using BankApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.DTOs.Profile
{
    public class ProfileInfo
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public bool Is2FAEnabled { get; set; }

        public ProfileInfo()
        {
            // TODO: implement profile info logic
            ;
        }

        public ProfileInfo(User user)
        {
            // TODO: implement profile info logic
            ;
        }
    }
}