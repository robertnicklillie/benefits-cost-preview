using benefits_cost_preview.Data;
using benefits_cost_preview.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestClass]
    public class BenefitsCostServiceTests
    {
        [TestMethod]
        public async Task CalculateBenefitCost_NoDependents_Discount_ZeroEmployerCoverage()
        {
            // Arrange

            var benefitsCostService = new BenefitsCostService(new BenefitsCostRepository());

            var profile = new benefits_cost_preview.Data.Models.EmployeeBenefitsCostProfile
            {
                FirstName = "Robert",
                LastName = "Adams",
                EmployerCoverageRatio = 0
            };

            // Act

            var result = await benefitsCostService.CalculateBenefitsCost(profile);

            // Assert

            Assert.AreEqual(result.EmployeeCostPerPayPeriod, 34.62m);
        }

        [TestMethod]
        public async Task CalculateBenefitCost_NoDependents_Discount_EmployerCoverage()
        {
            // Arrange

            var benefitsCostService = new BenefitsCostService(new BenefitsCostRepository());

            var profile = new benefits_cost_preview.Data.Models.EmployeeBenefitsCostProfile
            {
                FirstName = "Robert",
                LastName = "Adams",
                EmployerCoverageRatio = .33m
            };

            // Act

            var result = await benefitsCostService.CalculateBenefitsCost(profile);

            // Assert

            Assert.AreEqual(result.EmployeeCostPerPayPeriod, 23.19m);
        }

        [TestMethod]
        public async Task CalculateBenefitCost_NonRatioCoverageThrowsAnException()
        {
            // Arrange

            var benefitsCostService = new BenefitsCostService(new BenefitsCostRepository());

            var profile = new benefits_cost_preview.Data.Models.EmployeeBenefitsCostProfile
            {
                FirstName = "Robert",
                LastName = "Adams",
                EmployerCoverageRatio = 1.1m
            };

            Exception exception = null;

            // Act

            try
            {
                var result = await benefitsCostService.CalculateBenefitsCost(profile);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public async Task CalculateBenefitCost_Dependents_Discount_EmployerCoverage()
        {
            // Arrange

            var benefitsCostService = new BenefitsCostService(new BenefitsCostRepository());

            var profile = new benefits_cost_preview.Data.Models.EmployeeBenefitsCostProfile
            {
                FirstName = "Robert",
                LastName = "Adams",
                EmployerCoverageRatio = .33m,
                EmployeeDependents = new List<benefits_cost_preview.Data.Models.EmployeeDependent>
                {
                    new benefits_cost_preview.Data.Models.EmployeeDependent
                    {
                        FirstName = "Suzy",
                        LastName = "Adams"
                    },
                    new benefits_cost_preview.Data.Models.EmployeeDependent
                    {
                        FirstName = "Douglas",
                        LastName = "Adams"
                    },
                    new benefits_cost_preview.Data.Models.EmployeeDependent
                    {
                        FirstName = "Mary Beth",
                        LastName = "Adams"
                    }
                }
            };

            // Act

            var result = await benefitsCostService.CalculateBenefitsCost(profile);

            // Assert

            Assert.AreEqual(result.EmployeeCostPerPayPeriod, 57.98m);
        }
    }
}
