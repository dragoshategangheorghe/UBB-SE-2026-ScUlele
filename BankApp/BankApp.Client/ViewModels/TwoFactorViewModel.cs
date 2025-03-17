using System;
using System.Threading.Tasks;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Auth;
using BankApp.Models.Enums;

namespace BankApp.Client.ViewModels
{
    public class TwoFactorViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public Observable<TwoFactorState> State { get; private set; }

        public TwoFactorViewModel(ApiService apiService)
        {
            // TODO: implement two factor view model logic
            ;
        }

        public async Task VerifyOTP(string otp)
        {
            // TODO: validate otp
            ;
        }

        public async Task ResendOTP()
        {
            // TODO: implement authentication logic
            ;
        }

        public override void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}