using EA2.BLL;
using EA2.DAL;
using EA2.IDAL;
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

namespace EA2.MVC
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
            //������ ���� ��� 3����
            //1.services.AddSingleton<T>();     --> ���α׷�(������Ʈ)�� ���۵Ǹ� ���������� �޸𸮻� �����Ǵ� ��ü ����
            //2.services.AddScoped<T>();        --> ���α׷��� ���۵� �� 1���� ��û�� ������ �޸𸮻� �����Ǵ� ��ü ����
            //3.services.AddTransient<T>();     -->��û�� ���� �� ���� ���Ӱ� ��ü�� ����, ������ �ڵ忡 ���� ==> ��κ��� ��� Transient���
            services.AddTransient<UserBLL>();
            services.AddTransient<UserIDAL, UserDAl>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
