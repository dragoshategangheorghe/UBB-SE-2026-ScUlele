using BankApp.Client.Utilities;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;

namespace BankApp.Client.Views
{
    public sealed partial class NavView : Page
    {
        private Button _activeNavButton;
        private readonly List<Button> _navButtons;
        public NavView()
        {
            // TODO: implement nav view logic
            this.InitializeComponent();
        }

        private void SetActiveNav(Button selected)
        {
            // TODO: implement set active nav logic
            ;
        }

        public void UpdateNotificationBadge(int count)
        {
            // TODO: implement update notification badge logic
            ;
        }

        private void NavDashboard_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav dashboard_ logic
            ;
        }

        private void NavProfile_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav profile_ logic
            ;
        }

        // All other nav items show a coming soon alert
        private async void NavTransfers_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav transfers_ logic
            ;
        }

        private async void NavBillPayments_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav bill payments_ logic
            ;
        }

        private void NavCards_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav cards_ logic
            ;
        }

        private void NavTransferHistory_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav transfer history_ logic
            ;
        }

        private async void NavCurrencyExchange_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav currency exchange_ logic
            ;
        }

        private async void NavSavings_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav savings_ logic
            ;
        }

        private async void NavInvestments_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav investments_ logic
            ;
        }

        private void NavStatistics_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav statistics_ logic
            ;
        }

        private async void NavSupport_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement nav support_ logic
            ;
        }

        private async System.Threading.Tasks.Task ShowComingSoonAsync(string feature)
        {
            // TODO: update the UI
            ;
        }

        private void NotificationBell_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // TODO: implement notification bell_pointer pressed logic
            ;
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement authentication logic
            ;
        }
    }
}