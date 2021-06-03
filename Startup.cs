using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MonqTestJob
{
    /// <summary>
    /// �����, ����������� �������������� ������������ �������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ����������� ������ Startup
        /// </summary>
        /// <param name="configuration"> ��������� ������������ </param>
        public Startup(IConfiguration configuration)
        {
            var confBuilder = new ConfigurationBuilder().AddJsonFile("config.json");

            Configuration = confBuilder.Build();
        }


        /// <summary>
        /// ����������� ����� ������� ������������ (��� ������� � ���������� �� ��������� ������� ����������)
        /// </summary>
        public static IConfiguration Configuration { get; internal set; }

        /// <summary>
        /// ��������� �������� ��� ����������
        /// </summary>
        /// <param name="services">�������, ����������� ��� ����������</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        /// <summary>
        /// ��������� ����������
        /// </summary>
        /// <param name="app">���������� ��� ���������</param>
        /// <param name="env">���������, � ������� ���������� ����������</param>
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
