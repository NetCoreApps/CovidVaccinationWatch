using System;
using ServiceStack.DataAnnotations;

namespace CovidVaccinationWatch.ServiceModel.Types
{
    public class VaccinationData
    {
        [AutoIncrement]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal? TotalVaccinations { get; set; }
        public decimal? TotalDistributed { get; set; }
        public decimal? PeopleVaccinated { get; set; }
        public decimal? PeopleFullyVaccinatedPerHundred { get; set; }
        public decimal? TotalVaccinationsPerHundred { get; set; }
        public decimal? PeopleFullyVaccinated { get; set; }
        public decimal? PeopleVaccinatedPerHundred { get; set; }
        public decimal? DistributedPerHundred { get; set; }
        public decimal? DailyVaccinationsRaw { get; set; }
        public decimal? DailyVaccinations { get; set; }
        public decimal? DailyVaccinationsPerMillion { get; set; }
        public decimal? ShareDosesUsed { get; set; }
    }
}