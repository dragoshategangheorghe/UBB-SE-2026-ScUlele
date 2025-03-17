using Microsoft.UI.Xaml.Controls;

namespace BankApp.Client.Master
{
    public class NavigationService : INavigationService
    {
        private Frame? _frame;
        private Frame? _contentFrame;
        public void SetFrame(Frame frame)
        {
            // TODO: implement set frame logic
            ;
        }

        public void SetContentFrame(Frame frame)
        {
            // TODO: implement set content frame logic
            ;
        }

        public void NavigateTo<TPage>()
        {
            // TODO: implement navigate to logic
            ;
        }

        public void NavigateToContent<TPage>()
        {
            // TODO: implement navigate to content logic
            ;
        }

        public void GoBack()
        {
            // TODO: implement go back logic
            ;
        }

        public bool CanGoBack()
        {
            // TODO: implement can go back logic
            return default !;
        }
    }
}