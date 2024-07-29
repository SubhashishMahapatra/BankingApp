using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppUsingList.Models
{
    internal class Account
    {
        public const int LIMIT_BALANCE = 500;
        public string BankName {  get; set; }
        public int AccountNumber {  get; set; }
        public string AccountHolderName { get; set; }

        public double AccountBalance { get; set; }

        public long AadharNumber {  get; set; }

        public Account() 
        {

        }
        public Account(string bankName, string accountHolderName, int accountNumber, double accountBalance, long aadharNumber) 
        {
            BankName = bankName;
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            AccountBalance = accountBalance;
            AadharNumber = aadharNumber;

            if (AccountBalance < LIMIT_BALANCE)
            {
                Console.WriteLine("Balance Can't be below 500, Hence updated to Limit Balance");
                AccountBalance = LIMIT_BALANCE;
            }
            else 
            {
                AccountBalance = accountBalance;
            }
            

        }
        

        
        public static void Transactions(ref List<Account> accounts )
        {
            //accounts = SerializationDeserialization.Deserialization();

            Account transaction = new Account();

            Console.WriteLine("Enter Your Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());


            if (accounts.Count == 0)
            {
                Console.WriteLine("Account Does not Exist, You need to Add an Account First");
                
            }
            else
            {
                foreach (Account account in accounts)
                {
                    transaction.TransactionMenu(account, accNumber);
                }
            }
        }

        public void TransactionMenu(Account account, int accNum)
        {
            bool exit = true;

            int flag = 1;
            while (accNum == account.AccountNumber && exit)
            {
                flag = 0;
                Console.WriteLine();
                Console.WriteLine("Welcome " + account.AccountHolderName);
                Console.WriteLine("-------------------------------");

                Console.WriteLine("1. Deposit 2. Withdraw 3. Account Details 4. Go to the previous menu");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        account.Deposit();
                        break;
                    case 2:
                        account.Withdraw();
                        break;
                    case 3:
                        account.AccountDetails();
                        break;
                    case 4:
                        exit = false;
                        break;

                }
            }

            if (flag == 1)
            {
                Console.WriteLine("Account Not Found");
            }
        }


        public double Deposit()
        {
            Console.Write("Enter the amount you want to deposit: ");
            double dep = int.Parse(Console.ReadLine());
            AccountBalance += dep;
            Console.WriteLine("Amount has been deposited");
            Console.WriteLine("Cuurent Account Balance : "+AccountBalance);
            return AccountBalance;
        }

        public double Withdraw()
        {
            Console.WriteLine("Enter the amount you want to withdraw: ");
            double withdraw = int.Parse(Console.ReadLine());

            if (AccountBalance  - withdraw < LIMIT_BALANCE )
            {
                Console.WriteLine("Insufficient Amount to withdraw!");
            }
            else 
            {
                AccountBalance -= withdraw;
                Console.WriteLine("Amount Withdrawn Successfully!");
                Console.WriteLine("Current Balance left is: "+AccountBalance);

            }
            
            return AccountBalance;
        }

        public void AccountDetails()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"| {"Account Number",-25} | {AccountNumber,25} |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"| {"Bank Name",-25} | {BankName,25} |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"| {"Account Holder Name",-25} | {AccountHolderName,25} |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"| {"Account Balance",-25} | {AccountBalance,25} |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"| {"Aadhar Number",-25} | {AadharNumber,25} |");
            Console.WriteLine("----------------------------------------------------------");

        }


    }
}


