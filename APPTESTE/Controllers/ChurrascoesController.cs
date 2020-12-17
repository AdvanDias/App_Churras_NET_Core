using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPTESTE.Models;

namespace APPTESTE.Controllers
{
    public class ChurrascoesController : Controller
    {
        private readonly Context _context;

        public ChurrascoesController(Context context)
        {
            _context = context;
        }

        // GET: Churrascoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Churrascos.ToListAsync());
        }

        // GET: Churrascoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churrasco = await _context.Churrascos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churrasco == null)
            {
                return NotFound();
            }

            return View(churrasco);
        }

        // GET: Churrascoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Churrascoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Data,Observacoes")] Churrasco churrasco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(churrasco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(churrasco);
        }

        // GET: Churrascoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churrasco = await _context.Churrascos.FindAsync(id);
            if (churrasco == null)
            {
                return NotFound();
            }
            return View(churrasco);
        }

        // POST: Churrascoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Data,Observacoes")] Churrasco churrasco)
        {
            if (id != churrasco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(churrasco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurrascoExists(churrasco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(churrasco);
        }

        // GET: Churrascoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churrasco = await _context.Churrascos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churrasco == null)
            {
                return NotFound();
            }

            return View(churrasco);
        }

        // POST: Churrascoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var churrasco = await _context.Churrascos.FindAsync(id);
            _context.Churrascos.Remove(churrasco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChurrascoExists(int id)
        {
            return _context.Churrascos.Any(e => e.Id == id);
        }
    }
}
