namespace DailyTasks.Week_1.Day03.Exceptions
{
    public class InvalidDepositAmountException : Exception
    {
        public InvalidDepositAmountException()
            : base(ExceptionMessages.INVALID_DEPOSIT_AMOUNT)
        {
        }
    }
}
