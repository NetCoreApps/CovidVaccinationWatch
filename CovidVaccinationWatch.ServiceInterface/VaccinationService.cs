using System;
using System.Collections.Generic;
using System.Linq;
using CovidVaccinationWatch.ServiceModel;
using CovidVaccinationWatch.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace CovidVaccinationWatch.ServiceInterface
{
    public class VaccinationService : Service
    {
        public object Any(ResetVaccinationData request)
        {
            using var tx = Db.BeginTransaction();
            try
            {
                Db.DeleteAll<VaccinationData>();
                var csvStr = "https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/vaccinations/us_state_vaccinations.csv"
                    .GetStringFromUrl();

                if (csvStr == null)
                {
                    throw new Exception("Failed to fetch Sqlite data.");
                }

                List<VaccinationDataSource> data = csvStr.FromCsv<List<VaccinationDataSource>>();
                
                Db.InsertAll(data.Select(x => x.ConvertTo<VaccinationData>()).ToList());
            }
            catch (Exception e)
            {
                tx.Rollback();
                Console.WriteLine(e);
                throw;
            }
                
            tx.Commit();

            return "Success";
        }
    }
}