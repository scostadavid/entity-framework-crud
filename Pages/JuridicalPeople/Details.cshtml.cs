using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_CRUD.Models;

namespace EF_CRUD.Pages.JuridicalPeople
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public JuridicalPerson JuridicalPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JuridicalPerson = await _context.JuridicalPeople.FirstOrDefaultAsync(m => m.ClientID == id);

            if (JuridicalPerson == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
