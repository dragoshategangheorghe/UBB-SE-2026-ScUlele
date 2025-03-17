using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using BankApp.Client.Utilities;
using BankApp.Client.ViewModels;
using BankApp.Models.Enums;

namespace BankApp.Client.Views
{
    public sealed partial class LoginView : Page, Observer<LoginState>
    {
        private readonly LoginViewModel _viewModel;
        public LoginView()
        {
            // TODO: implement authentication logic
            this.InitializeComponent();
        }

        public void Update(LoginState state)
        {
            // TODO: implement update logic
            ;
        }

        public void OnStateChanged(LoginState state)
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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement sign in button_ logic
            ;
        }

        private void GoogleLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement create account button_ logic
            ;
        }
    }
}