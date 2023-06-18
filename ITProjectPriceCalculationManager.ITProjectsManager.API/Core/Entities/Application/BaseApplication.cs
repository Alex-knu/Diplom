using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application
{
    internal class BaseApplication : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid StatusId { get; set; } 
        public double Price { get; set; }
        public double Profit { get; set; }
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }
        public double? ConfidenceArea { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        
        public ApplicationStatus.ApplicationStatus? Status { get; set; } 
        public Evaluator.Evaluator Creator { get; set; }
    }
}