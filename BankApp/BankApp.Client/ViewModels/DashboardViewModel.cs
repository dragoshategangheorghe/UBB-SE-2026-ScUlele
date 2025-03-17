using BankApp.Client.Utilities;
using BankApp.Client.ViewModels.Base;
using BankApp.Models.DTOs.Dashboard;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using System;
using System.Collections.Generic;

namespace BankApp.Client.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public Observable<DashboardState> State { get; private set; }
        public User CurrentUser { get; private set; }
        public List<Card> Cards { get; private set; }
        public List<Transaction> RecentTransactions { get; private set; }
        public int UnreadNotificationCount { get; private set; }

        private readonly ApiService _apiService;
        public DashboardViewModel(ApiService apiService)
        {
            // TODO: implement dashboard view model logic
            ;
        }

        public async void LoadDashboard()
        {
            // TODO: load dashboard
            ;
        }

        public override void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}