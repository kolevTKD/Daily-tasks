namespace DailyTasks.Week_1.Day03
{
    using System.Text;

    using Exceptions;
    using Utilities;
    using Utilities.Attributes;

    [TaskDescription(@"Implement a BankAccount class with a Balance property, a Deposit method, and a Withdraw method. Depositing a non-positive amount or withdrawing more than the current balance should throw a custom exception with a clear message.",
        "Enter deposit/withdrawal amounts as decimal numbers when prompted (e.g. 100, 50.25)")]
    public class Day03_BankAccountManager
    {
        [ProblemSolution]
        public static void ManageBankAccount()
        {
            StringBuilder sb = new StringBuilder();

            string selectActionPrompt = sb.AppendLine("Select action:")
              .AppendLine("-Deposit")
              .AppendLine("-Withdraw")
              .AppendLine("-Cancel")
              .ToString()
              .Trim();

            ConsoleColorHelper.WriteLineColored(selectActionPrompt, MessageTypes.Prompt);

            string action = string.Empty;
            BankAccount bankAccount = new BankAccount();

            while (action != "cancel")
            {
                action = Console.ReadLine().ToLower().Trim();

                if (action == "cancel")
                    break;

                else if (!(action == "deposit" || action == "withdraw"))
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input, please try again.", MessageTypes.Error);
                    continue;
                }

                ConsoleColorHelper.WriteLineColored("Enter amount:", MessageTypes.Prompt);

                decimal amount = 0;
                bool isValid = decimal.TryParse(Console.ReadLine(), out amount);

                while (!isValid)
                {
                    ConsoleColorHelper.WriteLineColored("Invalid input! Please enter a valid decimal number:", MessageTypes.Error);
                    isValid = decimal.TryParse(Console.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out amount);
                }


                if (action == "deposit")
                {
                    try
                    {
                        bankAccount.Deposit(amount);
                        ConsoleColorHelper.WriteLineColored($"Deposit of {amount}€ successful! Balance: {bankAccount.Balance:F2}", MessageTypes.Result);
                    }
                    catch (InvalidDepositAmountException idae)
                    {
                        ConsoleColorHelper.WriteLineColored(idae.Message, MessageTypes.Error);
                        ConsoleColorHelper.WriteLineColored("Operation cancelled!", MessageTypes.Error);
                        Environment.Exit(0);
                    }
                }
                else if (action == "withdraw")
                {
                    try
                    {
                        bankAccount.Withdraw(amount);
                        ConsoleColorHelper.WriteLineColored($"Withdrawal of {amount}€ successful! Balance: {bankAccount.Balance:F2}", MessageTypes.Result);
                    }
                    catch (InvalidWithdrawAmountException iwae)
                    {
                        ConsoleColorHelper.WriteLineColored(iwae.Message, MessageTypes.Error);
                        ConsoleColorHelper.WriteLineColored("Operation cancelled!", MessageTypes.Error);
                    }
                }

                ConsoleColorHelper.WriteLineColored(selectActionPrompt, MessageTypes.Prompt);
            }
        }
    }
}
