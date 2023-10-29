using MortgageCalculator_MVC.Models;

namespace MortgageCalculator_MVC.Helpers
{
    public class LoanHelper
    {
        public Loan GetLoanData(Loan loan)
        {
            loan.Payment = CalcPayment(loan.Amount, loan.Rate, loan.Term);

            decimal balance = loan.Amount;
            decimal totalInterest = 0.0M;
            decimal monthlyRate = CalcMonthlyRate(loan.Rate);

            // for loop
            for (int month = 1; month <= loan.Term; month++)
            {
                decimal monthlyInterst = CalMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterst;
                decimal monthlyPrincipal = loan.Payment - monthlyInterst;
                balance -= monthlyPrincipal;

                LoanPayment loanPayment = new LoanPayment()
                {
                    Month = month,
                    Payment = loan.Payment,
                    MonthlyPrincipal = monthlyPrincipal,
                    MonthlyInterest = monthlyInterst,
                    TotalInterest = totalInterest,
                    Balance = balance
                };

                loan.LoanPayments.Add(loanPayment);

            }

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.Amount + totalInterest;

            return loan;
        }

        private decimal CalcPayment(decimal amount, decimal rate, int term)
        {
            decimal monthlyRate = CalcMonthlyRate(rate);
            double fixedRate = Convert.ToDouble(monthlyRate);
            double fixedAmount = Convert.ToDouble(amount);

            double fixedPayment = (fixedAmount * fixedRate) / (1 - Math.Pow(1 + fixedRate, -term));


            return Convert.ToDecimal(fixedPayment);
        }

        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }

        private decimal CalMonthlyInterest(decimal balance, decimal monthlyRate)
        {


            return balance * monthlyRate;
        }
    }
}
