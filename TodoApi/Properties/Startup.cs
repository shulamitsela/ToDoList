namespace TodoApi.Properties
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // הוספת שירותים נוספים
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // קוד נוסף
        }
    }

}
