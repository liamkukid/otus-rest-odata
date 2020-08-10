using System.Collections.Generic;
using System.Linq;
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
using Maxov.Otus.RestAndOdata.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();

            services.AddSingleton<FootballManagerDbContext>();
            services.AddSingleton<IRepository<long, ChampionshipEntity>, ChampionshipsRepository>();

            services.AddSingleton<IChampionshipService, ChampionshipService>();

            RegisterCommonMapping(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpMethodOverride();

            app.UseRouting();

            app.UseAuthorization();

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