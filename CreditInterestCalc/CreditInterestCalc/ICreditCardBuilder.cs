namespace CreditInterestCalc
{
    /// <summary>
    /// Credit Card Builder Class.
    /// </summary>
    public interface ICreditCardBuilder
    {
        /// <summary>
        /// Builder Function, not separated into builder Class for simplicity.
        /// </summary>
        /// <param name="cardName">Name of the Card</param>
        /// <param name="balance">The starting balance on the card.</param>
        /// <param name="interestRate"></param>
        /// <returns>The New Card</returns>
        ICreditCard BuildCreditCard(string cardName, double interestRate, double balance);
    }
}