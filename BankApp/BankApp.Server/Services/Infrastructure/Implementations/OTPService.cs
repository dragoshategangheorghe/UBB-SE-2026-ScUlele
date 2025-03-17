using System.Security.Cryptography;
using System.Text;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BankApp.Server.Services.Infrastructure.Implementations
{
    public class OTPService : IOTPService
    {
        private static readonly Dictionary<int, (string Code, DateTime ExpiryTime)> _temporarySmsStorage;
        private const int SmsOtpExpiryMinutes = 5;
        private const int TotpWindowSeconds = 300;
        public OTPService()
        {
            // TODO: implement authentication logic
            ;
        }

        public string GenerateSMSOTP(int userId)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public string GenerateTOTP(int userId)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public void InvalidateOTP(int userId)
        {
            // TODO: implement authentication logic
            ;
        }

        public bool IsExpired(DateTime expiredAt)
        {
            // TODO: implement is expired logic
            return default !;
        }

        public bool VerifySMSOTP(int userId, string code)
        {
            // TODO: validate smsotp
            return default !;
        }

        public bool VerifyTOTP(int userId, string code)
        {
            // TODO: validate totp
            return default !;
        }

        private string GenerateHmacCode(int userId, long timeWindow)
        {
            // TODO: implement generate hmac code logic
            return default !;
        }
    }
}