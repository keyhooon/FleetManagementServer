﻿using System;
using FleetManagementServer.Areas.Identity.Data;
using FleetManagementServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FleetManagementServer.Areas.Identity.VehicleHostingStartup))]
namespace FleetManagementServer.Areas.Identity
{
    public class VehicleHostingStartup : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AccountDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AccountDbContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<AccountDbContext>();
                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit           = true;
                    options.Password.RequireLowercase       = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase       = true;
                    options.Password.RequiredLength         = 6;
                    options.Password.RequiredUniqueChars    = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan  = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers      = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                });

                services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan  = TimeSpan.FromMinutes(5);

                    options.LoginPath         = "/Identity/Account/Login";
                    options.AccessDeniedPath  = "/Identity/Account/AccessDenied";
                    options.SlidingExpiration = true;
                });

            });
        }
    }
}