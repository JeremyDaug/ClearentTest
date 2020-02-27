namespace CreditInterestCalc
{
    public interface ICreditCard
    {
        /// <summary>
        /// The Name of the Card
        /// </summary>
        string CardName { get; set; }

        /// <summary>
        /// The Current Balance on the Card
        /// </summary>
        double Balance { get; set; }

        /// <summary>
        /// The simple interest rate of the card.
        /// </summary>
        double InterestRate { get; set; }

        /// <summary>
        /// Calculates the interest given a number of months.
        /// </summary>
        /// <param name="months">Number of months to calculate.</param>
        /// <returns>The Interest Accumulated over those months.</returns>
        double CalculateInterest(int months);

        /// <summary>
        /// Applies interest to the balance.
        /// </summary>
        /// <param name="months">Number of months of interest to add.</param>
        void ApplyInterest(int months);
    }
}