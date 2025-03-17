using BankApp.Client.Utilities;
using BankApp.Client.ViewModels.Base;
using BankApp.Models.Enums;
using BankApp.Models.DTOs.Auth;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace BankApp.Client.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Observable<RegisterState> State { get; private set; }

        private readonly ApiService _apiService;
        public RegisterViewModel(ApiService apiService)
        {
            // TODO: implement authentication logic
            ;
        }

        public async void Register(string email, string password, string confirmPassword, string fullName)
        {
            // TODO: implement authentication logic
            ;
        }

        public async void OAuthRegister(string email, string provider)
        {
            // TODO: implement authentication logic
            ;
        }

        private RegisterState? ValidateLocally(string email, string password, string confirmPassword, string fullName)
        {
            // TODO: validate locally
            return default !;
        }

        private void HandleRegisterError(RegisterResponse response)
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