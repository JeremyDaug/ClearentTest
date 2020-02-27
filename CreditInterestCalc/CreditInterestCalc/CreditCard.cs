using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    /// <summary>
    /// The Credit Card Class, does not include checks for negative values.
    /// </summary>
    public class CreditCard : ICreditCard
    {
        /// <summary>
        /// The Name of the Card
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// The Current Balance on the Card
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// The simple interest rate of the card.
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// Calculates the interest given a number of months.
        /// </summary>
        /// <param name="months">Number of months to calculate.</param>
        /// <returns></returns>
        public double CalculateInterest(int months)
        {
            return Math.Round(Balance * Math.Pow(InterestRate, months), 2);
        }

        /// <summary>
        /// Applies interest to the balance.
        /// </summary>
        /// <param name="months">Number of months of interest to add.</param>
        public void ApplyInterest(int months)
        {
            Balance += CalculateInterest(months);
        }
    }
}
