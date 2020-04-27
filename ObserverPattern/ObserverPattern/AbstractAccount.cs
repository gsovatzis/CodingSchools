using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public abstract class AbstractAccount : IAccount
    {

        List<IBeneficiary> accountBeneficiaries = new List<IBeneficiary>();

        public string IBAN { get; set; }

        public void Attach(IBeneficiary beneficiary)
        {
            if(!accountBeneficiaries.Contains(beneficiary))
            {
                accountBeneficiaries.Add(beneficiary);
            }
        }

        public void Detach(IBeneficiary beneficiary)
        {
            accountBeneficiaries.Remove(beneficiary);
        }

        public void Notify()
        {
            foreach(IBeneficiary beneficiary in accountBeneficiaries)
            {
                beneficiary.Notify(this);
            }
        }

        // methods to be implemented with specific type of accounts
        public abstract void Withdraw(double amount);
        public abstract void Deposit(double amount);
        public abstract double GetBalance();
    }
}
