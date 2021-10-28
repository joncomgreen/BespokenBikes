using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BespokenBikes.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BespokenBikes.Data
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private readonly IConfiguration _Configuration;

        public SalesPersonRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void Add(SalesPersonEntity SalesPerson)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "SalesPersonProcedures";
                var values = new { type = "Add", FirstName = SalesPerson.FirstName, LastName = SalesPerson.LastName, Address = SalesPerson.Address, Phone = SalesPerson.Phone, StartDate = SalesPerson.StartDate, TerminationDate = SalesPerson.TerminationDate, SalesPerson.Manager };
                var results = connection.Query<SalesPersonEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<SalesPersonEntity> GetAll()
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "SalesPersonProcedures";
                var values = new { type = "GetAll" };
                var results = connection.Query<SalesPersonEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "SalesPersonProcedures";
                var values = new { type = "Delete", Id = id };
                var results = connection.Query<SalesPersonEntity>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Update(SalesPersonEntity SalesPerson)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "SalesPersonProcedures";
                var values = new { type = "Update", Id = SalesPerson.Id, FirstName = SalesPerson.FirstName, LastName = SalesPerson.LastName, Address = SalesPerson.Address, Phone = SalesPerson.Phone, StartDate = SalesPerson.StartDate, TerminationDate = SalesPerson.TerminationDate, SalesPerson.Manager };
                var results = connection.Query<SalesPersonEntity>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
        public SalesPersonEntity Find(int id)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("default")))
            {
                var procedure = "SalesPersonProcedures";
                var values = new { type = "Find", Id = id };
                var results = connection.QueryFirstOrDefault<SalesPersonEntity>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
