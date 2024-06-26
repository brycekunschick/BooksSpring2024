using BooksSpring2024_sec02.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;

namespace BooksSpring2024_sec02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //1) fetch the information about the connection string
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");

            //2) Add the context class to the set of services and define the option to use SQL Server on that connection string that has been fetched in the previous line
            builder.Services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(connString));


            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));



            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<BooksDBContext>().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });



            builder.Services.AddRazorPages();



            builder.Services.AddScoped<IEmailSender, EmailSender>(); //this is just to avoid an error

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();


            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();






            app.MapControllerRoute(
                name: "default",
                pattern: "{Area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
