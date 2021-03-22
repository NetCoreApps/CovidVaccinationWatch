using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack;

namespace CovidVaccinationWatch.ServiceModel
{
    [Route("/vaccination_rate")]
    public class QueryVaccinationRatesByLocation : QueryDb<VaccinationData>
    {
        
    }

    [Route("/vaccination_rate/reset")]
    public class ResetVaccinationData
    {
        
    }
}