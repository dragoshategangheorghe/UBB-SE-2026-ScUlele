using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using BankApp.Client.Utilities;
using BankApp.Client.ViewModels;
using BankApp.Models.Enums;

namespace BankApp.Client.Views
{
    public sealed partial class ForgotPasswordView : Page, Observer<ForgotPasswordState>
    {
        private readonly ForgotPasswordViewModel _viewModel;
        public ForgotPasswordView()
        {
            // TODO: implement authentication logic
            this.InitializeComponent();
        }

        public void Update(ForgotPasswordState state)
        {
            // TODO: implement update logic
            ;
        }

        public void OnStateChanged(ForgotPasswordState state)
        {
            // TODO: implement on state logic
            ;
        }

        private async void SendCodeButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement send code button_ logic
            ;
        }

        private async void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        private async void VerifyTokenButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: validate button_
            ;
        }

        private async void ResendCodeButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement resend code button_ logic
            ;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        public void ShowMessage(string msg, InfoBarSeverity severity)
        {
            // TODO: update the UI
            ;
        }

        public void ShowLoading()
        {
            // TODO: update the UI
            ;
        }

        public void HideLoading()
        {
            // TODO: update the UI
            ;
        }
    }
}