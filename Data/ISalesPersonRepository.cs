using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokenBikes.Models;

namespace BespokenBikes.Data
{
    public interface ISalesPersonRepository
    {
        public void Add(SalesPersonEntity SalesPerson);
        public List<SalesPersonEntity> GetAll();
        public void Delete(int id);

        public void Update(SalesPersonEntity SalesPerson);
        public SalesPersonEntity Find(int id);
    }
}
