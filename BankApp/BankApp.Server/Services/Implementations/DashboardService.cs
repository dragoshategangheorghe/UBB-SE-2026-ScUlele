using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Server.Services.Interfaces;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Models.DTOs.Dashboard;

namespace BankApp.Server.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IUserRepository _userRepository;
        public DashboardService(IDashboardRepository dashboardRepository, IUserRepository userRepository)
        {
            // TODO: implement dashboard service logic
            ;
        }

        public DashboardResponse GetDashboardData(int id)
        {
            // TODO: load dashboard data
            return default !;
        }
    }
}