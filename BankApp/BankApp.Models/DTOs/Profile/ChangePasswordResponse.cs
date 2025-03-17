using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.DTOs.Profile
{
    public class ChangePasswordResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public ChangePasswordResponse()
        {
            // TODO: implement authentication logic
            ;
        }

        public ChangePasswordResponse(bool success, string? message)
        {
            // TODO: implement authentication logic
            ;
        }
    }
}