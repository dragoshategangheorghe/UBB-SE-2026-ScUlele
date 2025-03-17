using BankApp.Client.Utilities;
using BankApp.Client.ViewModels.Base;
using BankApp.Models.DTOs.Profile;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Text.Core;

namespace BankApp.Client.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private bool _disposed;
        public Observable<ProfileState> State { get; private set; }
        public ProfileInfo ProfileInfo { get; private set; }
        public List<OAuthLink> OAuthLinks { get; private set; }
        public List<Session> ActiveSessions { get; private set; }
        public List<NotificationPreference> NotificationPreferences { get; private set; }

        public ProfileViewModel(ApiService apiService)
        {
            // TODO: implement profile view model logic
            ;
        }

        public async Task<bool> LoadProfile()
        {
            // TODO: load profile
            return default !;
        }

        public async Task<bool> UpdatePersonalInfo(string phone, string address, string password)
        {
            // TODO: implement update personal info logic
            return default !;
        }

        public async Task<bool> ChangePassword(string currentPassword, string newPassword)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public async Task<bool> EnableTwoFactor(TwoFactorMethod method)
        {
            // TODO: implement enable two factor logic
            return default !;
        }

        public async Task<bool> DisableTwoFactor()
        {
            // TODO: implement disable two factor logic
            return default !;
        }

        public async Task<bool> LinkOAuth(string provider)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public async Task<bool> UnlinkOAuth(string provider)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public async Task<bool> UpdateNotificationPreferences(List<NotificationPreference> preferences)
        {
            // TODO: implement update notification preferences logic
            return default !;
        }

        public async Task<bool> VerifyPassword(string password)
        {
            // TODO: validate password
            return default !;
        }

        public override void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }

        private void LogError(string method, Exception ex)
        {
            // TODO: implement log error logic
            ;
        }
    }
}