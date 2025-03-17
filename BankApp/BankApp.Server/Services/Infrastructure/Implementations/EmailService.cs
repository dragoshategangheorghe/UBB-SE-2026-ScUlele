using System.Net;
using System.Net.Mail;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BankApp.Server.Services.Infrastructure.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            // TODO: implement email service logic
            ;
        }

        public void sendLockNotification(string email)
        {
            // TODO: implement send lock notification logic
            ;
        }

        public void SendLoginAlert(string email)
        {
            // TODO: implement authentication logic
            ;
        }

        public void sendOTPCode(string email, string code)
        {
            // TODO: implement authentication logic
            ;
        }

        public void sendPasswordResetLink(string email, string token)
        {
            // TODO: implement authentication logic
            ;
        }

        private void SendEmail(string toEmail, string subject, string body)
        {
            // TODO: implement send email logic
            ;
        }
    }
}