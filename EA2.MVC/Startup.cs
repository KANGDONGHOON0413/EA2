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
            //의존성 주입 방법 3가지
            //1.services.AddSingleton<T>();     --> 프로그램(웹사이트)이 시작되면 끝날때까지 메모리상에 유지되는 객체 주입
            //2.services.AddScoped<T>();        --> 프로그램이 시작된 후 1번의 요청이 있을때 메모리상에 유지되는 객체 주입
            //3.services.AddTransient<T>();     -->요청이 있을 때 마다 새롭게 객체를 생성, 가벼운 코드에 적합 ==> 대부분의 경우 Transient사용
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
