using System.Collections.Generic;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace CovidVaccinationWatch.ServiceModel
{
    [Route("/vaccination_rates")]
    public class QueryVaccinationRates : QueryDb<VaccinationData>
    {
        public string Location { get; set; }
    }

    [Route("/locations")]
    public class GetLocations : IReturn<GetLocationsResponse>, IGet
    {

    }

    public class GetLocationsResponse
    {
        public List<string> Locations { get; set; }
    }

    [Route("/vaccination_rate/reset")]
    [Exclude(Feature.All)]
    public class ResetVaccinationData
    {
        
    }
}