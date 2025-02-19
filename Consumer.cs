using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HomeHealthUnited
{
    internal class Consumer
    {
        private string Identity;
        private int Accounts;
        private double TotalBalance;

        public int ACCOUNTS
        {
            get { return Accounts; }
        }

        public double TOTALBALANCE
        {
            get { return TotalBalance; }
        }

        public Consumer()
        {
            Accounts = 0;
            TotalBalance = 0;
        }
        
        public void addAccount(double accountbalance)
        {
            Accounts++;
            TotalBalance += accountbalance;
        }
    }
}
