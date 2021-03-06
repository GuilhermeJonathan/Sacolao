using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sacolao.Aplicacao.ComunicacaoViaHttp;
using Sacolao.Aplicacao.GestaoDeCarrinhos;
using Sacolao.Aplicacao.GestaoDeFrutas;
using Sacolao.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Web
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
            services.AddHttpClient<IServicoDeGestaoDeFrutas, ServicoDeGestaoDeFrutas>();
            services.AddHttpClient<IServicoDeComunicacaoViaHttp, ServicoDeComunicacaoViaHttp>();
            
            services.Configure<MyConfiguration>(Configuration.GetSection("APIs:urlApi"));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IServicoDeGestaoDeFrutas>(service => new ServicoDeGestaoDeFrutas(
                Configuration.GetSection("APIs:urlApi").Value, new ServicoDeComunicacaoViaHttp()));
            
            services.AddSingleton<IServicoDeGestaoDeCarrinhos>(service => new ServicoDeGestaoDeCarrinhos(
                Configuration.GetSection("APIs:urlApi").Value, new ServicoDeComunicacaoViaHttp()));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
