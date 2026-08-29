namespace DailyTasks.Week_1.Day03
{
    using Exceptions;

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidDepositAmountException();
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidWithdrawAmountException(string.Format(ExceptionMessages.INVALID_WITHDRAW_AMOUNT, Balance));
            }

            Balance -= amount;
        }
    }
}
