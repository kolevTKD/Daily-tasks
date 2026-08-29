namespace DailyTasks.Week_1.Day03.Exceptions
{
    public class InvalidWithdrawAmountException : Exception
    {
        public InvalidWithdrawAmountException()
            : base(ExceptionMessages.INVALID_WITHDRAW_AMOUNT)
        {
        }

        public InvalidWithdrawAmountException(string message)
            : base(message)
        {
        }
    }
}
