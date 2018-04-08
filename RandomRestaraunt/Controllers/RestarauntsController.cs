using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomRestaraunt.Data.Models;
using RandomRestaraunt.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RandomRestaraunt.Controllers
{
    public class RestarauntsController : BaseController
    {
        public RestarauntsController(RandomRestarauntContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        // GET: Restaraunts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaraunts.AsNoTracking().OrderBy(x => x.Name).ToListAsync());
        }

        // GET: Restaraunts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var restaraunt = await _context.Restaraunts
                .SingleOrDefaultAsync(m => m.Id == id);

            if (restaraunt == null)
                return NotFound();

            return View(restaraunt);
        }

        // GET: Restaraunts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaraunts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restaraunt restaraunt)
        {
            if (ModelState.IsValid)
            {
                RestarauntService restarauntService = new RestarauntService(_configuration);
                restaraunt.ImageUrl = restarauntService.GetImage(restaraunt.Name);
                _context.Add(restaraunt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaraunt);
        }

        // GET: Restaraunts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var restaraunt = await _context.Restaraunts.SingleOrDefaultAsync(m => m.Id == id);
            if (restaraunt == null)
                return NotFound();

            return View(restaraunt);
        }

        // POST: Restaraunts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Restaraunt restaraunt, IFormFile image)
        {
            if (id != restaraunt.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    RestarauntService restarauntService = new RestarauntService(_configuration);
                    restaraunt.ImageUrl = restarauntService.GetImage(restaraunt.Name);
                    if (image != null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            image.CopyTo(stream);
                            restaraunt.Image = stream.ToArray();
                        }
                    }
                    _context.Update(restaraunt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestarauntExists(restaraunt.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Details), new { id = restaraunt.Id });
            }
            return View(restaraunt);
        }

        // GET: Restaraunts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var restaraunt = await _context.Restaraunts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (restaraunt == null)
                return NotFound();

            return View(restaraunt);
        }

        // POST: Restaraunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaraunt = await _context.Restaraunts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Restaraunts.Remove(restaraunt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestarauntExists(int id)
        {
            return _context.Restaraunts.Any(e => e.Id == id);
        }
    }
}
