using Microsoft.AspNetCore.Mvc;
using MortgageCalculator_MVC.Helpers;
using MortgageCalculator_MVC.Models;

namespace MortgageCalculator_MVC.Controllers
{
	public class LoanCalcController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			Loan loan = new Loan()
			{
				Payment = 0.0M,
				TotalInterest = 0.0M,
				TotalCost = 0.0M,
				Rate = 5.0M,
				Amount = 25000.00M,
				Term = 60
			};

			return View(loan);
		}

		[HttpPost]
		public IActionResult Index(Loan loan)
		{
			LoanHelper loanHelper = new LoanHelper();

			Loan model = loanHelper.GetLoanData(loan);

			return View(model);
		}
	}
}
