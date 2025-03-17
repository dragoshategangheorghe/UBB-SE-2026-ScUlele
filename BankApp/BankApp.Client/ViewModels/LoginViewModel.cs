using BankApp.Client.Utilities;
using BankApp.Client.ViewModels.Base;
using BankApp.Models.DTOs.Auth;
using BankApp.Models.Enums;
using Duende.IdentityModel.OidcClient;
using System;
using System.Threading.Tasks;

namespace BankApp.Client.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Observable<LoginState> State { get; private set; }

        private readonly ApiService _apiService;
        public LoginViewModel(ApiService apiService)
        {
            // TODO: implement authentication logic
            ;
        }

        public async void Login(string email, string password)
        {
            // TODO: implement authentication logic
            ;
        }

        public async void OAuthLogin(string email, string provider)
        {
            // TODO: implement authentication logic
            ;
        }

        private void HandleLoginError(LoginResponse response)
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