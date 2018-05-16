using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AdvWorksDataService : IAdvWorksDataService
    {
        public List<Customer> GetCustomers()
        {
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            DbSet<Customer> customers = dbContext.Customers;
            return customers.ToList();
        }

        public List<Customer> GetCustomer(int value)
        {
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            DbSet<Customer> customers = dbContext.Customers;
            return customers.Where(p => p.CustomerID == value).ToList();
        }
    }
}
