using BankApp.Client.ViewModels;
using BankApp.Models.DTOs.Transactions;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BankApp.Client.Views
{
    public sealed partial class TransactionHistoryView : Page
    {
        public TransactionHistoryView()
        {
            // TODO: implement transaction history view logic
            InitializeComponent();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            Loaded += TransactionHistoryView_Loaded;
            Unloaded += TransactionHistoryView_Unloaded;
        }

        public TransactionHistoryViewModel ViewModel { get; }

        private async void TransactionHistoryView_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: implement transaction history view_ logic
            ;
        }

        private void TransactionHistoryView_Unloaded(object sender, RoutedEventArgs e)
        {
            // TODO: implement transaction history view_ logic
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        private void TransactionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: implement transactions list_selection logic
            ;
        }

        private void TransactionsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // TODO: implement transactions list_item logic
            ;
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // TODO: implement view model_property logic
            ;
        }

        private void SetSelectedTransaction(TransactionHistoryItemDto? transaction)
        {
            // TODO: implement set selected transaction logic
            ;
        }

        private void UpdateDetailsPanel(TransactionHistoryItemDto? transaction)
        {
            // TODO: implement update details panel logic
            ;
        }

        private static string FormatDateTime(DateTime? value)
        {
            // TODO: implement format date time logic
            return default !;
        }

        private static string FormatDecimal(decimal? value)
        {
            // TODO: implement format decimal logic
            return default !;
        }
    }
}