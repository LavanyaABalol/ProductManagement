using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductManagementDBContext;
using ProductManagementRepo;
using ProductManagementService;

namespace ProductManagement
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
            //Provide options for DbContext
            //Register all dependencies here
            var connectionString = Configuration.GetConnectionString("myDb");
            services.AddDbContext<EFDBcontext>(options => options.UseSqlServer(connectionString));


            services.AddScoped<ProductManagementService.IProductManagementService, ProductManagementService.ProductManagementService>();
            services.AddScoped<ProductManagementRepo.IProductManagementRepo, ProductManagementRepo.ProductManagementRepo>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductManagement", Version = "v1" });
            });

            //   services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductManagement v1"));
            }

            //app.Run(context => {
            //    throw new Exception("error");
            //    //cgi_tollgate_assignment_book_api.Exceptions.BookNotFoundException("error");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
 }

