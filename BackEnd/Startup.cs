using BackEnd.Core.IRepository;
using BackEnd.Core.IService;
using BackEnd.Services;
using BackEnd.Services.Customer;
using BackEnd.Services.Order;
using DbConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace BackEnd
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
           

            var connectionString = Configuration.GetConnectionString("DB");
            services.AddTransient<IDbConnection>((sp) =>
           new SqlConnection(this.Configuration.GetConnectionString("DB"))
           );

            #region Depandency Inject
            services.AddTransient<IDBContext, DBContext>();
            services.AddTransient<IUnitOfWork, UnitOfWorkClass>();
            services.AddTransient<IDisposable, UnitOfWorkClass>();
            services.AddTransient<IApplicationCustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomer, CustomerService>();
            services.AddTransient<IApplicationOrderRepository, OrderRepository>();
            services.AddTransient<IOrder, OrderService>();
            #endregion

            services.DatabaseConfiguration(Configuration);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
