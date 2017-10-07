using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Bank
    {
        private Dictionary<string, Account> accounts;
        private Money depositLimit; // the needed amount to be able to make a deposit
        private Money openAccountLimit; // the needed amout to be able to make a new account

        public Bank()
        {
            this.accounts = new Dictionary<string, Account>();
            this.depositLimit = new Money(0);
            this.openAccountLimit = new Money(0);
        }

        public Bank(int depositLimit,int openAccountLimit)
        {
            this.accounts = new Dictionary<string, Account>();
            this.depositLimit = new Money(depositLimit);
            this.openAccountLimit = new Money(openAccountLimit);
        }

        ~Bank()
        {
            this.accounts.Clear();
            this.depositLimit = null;
            this.openAccountLimit = null;
        }

        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            Account newAccount = null;

            if (this.openAccountLimit > initialDeposit) 
            {
                return newAccount;
            }

            string name = customer.FirstAndLastName;
            int numberOfAccounts = getCustomerNumberOfAccounts(customer) + 1;
            string accountID = accountID = name + (numberOfAccounts).ToString();

            newAccount = new Account(initialDeposit, accountID, customer);

            accounts.Add(accountID, newAccount);
            return newAccount;
        }

        public Account[] GetAccountsForCustomer(Person customer)
        {
            Account[] accountsArray = null;

            if (customer == null)
            {
                return accountsArray;
            }

            int num = 0;
            string name = customer.FirstAndLastName;
            string id = name + num.ToString();

            if (accounts.ContainsKey(id))
            {
                int numberOfAccounts = getCustomerNumberOfAccounts(customer);
                accountsArray = new Account[numberOfAccounts + 1];

                for (int i = 0; i <= numberOfAccounts; i++)
                {
                    id = name + i.ToString();
                    accountsArray[i] = accounts[id];
                }
            }
            return accountsArray;
        }

        public bool Deposit(Account to, Money amount)
        {
            if (to == null || !accounts.ContainsKey(to.AccountId)) // check if accounts exists
            {
                return false;
            }

            Money noMoney = new Money(0);
            if (depositLimit < amount && amount > noMoney) // don't want to add negative/zero money
            {
                accounts[to.AccountId].Value = amount + accounts[to.AccountId].Value;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Withdraw(Account from, Money amount)
        {
            if (from == null || !accounts.ContainsKey(from.AccountId)) // check if accounts exists
            {
                return false;
            }

            string id = from.AccountId;
            Money noMoney = new Money(0);
            if (accounts[id].Value - amount >= noMoney && amount > noMoney) // don't want to add negative/zero money
            {
                accounts[id].Value = accounts[id].Value - amount;
                return true;
            }else
            {
                return false;
            }

        }

        public void Transfer(Account from, Account to, Money amount)
        {
            if (from == null || to == null || !accounts.ContainsKey(from.AccountId) || !accounts.ContainsKey(to.AccountId))
            {
                return;
            }
            Money noMoney = new Money(0);
            if (accounts[from.AccountId].Value - amount >= noMoney && amount > this.depositLimit) // not send if the amount is not bigger than depositLimit
            {
                Withdraw(from, amount);
                Deposit(to, amount);
  
            }
        }

        private int getCustomerNumberOfAccounts(Person customer)
        {
            if (customer == null)
            {
                return -100; // customer do not exists
            }

            int num = 0;
            string name = customer.FirstAndLastName;
            string id = name + num.ToString();

            while (accounts.ContainsKey(id))
            {
                num += 1;
                id = name + num.ToString();

            }
            return num - 1;
        }

        public void PrintBankAccounts()
        {
            string temp;
            foreach (KeyValuePair<string, Account> kvp in accounts)
            {
                string accountID = kvp.Key;
                temp = accounts[accountID].ToString();
                Console.Out.WriteLine(temp);
            }

        }

        public void PrintCustomerArrayOfAccounts(Account[] accountArray)
        {
            if (accountArray != null)
            {
                for (int i = 0; i < accountArray.Length; i++)
                {
                    Console.Out.WriteLine(accountArray[i].ToString());
                }
            }
            else
            {
                Console.Out.WriteLine("empty array");
            }
        }
    }

}


