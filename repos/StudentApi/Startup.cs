using AutoMapper;
using AutoMapperProfile;
using IManager;
using IRepository;
using IRepository.Data;
using IRepository.Models;
using Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using StudentApi.GlobalException;

namespace StudentApi
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
            services.AddControllers();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperSetProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddDbContext<TestDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbString")));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentManager, StudentManager>();
            services.AddTransient<IStudentMentorManager, StudentMentorManager>();
            services.AddTransient<IStudentMentorRepository, StudentMentorRepository>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            /*app.ConfigureExceptionHandler(env);*/

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

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
