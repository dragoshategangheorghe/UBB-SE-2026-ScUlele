using BankApp.Client.ViewModels;
using System.ComponentModel;
using System.Globalization;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BankApp.Client.Views
{
    public sealed partial class StatisticsView : Page
    {
        public StatisticsView()
        {
            // TODO: implement statistics view logic
            InitializeComponent();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            Loaded += StatisticsView_Loaded;
            Unloaded += StatisticsView_Unloaded;
        }

        public StatisticsViewModel ViewModel { get; }

        private async void StatisticsView_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: implement statistics view_ logic
            ;
        }

        private void StatisticsView_Unloaded(object sender, RoutedEventArgs e)
        {
            // TODO: implement statistics view_ logic
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // TODO: implement view model_property logic
            ;
        }

        private void UpdateSummaryValues()
        {
            // TODO: implement update summary values logic
            ;
        }

        private static string FormatCurrency(decimal value)
        {
            // TODO: implement format currency logic
            return default !;
        }
    }
}