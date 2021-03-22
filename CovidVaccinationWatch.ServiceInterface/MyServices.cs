using System;
using ServiceStack;
using CovidVaccinationWatch.ServiceModel;
using CovidVaccinationWatch.ServiceModel.Types;

namespace CovidVaccinationWatch.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
