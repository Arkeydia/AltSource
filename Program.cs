using System;
using System.Collections.Generic;
using System.Linq;
//You have been tasked with writing the world’s greatest banking ledger.
//Please code a solution that can perform the following workflows through a console application (accessed via the command line):

//-Create a new account
//-Login
//-Record a deposit
//-Record a withdrawal
//-Check balance
//-See transaction history
//-Log out

//For additional credit, you may implement this through a web page. They don’t have to run at the same time, but if you would like to do that, feel free.

//Use C# for the backend. If designing a front end, use whatever JavaScript frameworks/libraries you wish and just make sure they are included or available via NuGet.
//There is no need to use persistent storage or spend much time on the UI (unless you love doing that).

//Created by Brent Langevin - January 14th, 2019

namespace BankLedger_AltSource
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Bank of AltSource Console Application";

            //Prints Menu
            MenuInitializer();

        }

        static void MenuInitializer()
        {
            
            //Command lines written into Console App.
            Console.Clear();
            Console.WriteLine("Bank of AltSource - Banking Application");
            Console.WriteLine("-----------------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nIf you have an account, please login now. Otherwise create a new account.");
            Console.WriteLine("\nPlease enter the number of the option desired and press enter:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create a New Account");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\nEntry:");

            //Converts input to integer for use in cases.
            var menuInput = ReadMenuInput();

            MainMenuSelector(menuInput);

            //Console Pause
            Console.ReadKey();
        }


        static void MainMenuSelector(int input)
        {
            //List of accounts
            List<Account> AccountList = new List<Account>();

            switch (input)
            {

                case 1:
                    //Attempts Login and exposes additional features.
                    Console.WriteLine("\nNo Account detected, running in TRIAL mode.");
                    System.Threading.Thread.Sleep(1500);
                    Account acct = new Account("Trial Account", "password123", "Alton", "Sorcham");
                    AccessFeatures(acct);
                    break;
                case 2:
                    //Creates an account
                    Account newAcct = new Account();
                    newAcct = AccountCreator();
                    AccountList.Add(newAcct);
                    goto case 1;
                case 3:
                    Console.WriteLine("\nThe Application will close shortly.");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\n\t3");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\t2");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\t1");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\nThank you for choosing Bank of AltSource.");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;
                case 99:
                    Console.WriteLine("\nSecret control. List of Accounts:");
                    foreach (Account accts in AccountList)
                    {
                        accts.GeneralInquiry();
                    }
                    Console.ReadKey();
                    Console.WriteLine("\nRestarting...");
                    goto default;
                default:
                    Console.WriteLine("Invalid Input. Returning to Main Menu.");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    MenuInitializer();
                    break;
            };
        }

        public static Account AccountCreator()
        {
            Console.Clear();
            Console.WriteLine("Bank of AltSource - Account Creator");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nTo create a new account, please enter the information below:");

            //Gathers attributes for class
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            if (username.Contains(" ") || username == "")
            {
                Console.WriteLine("Username cannot contain spaces or be blank. Please enter a new Username.");
                System.Threading.Thread.Sleep(4000);
                AccountCreator();
            }
            Console.WriteLine("Password");
            string password = Console.ReadLine();
            if (password == "")
            {
                Console.WriteLine("Passwords cannot be blank. Restarting Account Creator on next keystroke.");
                Console.ReadKey();
                AccountCreator();
            }
            Console.WriteLine("Confirm Password:");
            string pwConfirm = Console.ReadLine();
            if (password != pwConfirm) 
                {
                Console.WriteLine("Passwords do not match. Restarting Account Creator on next keystroke.");
                Console.ReadKey();
                AccountCreator();
            }

            Console.WriteLine("Type in First:");
            string firstName = Console.ReadLine();
            if (firstName.Any(c => char.IsDigit(c)) || firstName[0] == '$' || firstName == "")
            {
                Console.WriteLine("Names cannot contain numbers or be blank. Use Roman Numberals (e.g. III) where required. Restarting Account Creator on next keystroke.");
                Console.ReadKey();
                AccountCreator();
            }
            Console.WriteLine("Type in Last Name:");
            string lastName = Console.ReadLine();
            if (lastName.Any(c => char.IsDigit(c)) || lastName[0] == '$' || lastName == "")
            {
                Console.WriteLine("Names cannot contain numbers or be blank. Use Roman Numberals (e.g. III) where required. Restarting Account Creator on next keystroke.");
                Console.ReadKey();
                AccountCreator();
            }
            //var name = fullName.Split(" ");
            //string firstName = name[0];
            //string lastName = name[1];

            Console.WriteLine("Please Confirm all the information is correct:");
            Console.WriteLine("\nUsername: " + username);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);;
            Console.WriteLine("\nDoes everything look correct? 1 = Yes, 2 = No.");
            Console.WriteLine("\nEntry:");

            //var account = new Account();
            int input = 0; 
            int.TryParse(Console.ReadLine(), out input);

            switch (input)
            {
                case 1:
                    //Creates an account
                    Account acct = new Account(username, password, firstName, lastName);
                    Console.Clear();
                    Console.WriteLine("\nNew account has been created successfully!" + "\n\nYour Account information is as follows:");
                    acct.GeneralInquiry();

                    Console.WriteLine("\nPress Any Key to Return to Main Menu...");
                    Console.ReadKey();
                    MenuInitializer();
                    return acct;
                case 2:
                    //Restarts Account Creation
                    AccountCreator();
                    break;
                default:
                    //Restarts this portion of code
                    Console.WriteLine("\nInvalid entry, restarting Account Creation.");
                    System.Threading.Thread.Sleep(2000);
                    AccountCreator();
                    break;
            }

            //Initial Deposit
            //Console.WriteLine("\nEnter an initial amount to deposit (Max $10,000). Enter 0 to to skip.");
            //Console.WriteLine("\nEntry:");

            //int deposit;
            //string userInput = Console.ReadLine();
            //if (decimal.Parse(userInput) > 10000)
            //{
            //    Console.WriteLine("Deposits of the magnitude are not allowed at this time. Please see a Teller at a Bank of Altsource branch to deposit sums of this size.");
            //}
            //else if (int.TryParse(userInput, out deposit))
            //{
            //    account.Deposit(deposit, DateTime.Now);
            //    Console.WriteLine("Counting Money...");
            //    System.Threading.Thread.Sleep(1000);
            //    Console.WriteLine("Confirming Balance...");
            //    System.Threading.Thread.Sleep(1000);
            //    Console.WriteLine("\nGreat! Your new account balance is: " + account.Balance);
            //}
            //else
            //{
            //    Console.WriteLine("Skipping Initial Deposit...");
            //}

            //Returns to Login Screen

            return null;
        }
        static int ReadMenuInput()
        {
            var selection = Console.ReadLine();
            int returnVal;
            if (int.TryParse(selection, out returnVal))
            {
                return Convert.ToInt32(selection);
            }
            else
            {
                return 0;
            }
        }

        static void AccessFeatures(Account acct)
        //This section will demonstrate the following functionality:
        //-Login    //-Record a deposit    //-Record a withdrawal    //-Check balance    //-See transaction history    //-Logout
        {
            Console.WriteLine("\nPlease enter your Username:");
            Console.WriteLine("\nPlease enter your Password:");
            //Code to check input

            Console.Clear();
            Console.WriteLine("Bank of AltSource - Welcome " + acct.GetFirstName() + "!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Make Deposit");
            Console.WriteLine("2. Make Withdrawal");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Logout");
            Console.WriteLine("\nEntry:");

            var menuInput = ReadMenuInput();

            switch (menuInput)
            {
                case 1:
                    //Attempts Login and exposes additional features.

                    Console.WriteLine("Your current balance is:");
                    acct.CheckBalance();
                    Console.WriteLine("How much would you like to deposit?");
                    Console.WriteLine("\nEntry:");

                    try
                    {
                        decimal d = decimal.Parse(Console.ReadLine());
                        acct.Deposit(d, DateTime.Now);
                    }
                    catch (FormatException ex)
                    {
                        Console.Clear();
                        Console.WriteLine("****Entry was invalid! Ensure you've input just numbers (2 decimal precise)!****\n");
                        goto case 1;
                    }
                    Console.WriteLine("Counting Money...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Confirming Balance...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\nGreat! Your new account balance is: ");
                    acct.CheckBalance();
                    Console.WriteLine("\nPress any key to see additional options...");
                    Console.ReadKey();
                    goto default;
                case 2:
                    //Withdrawal process
                    Console.WriteLine("\nYour current balance is:");
                    acct.CheckBalance();
                    Console.WriteLine("\nHow much would you like to withdraw?");
                    Console.WriteLine("\nEntry:");
                    try
                    {
                        decimal w = decimal.Parse(Console.ReadLine());
                        acct.Withdrawal(w, DateTime.Now);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("\nInvalid Entry. Try again!");
                    }

                    Console.WriteLine("Counting Money...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Confirming Balance...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\nYour remaining balance is: ");
                    acct.CheckBalance();
                    Console.WriteLine("\nPress any key to see additional options...");
                    Console.ReadKey();
                    goto default;
                    break;
                case 3:
                    //Checks Balance of Currently logged on acct
                    Console.WriteLine("\nYour current balance is:");
                    acct.CheckBalance();
                    Console.WriteLine("\nPress any key to see additional options...");
                    Console.ReadKey();
                    goto default;
                case 4:
                    //Checks the Transaction History.
                    Console.WriteLine("The following is your entire transaction history:");
                    acct.GetTransactionHistory(); //Performs the Console.WriteLines
                    Console.WriteLine("\nPress any key to see additional options...");
                    Console.ReadKey();
                    goto default;
                case 5:
                    //Logout
                    Console.Clear();
                    Console.WriteLine("\nYou will be logged out and returned to the main menu momentarily.");
                    System.Threading.Thread.Sleep(2000);
                    MenuInitializer();
                    break;
                default:
                    AccessFeatures(acct);
                    break;
            };
        }
    };
}
