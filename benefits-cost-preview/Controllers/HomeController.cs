using benefits_cost_preview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace benefits_cost_preview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new BenefitsCostPreviewViewModel
            {
                Employees = new List<EmployeeBenefitsCostViewModel>
                {
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    },
                    new EmployeeBenefitsCostViewModel
                    {
                        EmployeeId = 1,
                        EmployeeName = "Jerry Atkins",
                        SelfCostAnnual = 1000m,
                        DependentsCostAnnual = 2000m,
                        DependentsCount = 4,
                        DiscountAnnual = 300m,
                        EmployerCoverageRate = .77m
                    }
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Employee(int? id)
        {
            return View(new EmployeeViewModel { Dependents = new List<DependentsViewModel> { new DependentsViewModel { FirstName = "George", LastName = "Smith" } } });
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