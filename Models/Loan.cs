﻿namespace MortgageCalculator_MVC.Models
{
	public class Loan
	{
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public int Term { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }

        public List<LoanPayment> LoanPayments { get; set; } = new List<LoanPayment>();
    }
}
