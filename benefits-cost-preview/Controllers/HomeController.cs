using benefits_cost_preview.Models;
using benefits_cost_preview.Services;
using benefits_cost_preview.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
        public async Task<IActionResult> Index()
        {
            var benefitsCostEmployees = await _benefitsCostService.GetAllEmployeesBenefitsCosts();

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
            var model = new EmployeeViewModel { };
            if (id.HasValue)
            {
                var profile = await _benefitsCostService.GetEmployeeBenefitsCost(id.Value);

                model.EmployeeId = profile.EmployeeId;
                model.FirstName = profile.FirstName;
                model.LastName = profile.LastName;
                model.EmployerCoveragePercent = profile.EmployerCoverageRatio * 100;
                if (profile.EmployeeDependents != null && profile.EmployeeDependents.Any())
                    model.Dependents = profile.EmployeeDependents.Select(d => new DependentsViewModel
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Action = CRUDAction.None
                    }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Employee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // save the employee

                var profile = new EmployeeBenefitsCostProfile
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployerCoverageRatio = Math.Round(model.EmployerCoveragePercent.Value / 100, 2)
                };

                if (model.Dependents != null && model.Dependents.Any())
                {
                    profile.EmployeeDependents = model
                        .Dependents
                        .Where(d => d.Action != CRUDAction.Remove)
                        .Select(d => new EmployeeDependentProfile
                        {
                            FirstName = d.FirstName,
                            LastName = d.LastName
                        })
                        .ToList();
                }

                await _benefitsCostService.AddOrUpdateEmployee(profile);

                return RedirectToAction("Index");
            }

            // return the validation errors

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> CalculateBenefitsCost(EmployeeViewModel model)
        {
            EmployeeBenefitsCostPreview preview = new EmployeeBenefitsCostPreview();
            
            if (ModelState.IsValid)
            {
                // save the employee

                var profile = new EmployeeBenefitsCostProfile
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployerCoverageRatio = Math.Round(model.EmployerCoveragePercent.Value / 100, 2)
                };

                if (model.Dependents != null && model.Dependents.Any())
                {
                    profile.EmployeeDependents = model
                        .Dependents
                        .Where(d => d.Action != CRUDAction.Remove)
                        .Select(d => new EmployeeDependentProfile
                        {
                            FirstName = d.FirstName,
                            LastName = d.LastName
                        })
                        .ToList();
                }

                var cost = await _benefitsCostService.Preview(profile);

                preview.EmployeeGrossPerPayPeriod = profile.GrossPayPerPayPeriod;
                preview.EmployeeCostPerPayPeriod = cost.EmployeeCostPerPayPeriod;
                preview.CanCalculate = true;
            }

            return new JsonResult(preview);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}