using System;
using System.Threading.Tasks;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Auth;
using BankApp.Models.Enums;

namespace BankApp.Client.ViewModels
{
    public class ApiResponse
    {
        public string? message { get; set; }
        public string? error { get; set; }
    }

    public class ForgotPasswordViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public Observable<ForgotPasswordState> State { get; private set; }

        public ForgotPasswordViewModel(ApiService apiService)
        {
            // TODO: implement authentication logic
            ;
        }

        public async Task ForgotPassword(string email)
        {
            // TODO: implement authentication logic
            ;
        }

        public async Task ResetPassword(string email, string newPassword, string code)
        {
            // TODO: implement authentication logic
            ;
        }

        public async Task VerifyToken(string code)
        {
            // TODO: validate token
            ;
        }

        public override void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}