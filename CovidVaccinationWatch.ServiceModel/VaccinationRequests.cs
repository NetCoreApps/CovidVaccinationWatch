using System.Collections.Generic;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack;

namespace CovidVaccinationWatch.ServiceModel
{
    [Route("/vaccination_rate")]
    public class QueryVaccinationRates : QueryDb<VaccinationData>
    {
        public string Location { get; set; }
    }

    [Route("/locations")]
    public class GetLocations : IReturn<GetLocationsResponse>
    {
        
    }

    public class GetLocationsResponse
    {
        public List<string> Locations { get; set; }
    }

    [Route("/vaccination_rate/reset")]
    public class ResetVaccinationData
    {
        
    }
}