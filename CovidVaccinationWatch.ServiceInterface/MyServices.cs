using System;
using System.Linq;
using ServiceStack;
using CovidVaccinationWatch.ServiceModel;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace CovidVaccinationWatch.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }

        public object Get(GetLocations request)
        {
            var q = Db.From<VaccinationData>()
                .Select(x => x.Location);
            var results = Db.ColumnDistinct<string>(q);
            return new GetLocationsResponse
            {
                Locations = results.ToList()
            };

        }
    }
}
