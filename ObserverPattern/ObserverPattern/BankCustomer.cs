using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class BankCustomer : IBeneficiary
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BankCustomer(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }

        public void Notify(IAccount account)
        {
            Console.WriteLine($"SMS Notification for {this.FirstName} {this.LastName}: The amount of account with IBAN {account.IBAN} changed to {String.Format("{0:0.00} EUR", account.GetBalance())}");
        }
    }
}
