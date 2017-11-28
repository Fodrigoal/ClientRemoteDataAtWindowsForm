//
// Collection class created to store the results of the query.
//
// Rodrigo Silva
// November 9, 2016
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Common
{
    public class ClientCollection : BindingList<Client>
    {
        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);

        public int TotalCreditHold => this.Count(x => x.CreditHoldCount > 0);

    }
}
