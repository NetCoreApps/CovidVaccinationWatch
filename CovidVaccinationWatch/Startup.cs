using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Funq;
using ServiceStack;
using CovidVaccinationWatch.ServiceInterface;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.IO;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Text;

namespace CovidVaccinationWatch
{
    public class Startup : ModularStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public new void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("CovidVaccinationWatch", typeof(MyServices).Assembly) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });

            container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(":memory:",
                new SqliteOrmLiteDialectProvider()));
            
            Plugins.Add(new AutoQueryFeature { MaxLimit = 100});

            JsConfig.DateHandler = DateHandler.ISO8601;

            var csvStr = "https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/vaccinations/us_state_vaccinations.csv"
                .GetStringFromUrl();

            if (csvStr == null)
            {
                throw new Exception("Failed to fetch Sqlite data.");
            }

            List<VaccinationDataSource> data = csvStr.FromCsv<List<VaccinationDataSource>>();

            if (data.Count == 0)
            {
                throw new Exception("Failed to initialize Sqlite data.");
            }

            // Initialize data into sqlite.
            using var db = container.Resolve<IDbConnectionFactory>().Open();
            if (db.CreateTableIfNotExists<VaccinationData>())
            {
                db.InsertAll(data.Select(x => x.ConvertTo<VaccinationData>()).ToList());
            }

            var dataCount = db.Count<VaccinationData>();

            if (dataCount == 0)
            {
                throw new Exception("Failed to insert Sqlite data.");
            }
        }
    }
}
