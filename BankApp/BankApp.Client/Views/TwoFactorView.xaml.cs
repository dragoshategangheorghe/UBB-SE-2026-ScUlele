using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using BankApp.Client.Utilities;
using BankApp.Client.ViewModels;
using BankApp.Models.Enums;

namespace BankApp.Client.Views
{
    public sealed partial class TwoFactorView : Page, Observer<TwoFactorState>
    {
        private readonly TwoFactorViewModel _viewModel;
        private DispatcherTimer _countdownTimer;
        private int _secondsRemaining = 30;
        public TwoFactorView()
        {
            // TODO: implement two factor view logic
            this.InitializeComponent();
            _countdownTimer.Tick += CountdownTimer_Tick;
        }

        public void Update(TwoFactorState state)
        {
            // TODO: implement update logic
            ;
        }

        public void OnStateChanged(TwoFactorState state)
        {
            // TODO: implement on state logic
            ;
        }

        public void ShowError(string msg)
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

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: validate button_
            ;
        }

        private async void ResendButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement resend button_ logic
            ;
        }

        private void CountdownTimer_Tick(object sender, object e)
        {
            // TODO: implement countdown timer_ logic
            ;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }
    }
}