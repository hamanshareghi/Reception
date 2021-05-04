using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using DataAccess.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });


            services.AddScoped<IBrand, BrandService>();
            services.AddScoped<ICarousel, CarouselService>();
            services.AddScoped<IFaq, FaqService>();
            services.AddScoped<IMessage, MessageService>();
            services.AddScoped<IOneData,OneDatatService>();
            services.AddScoped<IProduct, ProductService>();
            services.AddScoped<IProductGroup, ProductGroupService>();
            services.AddScoped<IRule,RuleService>();
            services.AddScoped<IVideo, VideoService>();
            services.AddScoped<IDefect, DefectService>();
            services.AddScoped<IService, ServicesService>();
            services.AddScoped<IStatus, StatusService>();
            services.AddScoped<IReception, ReceptionService>();
            services.AddScoped<ICostDefine, CostDefineService>();
            services.AddScoped<ICost, CostService>();
            services.AddScoped<ILeave, LeaveService>();
            services.AddScoped<IShipping, ShippingService>();
            services.AddScoped<IDebtor, DebtorService>();
            services.AddScoped<IDuty, DutyService>();
            services.AddScoped<IRequestDevice, RequestDeviceService>();
            services.AddScoped<ITicket, TicketService>();
            services.AddScoped<ICustomer, CustomerService>();
            services.AddScoped<IDeviceDefect, DeviceDefectService>();
            services.AddScoped<IPayment, PaymentService>();
            services.AddScoped<IAllMessage, AllMessageService>();
            services.AddScoped<ISale, SaleService>();
            services.AddScoped<IPayType, PayTypeService>();


            #region Authorization

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    option =>
                    {
                        option.LoginPath = "~/Account/Login";
                        option.LogoutPath = "~/Account/Logout";
                        option.ExpireTimeSpan = TimeSpan.FromDays(10);
                    });
            services.AddIdentity<ApplicationUser, ApplicationRole>()

                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityError>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
