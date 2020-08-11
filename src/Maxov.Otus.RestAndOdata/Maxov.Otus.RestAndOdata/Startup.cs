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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddSingleton<FootballManagerDbContext>();
            services.AddSingleton<IRepository<long, ChampionshipEntity>, ChampionshipsRepository>();

            services.AddSingleton<IChampionshipService, ChampionshipService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Football Manager API",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Maxim Ovchinnikov",
                        Email = "footballmanager@ovchinnikov.ma",
                        Url = new Uri("https://www.facebook.com/max.ovchinnikov/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football Manager");
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void RegisterCommonMapping(IServiceCollection services)
        {
            var config = new TypeAdapterConfig {Compiler = exp => exp.CompileFast()};

            config.NewConfig<ChampionshipEntity, ChampionshipEntity>();

            config.NewConfig<IEnumerable<Championship>, ChampionshipsContainerViewModel>()
                .Map(x => x.Data, x => x.ToList())
                .Map(x => x.TotalCount, x => x.Count());

            config.NewConfig<Championship, ChampionshipShortViewModel>()
                .Map(x => x.TeamsCount, x => x.Teams.Count);

            config.NewConfig<Championship, ChampionshipViewModel>()
                .Map(x => x.Teams, x => x.Teams);

            services.AddSingleton(config);
            services.AddSingleton<IMapper, ServiceMapper>();
        }
    }
}