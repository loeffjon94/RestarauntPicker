using Microsoft.EntityFrameworkCore;
using RandomRestaraunt.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RandomRestaraunt.Data.Repos
{
    public class RestarauntRepo
    {
        private RandomRestarauntContext _context;

        public RestarauntRepo(RandomRestarauntContext context)
        {
            _context = context;
        }

        public List<Restaraunt> GetUsableRestaraunts()
        {
            return _context.Restaraunts
                .AsNoTracking()
                .Where(x => !x.UsedLast)
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
