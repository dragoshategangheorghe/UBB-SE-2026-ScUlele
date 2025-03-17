using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.Extensions;
using BankApp.Models.Enums;

namespace BankApp.Server.DataAccess
{
    internal class NotificationPreferenceDAO : INotificationPreferenceDAO
    {
        private AppDbContext _appDbContext;
        public NotificationPreferenceDAO(AppDbContext appDbContext)
        {
            // TODO: implement notification preference dao logic
            ;
        }

        public bool Create(int userId, string category)
        {
            // TODO: implement create logic
            return default !;
        }

        public List<NotificationPreference> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        public bool Update(int userId, List<NotificationPreference> prefs)
        {
            // TODO: implement update logic
            return default !;
        }
    }
}