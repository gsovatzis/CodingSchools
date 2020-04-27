using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public interface IAccount
    {
        string IBAN { get; set; }

        // Contracts for the observer pattern
        void Attach(IBeneficiary beneficiary);
        void Detach(IBeneficiary beneficiary);
        void Notify();

        // Account contracts
        void Deposit(double amount);
        void Withdraw(double amount);
        double GetBalance();
    }
}
