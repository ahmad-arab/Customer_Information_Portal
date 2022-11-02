using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Infrastructure;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.Service
{
    public class CustomerRepo : ICustomerRepo
    {
        private CustomerInfoContext _customerInfoContext;

        public CustomerRepo(CustomerInfoContext customerInfoContext)
        {
            _customerInfoContext = customerInfoContext;
        }

        public void Delete(int id)
        {
            Customer? customer = _customerInfoContext.Customers.Include(x=> x.CustomerAddresses).Where(x => x.Id == id).FirstOrDefault();
            if (customer == null) return;
            //_customerInfoContext.Customers.Attach(customer);
            _customerInfoContext.Customers.Remove(customer);
            _customerInfoContext.SaveChanges();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerInfoContext.Customers.
                Include(x => x.Country).
                Include(x => x.CustomerAddresses).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _customerInfoContext.Customers.
                Include(x => x.Country).
                Include(x => x.CustomerAddresses).
                Where(x => x.Id == id).
                FirstOrDefaultAsync();
        }

        public void Insert(Customer customer)
        {
            _customerInfoContext.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _customerInfoContext.Customers.Update(customer);
        }
        public async Task SaveAsync()
        {
            await _customerInfoContext.SaveChangesAsync();
        }
    }
}
