using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_CRUD.Models;

namespace EF_CRUD.Pages.PhysicalPeople
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public PhysicalPerson PhysicalPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhysicalPerson = await _context.PhysicalPeople.FirstOrDefaultAsync(m => m.ClientID == id);

            if (PhysicalPerson == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
