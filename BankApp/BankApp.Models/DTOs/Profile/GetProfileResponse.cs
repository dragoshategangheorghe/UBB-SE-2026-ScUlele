using BankApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.DTOs.Profile
{
    public class GetProfileResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProfileInfo? ProfileInfo { get; set; }

        public GetProfileResponse()
        {
            // TODO: load profile response
            ;
        }

        public GetProfileResponse(bool success, string message)
        {
            // TODO: load profile response
            ;
        }

        public GetProfileResponse(bool success, string message, User user)
        {
            // TODO: load profile response
            ;
        }
    }
}