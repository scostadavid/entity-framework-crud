using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EF_CRUD.Models;
using EF_CRUD.Data;

namespace EF_CRUD.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public Pagination<Phone> Phone  {get; set;}
        public string NameSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Phone> query = from p in _context.Phone select p;


                switch (sortOrder)
                {
                    case "name_desc":
                        query = query.OrderByDescending(s => s.PhoneNumber);
                        break;
                    default:
                        query = query.OrderBy(s => s.PhoneNumber);
                        break;
                }

                var pageSize = Configuration.GetValue("PageSize", 20);

                Phone = await Pagination<Phone>.CreateAsync(
                    query.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
