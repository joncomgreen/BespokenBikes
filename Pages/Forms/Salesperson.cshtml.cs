using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokenBikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BespokenBikes.Data; 

namespace BespokenBikes.Pages.Forms
{
    public class SalespersonModel : PageModel
    {

        private readonly ISalesPersonRepository _SalesPersonRepo;
        public SalespersonModel(ISalesPersonRepository SalesPersonRepository)
        {
            _SalesPersonRepo = SalesPersonRepository;
        }

        [BindProperty]
        public List<SalesPersonEntity> SalesPersonEntities { get; set; }
        [BindProperty]
        public SalesPersonEntity SalesPerson { get; set; }

        public void OnGet()
        {
            SalesPersonEntities = _SalesPersonRepo.GetAll();
        }

        public IActionResult OnPostAdd()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _SalesPersonRepo.Add(SalesPerson);
            return RedirectToPage("/Forms/SalesPerson");
        }

        public IActionResult OnPostDelete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _SalesPersonRepo.Delete(id);
            return RedirectToPage("/Forms/SalesPerson");
        }

        public void OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                _SalesPersonRepo.Add(SalesPerson);
            }
            _SalesPersonRepo.Update(SalesPerson);
            RedirectToPage("/Forms/SalesPerson");
        }
    }
}
