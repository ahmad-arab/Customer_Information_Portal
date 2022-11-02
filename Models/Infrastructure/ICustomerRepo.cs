using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infrastructure
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        void Delete(int id);
        void Update(Customer customer);
        void Insert(Customer customer);
        Task SaveAsync();
    }
}
