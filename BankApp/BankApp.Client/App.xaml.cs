using BankApp.Client.Master;
using BankApp.Client.Services.Implementations;
using BankApp.Client.Services.Interfaces;
using BankApp.Client.State;
using BankApp.Client.Utilities;
using Microsoft.UI.Xaml;

namespace BankApp.Client
{
    public partial class App : Application
    {
        public static ApiService ApiService { get; private set; };
        public static NavigationService NavigationService { get; private set; };
        public static ICardApiService CardApiService { get; private set; };
        public static ITransactionApiService TransactionApiService { get; private set; };
        public static IStatisticsApiService StatisticsApiService { get; private set; };
        public static ITransactionHistorySessionState TransactionHistorySessionState { get; private set; };

        private Window? _window;
        public App()
        {
            // TODO: implement app logic
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // TODO: implement on launched logic
            ;
        }
    }
}