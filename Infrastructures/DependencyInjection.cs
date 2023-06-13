﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures;

public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(config.GetConnectionString("CarManagementDB")));
            return services;
        }
    }
