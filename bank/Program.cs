using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {

            // Test of CreateAccount
            Console.Out.WriteLine("*** Test of CreateAccount: Add : Per, Mia og Tom Nordmann ***");
            Person person1 = new Person("Per", "Nordmann");
            Person person2 = new Person("Mia", "Nordmann");
            Person person3 = new Person("Tom", "Nordmann");
                        
            Money amount10 = new Money(10);
            Money amount100 = new Money(100);
            Money amount1000 = new Money(1000);
            Money amount2000 = new Money(2000);
            Money amount100000 = new Money(100000);

            Console.Out.WriteLine("*** Create bank with deposi limit of 100 and depositum of starting a new bankacount 500 ***");
            Bank SMN = new Bank(100,500);

            Console.Out.WriteLine("*** Test of CreateAcccount : Per Nordmann (1000), Mia Nordmann (2000) and Tom (100). If not printet -> to low deposit ***");
            SMN.CreateAccount(person1, amount1000);
            SMN.CreateAccount(person2, amount2000);
            SMN.CreateAccount(person1, amount2000);
            SMN.CreateAccount(person3, amount100);
            SMN.PrintBankAccounts();

            // Test of GetAccountsForCustomer: Check of Mia, Per and Tom (do not have account)
            Console.Out.WriteLine("*** Test of GetAccountsForCustomer: Print accounts for Mia, Per and Tom (do not have account) ***");
            Account[] accountArray1 = SMN.GetAccountsForCustomer(person1);
            SMN.PrintCustomerArrayOfAccounts(accountArray1);
            Account[] accountArray2 = SMN.GetAccountsForCustomer(person2);
            SMN.PrintCustomerArrayOfAccounts(accountArray2);
            Account[] accountArray3 = SMN.GetAccountsForCustomer(person3);
            SMN.PrintCustomerArrayOfAccounts(accountArray3);

            // Test of Deposit: OlaNordmann0 +100, MiaNordmann0 +100 000
            Console.Out.WriteLine("*** Test of Deposit: OlaNordmann0 +100, MiaNordmann0 +100 000 ***");
            SMN.Deposit(accountArray1[0], amount100);
            SMN.Deposit(accountArray2[0], amount100000);
            SMN.PrintBankAccounts();

            // Test of Withdraw: OlaNordmann1 -100 000, MiaNordmann0 -100 000
            Console.Out.WriteLine("*** Test of Withdraw: OlaNordmann1 -100 000, MiaNordmann0 -100 000 ***");
            SMN.Withdraw(accountArray1[1], amount100000);
            SMN.Withdraw(accountArray2[0], amount100000);
            SMN.PrintBankAccounts();

            // Test of Transfer:  1000 from MiaNordmann0 to PerNormann0
            Console.Out.WriteLine("*** Test of transfer: 1000 from MiaNordmann0 to PerNormann0***");
            SMN.Transfer(accountArray2[0], accountArray1[0], amount1000);
            SMN.PrintBankAccounts();

            Console.Out.WriteLine("*** Test of transfer: 100 from MiaNordmann0 to PerNormann0 (on deposit limit for Deposit) ***");
            SMN.Transfer(accountArray2[0], accountArray1[0], amount100);
            SMN.PrintBankAccounts();

            Console.ReadKey();

        }
    }
}
