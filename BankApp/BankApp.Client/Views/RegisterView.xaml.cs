using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using BankApp.Client.Utilities;
using BankApp.Client.ViewModels;
using BankApp.Models.Enums;

namespace BankApp.Client.Views
{
    public sealed partial class RegisterView : Page, Observer<RegisterState>
    {
        private readonly RegisterViewModel _viewModel;
        public RegisterView()
        {
            // TODO: implement authentication logic
            this.InitializeComponent();
        }

        public void Update(RegisterState state)
        {
            // TODO: implement update logic
            ;
        }

        public void OnStateChanged(RegisterState state)
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

        private void ClearForm()
        {
            // TODO: implement clear form logic
            ;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        private void GoogleRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement sign in button_ logic
            ;
        }
    }
}