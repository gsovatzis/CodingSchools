using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public interface IBeneficiary
    {
        void Notify(IAccount account);
    }
}
