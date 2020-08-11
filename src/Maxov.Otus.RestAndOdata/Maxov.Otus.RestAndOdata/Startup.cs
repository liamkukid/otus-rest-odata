using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FastExpressionCompiler;
using Mapster;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.BLL.Abstractions.Services;
using Maxov.Otus.RestAndOdata.BLL.Models;
using Maxov.Otus.RestAndOdata.BLL.Services;
using Maxov.Otus.RestAndOdata.DAL;
using Maxov.Otus.RestAndOdata.DAL.Abstractions.Repositories;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;
using Maxov.Otus.RestAndOdata.DAL.Repositories;
using Maxov.Otus.RestAndOdata.ErrorHandling;
using Maxov.Otus.RestAndOdata.ViewModels;
using Maxov.Otus.RestAndOdata.ViewModels.BeforeV3;
using Maxov.Otus.RestAndOdata.ViewModels.V3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Maxov.Otus.RestAndOdata
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
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddApiVersioning(x =>  
            {  
                x.DefaultApiVersion = new ApiVersion(1, 0);  
                x.AssumeDefaultVersionWhenUnspecified = true;  
                x.ReportApiVersions = true;  
            });

            services.AddSingleton<FootballManagerDbContext>();
            services.AddSingleton<IRepository<long, ChampionshipEntity>, ChampionshipsRepository>();

            services.AddSingleton<IChampionshipService, ChampionshipService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "Football Manager API v1.0",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Maxim Ovchinnikov",
                        Email = "footballmanager@ovchinnikov.ma",
                        Url = new Uri("https://www.facebook.com/max.ovchinnikov/")
                    }
                });
                
                c.SwaggerDoc("2.0", new OpenApiInfo
                {
                    Version = "2.0",
                    Title = "Football Manager API v2.0",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Maxim Ovchinnikov",
                        Email = "footballmanager@ovchinnikov.ma",
                        Url = new Uri("https://www.facebook.com/max.ovchinnikov/")
                    }
                });
                
                c.SwaggerDoc("3.0", new OpenApiInfo
                {
                    Version = "3.0",
                    Title = "Football Manager API v3.0",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Maxim Ovchinnikov",
                        Email = "footballmanager@ovchinnikov.ma",
                        Url = new Uri("https://www.facebook.com/max.ovchinnikov/")
                    }
                });
                
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                
                c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
            });

            RegisterCommonMapping(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpMethodOverride();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Football Manager V1.0");
                c.SwaggerEndpoint("/swagger/2.0/swagger.json", "Football Manager V2.0");
                c.SwaggerEndpoint("/swagger/3.0/swagger.json", "Football Manager V3.0");
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void RegisterCommonMapping(IServiceCollection services)
        {
            var config = new TypeAdapterConfig {Compiler = exp => exp.CompileFast()};

            config.NewConfig<ChampionshipEntity, ChampionshipEntity>();

            config.NewConfig<IEnumerable<Championship>, ChampionshipsContainerBeforeV3ViewModel>()
                .Map(x => x.Data, x => x.ToList())
                .Map(x => x.TotalCount, x => x.Count());

            config.NewConfig<Championship, ChampionshipShortBeforeV3ViewModel>()
                .Map(x => x.TeamsCount, x => x.Teams.Count);
            
            config.NewConfig<IEnumerable<Championship>, ChampionshipsContainerV3ViewModel>()
                .Map(x => x.Data, x => x.ToList())
                .Map(x => x.TotalCount, x => x.Count());

            config.NewConfig<Championship, ChampionshipViewModel>()
                .Map(x => x.Teams, x => x.Teams);

            services.AddSingleton(config);
            services.AddSingleton<IMapper, ServiceMapper>();
        }
    }
    
    public sealed class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.FirstOrDefault(p => p.Name == "v");
            if (versionParameter != null) operation.Parameters.Remove(versionParameter);
        }
    }

    public sealed class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("{v}", swaggerDoc.Info.Version), path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}