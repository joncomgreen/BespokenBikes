using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BespokenBikes.Models;
using Dapper;
namespace BespokenBikes.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _Configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void Add(CustomerEntity Customer){
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "CustomerProcedures";
                var values = new { type = "Add", FirstName = Customer.FirstName, LastName = Customer.LastName, Address = Customer.Address, Phone = Customer.Phone, StartDate = Customer.StartDate };
                var results = connection.Query<CustomerEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<CustomerEntity> GetAll()
        {   
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "CustomerProcedures";
                var values = new { type = "GetAll" };
                var results = connection.Query<CustomerEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "CustomerProcedures";
                var values = new { type = "Delete", Id = id };
                var results = connection.Query<CustomerEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public void Update(CustomerEntity Customer)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "CustomerProcedures";
                var values = new { type = "Update", Id = Customer.Id, FirstName = Customer.FirstName, LastName = Customer.LastName, Address = Customer.Address, Phone = Customer.Phone, StartDate = Customer.StartDate};
                var results = connection.Query<CustomerEntity>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
        public CustomerEntity Find(int id)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "CustomerProcedures";
                var values = new { type = "Find", Id = id };
                var results = connection.QueryFirstOrDefault<CustomerEntity>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
        
    }
}
