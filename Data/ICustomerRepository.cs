using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokenBikes.Models;
namespace BespokenBikes.Data
{
    public interface ICustomerRepository
    {
        public void Add(CustomerEntity Customer);
        public List<CustomerEntity> GetAll();
        public void Delete(int id);
        
        public void Update(CustomerEntity Customer);
        public CustomerEntity Find(int id);
    }
}
