using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class NotificationDAO : INotificationDAO
    {
        private readonly AppDbContext _dbContext;
        public NotificationDAO(AppDbContext dbContext)
        {
            // TODO: implement notification dao logic
            ;
        }

        public int CountUnreadByUserId(int userId)
        {
            // TODO: implement count unread by user id logic
            return default !;
        }

        public List<Notification> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        private Notification MapToNotification(System.Data.IDataReader r)
        {
            // TODO: implement map to notification logic
            return default !;
        }
    }
}