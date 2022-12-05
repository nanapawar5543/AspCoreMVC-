using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookstoreContext _context = null;
        public LanguageRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetallLanguages()
        {
            var languages = await _context.Languages.Select(x => new LanguageModel() { 
                ID= x.ID,
                Name= x.Name,
                Description= x.Description
            }).ToListAsync();
            return languages;
        }
    }
}
