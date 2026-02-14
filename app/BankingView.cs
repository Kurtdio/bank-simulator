using System;
using ATMApp.Services;

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;
            double lastTransaction = 0.00;
            bool isRunning = true;

            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine("Initial Balance: ₱1000.00");

            while (isRunning)
            {
                Console.WriteLine("\n1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Print Mini Statement");
                Console.WriteLine("5. Exit");
                Console.Write("Select option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        double currentBalance = BankingServices.GetBalance(balance);
                        Console.WriteLine($"Current Balance: ₱{currentBalance}");
                        break;

                    case 2:
                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());

                        bool depositSuccess = BankingServices.Deposit(ref balance, depositAmount);

                        if (depositSuccess)
                        {
                            lastTransaction = depositAmount;
                            Console.WriteLine("Deposit successful.");
                            Console.WriteLine($"Updated Balance: ₱{balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                        BankingServices.Withdraw(ref balance, withdrawAmount, out bool isSuccessful);

                        if (isSuccessful)
                        {
                            lastTransaction = -withdrawAmount;
                            Console.WriteLine("Withdrawal successful.");
                            Console.WriteLine($"Updated Balance: ₱{balance}");
                        }
                        else
                        {
                            Console.WriteLine("Withdrawal failed. Check amount or balance.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: ₱{balance}");
                        Console.WriteLine($"Last Transaction: ₱{lastTransaction}");
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
        }
    }
}
