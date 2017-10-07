using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Account
    {
        private string id;
        private Money balance;
        private Person person;

        public Account(Money initialDeposit, string id, Person person)
        {
            this.id = id;
            this.balance = initialDeposit;
            this.person = person;
        }

        ~Account()
        {
            this.id = "";
            this.balance = null;
            this.person = null;
        }

        public override string ToString()
        {
            if (id != "")
            {
                return "Account: " + person.ToString() + ", id : " + id + ", Balance: " + balance.ToString();
            }
            else
            {
                return "account do not exist";
            }

        }

        // Gives access to read and set private variable, alternative to get/set-type of access
        public string AccountId
        {
            get
            {
                return this.id;
            }
        }

        public Money Value
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }
    }
}

