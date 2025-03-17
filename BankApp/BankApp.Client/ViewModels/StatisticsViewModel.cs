using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Client.Commands;
using BankApp.Client.Services.Interfaces;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Statistics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BankApp.Client.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private readonly IStatisticsApiService _statisticsApiService;
        private readonly AsyncRelayCommand _refreshCommand;
        private bool _isLoading;
        private bool _isStatusOpen;
        private InfoBarSeverity _statusSeverity;
        private string _statusMessage = string.Empty;
        private decimal _income;
        private decimal _expenses;
        private decimal _net;
        private decimal _totalSpending;
        private double _maxCategoryAmount = 1;
        private double _maxBalanceAmount = 1;
        private double _maxTopRecipientAmount = 1;
        public StatisticsViewModel(IStatisticsApiService statisticsApiService)
        {
            // TODO: implement statistics view model logic
            ;
        }

        public ObservableCollection<CategorySpendingPointDto> SpendingByCategory { get; }
        public ObservableCollection<BalanceTrendPointDto> BalanceTrends { get; }
        public ObservableCollection<TopCounterpartyDto> TopRecipients { get; }

        public AsyncRelayCommand RefreshCommand
        {
            get
            {
                // TODO: implement refresh command logic
                return default !;
            }
        }

        public bool IsLoading
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public Visibility LoadingVisibility
        {
            get
            {
                // TODO: implement loading visibility logic
                return default !;
            }
        }

        public bool IsStatusOpen
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public string StatusMessage
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public InfoBarSeverity StatusSeverity
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public decimal Income
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public decimal Expenses
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public decimal Net
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public decimal TotalSpending
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public double MaxCategoryAmount
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public double MaxBalanceAmount
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public double MaxTopRecipientAmount
        {
            get
            {
                // TODO: implement get logic
                return default !;
            }

            set
            {
                // TODO: implement set logic
                ;
            }
        }

        public async Task LoadAsync()
        {
            // TODO: load load
            ;
        }

        private void ShowStatus(string message, InfoBarSeverity severity)
        {
            // TODO: update the UI
            ;
        }

        private static void ReplaceCollection<T>(ObservableCollection<T> target, IEnumerable<T> source)
        {
            // TODO: implement replace collection logic
            ;
        }

        public override void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}