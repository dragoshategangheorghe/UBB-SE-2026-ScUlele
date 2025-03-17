namespace BankApp.Models.DTOs.Profile
{
    public class ChangePasswordRequest
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;

        public ChangePasswordRequest()
        {
            // TODO: implement authentication logic
            ;
        }

        public ChangePasswordRequest(int userId, string currentPassword, string newPassword)
        {
            // TODO: implement authentication logic
            ;
        }
    }
}