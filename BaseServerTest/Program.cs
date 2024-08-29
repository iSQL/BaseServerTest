using BaseServerTest.Components;
using BaseServerTest.Components.Account;
using BaseServerTest.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Devexpress.Blazor;
using DevExpress.Blazor;
using BaseServerTest.Contracts.Services;
using BaseServerTest.Services;
using BaseServerTest.Contracts.Repositories;
using BaseServerTest.Repositories;
using BaseServerTest.State;
using System;
using BaseServerTest.Misc;
using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Repositories.Classifieds;
using BaseServerTest.Services.Classifieds;
namespace BaseServerTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
            builder.Services.AddMvc();
            builder.Services.AddSignalR();


            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
               // options.UseSqlServer(connectionString));

            builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(
            builder.Configuration["ConnectionStrings:DefaultConnection"]));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
            builder.Services.AddScoped<IAppointmentDataService, AppointmentDataService>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // ClassifiedsRepository registrations
            builder.Services.AddScoped<IClassifiedAdRepository, ClassifiedAdRepository>();
            builder.Services.AddScoped<IClassifiedUserRepository, ClassifiedUserRepository>();
            builder.Services.AddScoped<IClassifiedMessageRepository, ClassifiedMessageRepository>();

            // Classifieds Service registrations
            builder.Services.AddScoped<IClassifiedAdService, ClassifiedAdService>();
            builder.Services.AddScoped<IClassifiedUserService, ClassifiedUserService>();
            builder.Services.AddScoped<IClassifiedMessageService, ClassifiedMessageService>();

            builder.Services.AddScoped<ApplicationState>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();
            app.MapHub<ChatHub>("/chathub");
            app.Run();
        }
    }
}
