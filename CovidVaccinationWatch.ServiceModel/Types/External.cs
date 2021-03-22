using System;
using System.Runtime.Serialization;

namespace CovidVaccinationWatch.ServiceModel.Types
{
    [DataContract]
    public class VaccinationDataSource
    {
        [DataMember]
        public DateTime Date { get; set; }
        
        [DataMember]
        public string Location { get; set; }
        
        [DataMember(Name = "total_vaccinations")]
        public decimal? TotalVaccinations { get; set; }
        
        [DataMember(Name = "total_distributed")]
        public decimal? TotalDistributed { get; set; }
        
        [DataMember(Name = "people_vaccinated")]
        public decimal? PeopleVaccinated { get; set; }
        
        [DataMember(Name = "people_fully_vaccinated_per_hundred")]
        public decimal? PeopleFullyVaccinatedPerHundred { get; set; }
        
        [DataMember(Name = "total_vaccinations_per_hundred")]
        public decimal? TotalVaccinationsPerHundred { get; set; }
        
        [DataMember(Name = "people_fully_vaccinated")]
        public decimal? PeopleFullyVaccinated { get; set; }
        
        [DataMember(Name = "people_vaccinated_per_hundred")]
        public decimal? PeopleVaccinatedPerHundred { get; set; }
        
        [DataMember(Name = "distributed_per_hundred")]
        public decimal? DistributedPerHundred { get; set; }
        
        [DataMember(Name = "daily_vaccinations_raw")]
        public decimal? DailyVaccinationsRaw { get; set; }
        
        [DataMember(Name = "daily_vaccinations")]
        public decimal? DailyVaccinations { get; set; }
        
        [DataMember(Name = "daily_vaccinations_per_million")]
        public decimal? DailyVaccinationsPerMillion { get; set; }
        
        [DataMember(Name = "share_doses_used")]
        public decimal? ShareDosesUsed { get; set; }
    }
}