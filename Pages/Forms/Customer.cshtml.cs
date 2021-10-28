using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BespokenBikes.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using BespokenBikes.Data;

namespace BespokenBikes.Pages.Forms
{
    public class CustomerModel : PageModel
    {

        private readonly ICustomerRepository _customerRepo;
        public CustomerModel(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }




        [BindProperty]
        public ProductEntity Product { get; set; }
        [BindProperty]
        public CustomerEntity Customer { get; set; }
        [BindProperty]
        public List<CustomerEntity> Customers { get; set; }
        [BindProperty]
        public DiscountEntity Discount { get; set; }
        [BindProperty]
        public SalesPersonEntity SalesPerson { get; set; }

        public void OnGet()
        {
            // populate the table
            Customers = _customerRepo.GetAll();
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _customerRepo.Add(Customer);
            return RedirectToPage("/Forms/Customer");
        }

        public IActionResult OnPostDelete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _customerRepo.Delete(id);
            return RedirectToPage("/Forms/Customer");
        }

        public void OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                _customerRepo.Add(Customer);
            }
            _customerRepo.Update(Customer);
            RedirectToPage("/Forms/Customer");
        }
    }
}
