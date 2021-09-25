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

namespace EF_CRUD.Pages.JuridicalPeople
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


     
        public Pagination<JuridicalPerson> JuridicalPerson {get; set;}


        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<JuridicalPerson> query = from p in _context.JuridicalPeople select p;


                switch (sortOrder)
                {
                    case "name_desc":
                        query = query.OrderByDescending(s => s.CompanyName);
                        break;
                    default:
                        query = query.OrderBy(s => s.CompanyName);
                        break;
                }

                var pageSize = Configuration.GetValue("PageSize", 20);

                JuridicalPerson = await Pagination<JuridicalPerson>.CreateAsync(
                    query.AsNoTracking(), pageIndex ?? 1, pageSize);
        }        
    }
}
