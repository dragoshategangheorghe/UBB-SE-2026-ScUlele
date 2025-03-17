namespace BankApp.Models.DTOs.Profile
{
    public class UpdateProfileRequest
    {
        public int? UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public UpdateProfileRequest()
        {
            // TODO: implement update profile request logic
            ;
        }

        public UpdateProfileRequest(int? userId, string? phoneNumber, string? address)
        {
            // TODO: implement update profile request logic
            ;
        }
    }
}