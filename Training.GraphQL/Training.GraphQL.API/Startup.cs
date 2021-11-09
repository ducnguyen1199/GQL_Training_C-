using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data;
using Training.Data.Repository;
using Training.GraphQL.API.GraphQL.GraphQLSchema;

namespace Training.GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<AppSchema>();
            services
                .AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL<AppSchema>();

            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
}
