using AMS.UI.Domain.Entities;
using AMS.UI.Infra.MySQLRepo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AMS.UI.UseCases.Customers
{
    public static class CustomerService
    {
        static CustomerRepository repository = new CustomerRepository();

        public static List<Customer> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public static bool Save(Customer customer)
        {
            bool result;

            if(customer.IsPresent)
            {
                result = repository.Update(customer);
            }
            else
            {
                result = repository.Create(customer);
            }

            return result;
        }

        public static bool Delete(Customer customer)
        {
            return repository.Delete(customer);
        }
    }
}
