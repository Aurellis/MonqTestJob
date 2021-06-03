using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MonqTestJob
{
    /// <summary>
    /// Класс, реализующий первоначальную конфигурацию сервиса
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конструктор класса Startup
        /// </summary>
        /// <param name="configuration"> Параметры конфигурации </param>
        public Startup(IConfiguration configuration)
        {
            var confBuilder = new ConfigurationBuilder().AddJsonFile("config.json");

            Configuration = confBuilder.Build();
        }


        /// <summary>
        /// Статическое проле текущей конфигурации (для доступа к параметрам из различных классов приложения)
        /// </summary>
        public static IConfiguration Configuration { get; internal set; }

        /// <summary>
        /// Настройка сервисов для приложения
        /// </summary>
        /// <param name="services">Сервисы, необходимые для приложения</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        /// <summary>
        /// Настройка приложения
        /// </summary>
        /// <param name="app">Приложение для настройки</param>
        /// <param name="env">Окружение, в котором развернуто приложение</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
