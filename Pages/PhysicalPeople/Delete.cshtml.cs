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
    public class DeleteModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhysicalPerson = await _context.PhysicalPeople.FindAsync(id);

            if (PhysicalPerson != null)
            {
                _context.PhysicalPeople.Remove(PhysicalPerson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
