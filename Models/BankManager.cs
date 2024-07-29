using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BankAppUsingList.Models
{
    internal class BankManager
    {        
        public static void StartApp() //Account[] account --> for an Array
        {
            List<Account> account = new List<Account>();  // Creation of a List

            account = SerializationDeserialization.Deserialization();
            
            bool programRunning = true;
            Console.WriteLine("Welcome To Banking App");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Select an Options Below");
            while (programRunning)
            {
                
                Console.WriteLine();
                Console.WriteLine($"{"1. Create New Account"} | {"2. Work with an Existing account"} | {"3. Exit App"} ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        
                        AddAccount(ref account);
                        break;

                    case 2:

                        ExistingAccount(ref account);
                        break;
                    case 3:

                        programRunning = false;
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Thank for Using Banking App!, Have a nice day :)");
                        Console.WriteLine("-----------------------------------------------");

                        break;
                }

            }

            static void AddAccount(ref List<Account> account)
            {
                Console.WriteLine();
                Console.WriteLine("Enter All Your Details Properly to Add an Account");
                Console.WriteLine("----------------------------------------------------------------------------------------");


                Console.Write("Enter Your Bank Name: ");
                string bankName = Console.ReadLine();
                Console.Write("Enter Account Holder Name: ");
                string accountHolderName = Console.ReadLine();
                Console.Write("Enter Account Number: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter the Balance You want to Add: ");
                double accountBalance = double.Parse(Console.ReadLine());
                Console.Write("Enter Your Aadhar Number: ");
                long aadharNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Congratulations!..Your Account has been Added Successfully!");

                Account newAccount = new Account(bankName, accountHolderName, accountNumber, accountBalance, aadharNumber);
                account.Add(newAccount);
                SerializationDeserialization.Serialization(account);
            }


            static void ExistingAccount(ref List<Account> account)
            {
         
                bool programmingRunning = true;

                while (programmingRunning)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine($"| {"1. Update your Account"} | {"2. View or Initiate Transactions"} |  {"3. Remove Your Account"} | {"4. Go to Main Menu"}");
                    int choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            UpdateAccountDetails(ref account);
                            break;
                        case 2:
                            Account.Transactions(ref account);
                            break;
                        case 3:
                            RemoveAccount(ref account);
                            break;
                        case 4:
                            programmingRunning = false;
                            break;
                    }
                }
            }

            
            

            static void UpdateAccountDetails(ref List<Account> accounts)
            {

                Console.Write("Enter the account number you want to Edit: ");
                int accNumber = int.Parse(Console.ReadLine());
                int iterator = 0;
                if (accounts.Count == 0)
                {
                    Console.WriteLine("System Doesn't Contain any account, You have to Add before Updating.");
                    Console.WriteLine("Go to the Previous Menu and Create a new one.");
                }
                else
                {
                    foreach (Account account in accounts)
                    {


                        if (account.AccountNumber == accNumber)
                        {
                            Console.WriteLine("Welcome " + account.AccountHolderName);
                            Console.WriteLine("Edit your Details Below");

                            Console.Write("Enter Your Bank Name: ");
                            string bankName = Console.ReadLine();
                            Console.Write("Enter Account Holder Name: ");
                            string accountHolderName = Console.ReadLine();
                            //Console.Write("Enter Account Number: ");
                            //int accountNumber = int.Parse(Console.ReadLine());
                            //Console.Write("Enter the Balance You want to Add: ");
                            //double accountBalance = double.Parse(Console.ReadLine());
                            Console.Write("Enter Your Aadhar Number: ");
                            long aadharNumber = long.Parse(Console.ReadLine());

                            


                            Account newAccount = new Account(bankName, accountHolderName, account.AccountNumber, account.AccountBalance, aadharNumber);

                            accounts[iterator] = newAccount;
                            SerializationDeserialization.Serialization(accounts);
                            Console.WriteLine("Account Updated Successfully!");
                            break;

                            

                        }
                        else
                        {
                            Console.WriteLine("Account Not Found");
                        }

                        iterator++;
                    }

                }
                
            }



            static void RemoveAccount(ref List<Account> accounts)
            {
                int flag = 0;
                Console.WriteLine("Enter Account Number that needs to be removed: ");
                int accNumber = int.Parse(Console.ReadLine());

                foreach(Account account in accounts)
                {
                    if (account.AccountNumber == accNumber) 
                    {
                        accounts.Remove(account);
                        Console.WriteLine("Account Removed Successfully!");
                        flag = 1;
                        break; 
                    }
                    
                }

                if (flag == 0) 
                {
                    Console.WriteLine("Account Not Found"); 
                }

                SerializationDeserialization.Serialization(accounts);
            }
            


        }

    }
}
