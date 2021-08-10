using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Funq;
using ServiceStack;
using NUnit.Framework;
using CovidVaccinationWatch.ServiceInterface;
using CovidVaccinationWatch.ServiceModel;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Text;

namespace CovidVaccinationWatch.Tests
{
    public class IntegrationTest
    {
        const string BaseUri = "http://localhost:2000/";
        private readonly ServiceStackHost appHost;

        class AppHost : AppSelfHostBase
        {
            public AppHost() : base(nameof(IntegrationTest), typeof(VaccinationService).Assembly) { }

            public override void Configure(Container container)
            {
                Plugins.Add(new AutoQueryDataFeature
                {
                    MaxLimit = 100
                });
                container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(":memory:",
                    new SqliteOrmLiteDialectProvider()));
            
                Plugins.Add(new AutoQueryFeature { MaxLimit = 100});

                JsConfig.DateHandler = DateHandler.ISO8601;

                var csvStr = File.ReadAllText("~\\TestFiles\\test-data.csv".MapProjectPath());

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

        public IntegrationTest()
        {
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

        [Test]
        public void Can_filter_by_date()
        {
            var dateGreaterThan = new DateTime(2021, 3, 1);
            var client = CreateClient();
            var response = client.Get(new QueryVaccinationRates
            {
                DateGreaterThan = dateGreaterThan
            });
            Assert.That(response.Results.All(x => x.Date > dateGreaterThan));
        }
    }
}