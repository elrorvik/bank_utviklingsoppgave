using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Person
    {
        private string firstName;
        private string lastName;
        // may add more information about a person

        public Person()
        {
            this.firstName = "";
            this.lastName = "";
        }

        ~Person()
        {
            this.firstName = "";
            this.lastName = "";
        }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            if (firstName != "" && lastName != "")
            {
                return "Name: " + this.firstName + " " + this.lastName;
            }
            else
            {
                return "Unknown name";
            }

        }

        public string FirstAndLastName
        {
            get
            {
                return this.firstName + this.lastName;
            }
        }

    }
}
