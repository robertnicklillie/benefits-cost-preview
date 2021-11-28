using benefits_cost_preview.Models;
using benefits_cost_preview.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace benefits_cost_preview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBenefitsCostService _benefitsCostService;

        public HomeController(ILogger<HomeController> logger, IBenefitsCostService benefitsCostService)
        {
            _logger = logger;
            _benefitsCostService = benefitsCostService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? companyId)
        {
            if (!companyId.HasValue) companyId = 1234;

            var benefitsCostEmployees = await _benefitsCostService.GetAllEmployeesBenefitsCosts(companyId.Value);

            return View(new BenefitsCostPreviewViewModel
            {
                Employees = benefitsCostEmployees.Select(e => new EmployeeBenefitsCostViewModel
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName ?? String.Empty,
                    SelfCostAnnual = e.SelfCostAnnual,
                    DependentsCostAnnual = e.DependentsCostAnnual,
                    DependentsCount = e.DependentsCount,
                    DiscountAnnual = e.DiscountAnnual,
                    EmployerCoverageRate = e.EmployerCoverageRate
                })
            });
        }

        [HttpGet]
        public async Task<IActionResult> Employee(int? id)
        {
            if (!id.HasValue) throw new ArgumentException("Employee id was missing when attempting to get an employee");

            var employeeBenefitsCost = await _benefitsCostService.GetEmployeeBenefitsCost(id.Value);

            return View(new EmployeeViewModel 
            { 
                
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Employee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // save the employee
            }

            // return the errors

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}