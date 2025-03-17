using BankApp.Client.Utilities;
using BankApp.Client.ViewModels;
using BankApp.Models.Enums;
using BankApp.Models.Entities;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using Windows.UI;
using System.Threading.Tasks;

namespace BankApp.Client.Views
{
    public sealed partial class DashboardView : Page, Observer<DashboardState>
    {
        private readonly DashboardViewModel _viewModel;
        private int _currentCardIndex = 0;
        public DashboardView()
        {
            // TODO: implement dashboard view logic
            this.InitializeComponent();
        }

        public void Update(DashboardState state)
        {
            // TODO: implement update logic
            ;
        }

        public void OnStateChanged(DashboardState state)
        {
            // TODO: implement on state logic
            ;
        }

        private void RefreshUI()
        {
            // TODO: implement refresh ui logic
            ;
        }

        private void ShowCard(int index)
        {
            // TODO: update the UI
            ;
        }

        private void BuildCardDots()
        {
            // TODO: implement build card dots logic
            ;
        }

        private void UpdateCardDots()
        {
            // TODO: implement update card dots logic
            ;
        }

        private void PrevCardButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement prev card button_ logic
            ;
        }

        private void NextCardButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement next card button_ logic
            ;
        }

        private async void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement transfer button_ logic
            ;
        }

        private async void PayBillButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement pay bill button_ logic
            ;
        }

        private async void ExchangeButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement exchange button_ logic
            ;
        }

        private async void TxHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement tx history button_ logic
            ;
        }

        private void ShowError(string msg)
        {
            // TODO: update the UI
            ;
        }

        private async System.Threading.Tasks.Task ShowAlertAsync(string title, string message)
        {
            // TODO: update the UI
            ;
        }

        private async void CardVisual_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // TODO: implement card visual_pointer pressed logic
            ;
        }

        private void ShowLoading()
        {
            // TODO: update the UI
            ;
        }

        private void HideLoading()
        {
            // TODO: update the UI
            ;
        }
    }
}