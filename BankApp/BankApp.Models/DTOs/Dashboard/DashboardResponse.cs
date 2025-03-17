using BankApp.Models.Entities;

namespace BankApp.Models.DTOs.Dashboard
{
    public class DashboardResponse
    {
        public User CurrentUser { get; set; }
        public List<Card> Cards { get; set; };
        public List<Transaction> RecentTransactions { get; set; };
        public int UnreadNotificationCount { get; set; }
    }
}