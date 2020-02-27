namespace CreditInterestCalc
{
    /// <summary>
    /// Interface for User Builder
    /// </summary>
    public interface IUserBuilder
    {
        /// <summary>
        /// Build User Function
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <returns>A new user</returns>
        IUser BuildUser(string name);
    }
}