using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Money
    {
        private double value;
        // may also add private variable currency if needed

        public Money()
        {
            this.value = 0.0;
        }

        public Money(double value)
        {
            this.value = value;
        }

        ~Money()
        {
            this.value = 0.0;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public static bool operator <(Money lhs, Money rhs)
        {
            return lhs.value < rhs.value;
        }

        public static bool operator >(Money lhs, Money rhs)
        {
            return lhs.value > rhs.value;
        }

        public static bool operator >=(Money lhs, Money rhs)
        {
            return lhs.value >= rhs.value;
        }

        public static bool operator <=(Money lhs, Money rhs)
        {
            return lhs.value <= rhs.value;
        }

        public static Money operator -(Money lfs, Money rhs)
        {
            Money temp = new Money(0);
            temp.value = lfs.value - rhs.value;
            return temp;
        }

        public static Money operator +(Money lfs, Money rhs)
        {
            Money temp = new Money(0);
            temp.value = lfs.value + rhs.value;
            return temp;
        }

    }
}

