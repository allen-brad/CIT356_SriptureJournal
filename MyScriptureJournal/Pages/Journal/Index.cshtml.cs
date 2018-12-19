using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Journal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

       
      
        public string CurrentFilter { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<JournalEntry> JournalEntry { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentSort = sortOrder;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<JournalEntry> journalIQ = from j in _context.JournalEntry
                                            select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                journalIQ = journalIQ.Where(j => j.Book.Contains(searchString) || j.Note.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "book_desc":
                    journalIQ = journalIQ.OrderByDescending(j => j.Book);
                    break;
                case "date_desc":
                    journalIQ = journalIQ.OrderByDescending(j => j.DateAdded);
                    break;
                default:
                    journalIQ = journalIQ.OrderBy(j => j.DateAdded);
                    break;
            }

            int pageSize = 5;

            JournalEntry = await PaginatedList<JournalEntry>.CreateAsync(journalIQ
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
