using _1lab.Extensions;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq.Expressions;
using WebApplication1.Extensions;
namespace ShopApi;
public class Startup
{
    [Obsolete]
    public Startup(IConfiguration configuration)
    {
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureCors();
        services.ConfigureIISIntegration();
        services.ConfigureLoggerService();
        services.ConfigureSqlContext(Configuration);
        services.ConfigureRepositoryManager();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(Startup));
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ConfigureExceptionHandler((Contracts.ILoggerManager)logger);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool
       trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
[Route("[controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    public WeatherForecastController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        _repository.Company.AnyMethodFromCompanyRepository();
        _repository.Employee.AnyMethodFromEmployeeRepository();
        return new string[] { "value1", "value2" };
    }

}




