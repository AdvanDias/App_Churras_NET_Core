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
    public class ParticipantesController : Controller
    {
        private readonly Context _context;

        public ParticipantesController(Context context)
        {
            _context = context;
        }

        // GET: Participantes
        public async Task<IActionResult> Index(string id)
        {
            var filtroPartic = from m in _context.Participantes.Include(e => e.Churrasco)
                               select m;
            if (!String.IsNullOrEmpty(id))
            {
                var id_churrasco = Convert.ToUInt32(id);
                filtroPartic = filtroPartic.Where(s => s.Churrasco.Id == id_churrasco);
                return View(await filtroPartic.ToListAsync());
            }

            var context = _context.Participantes.Include(p => p.Churrasco);
            return View(await context.ToListAsync());
        }

        // GET: Participantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .Include(p => p.Churrasco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // GET: Participantes/Create
        public IActionResult Create()
        {
            ViewData["ChurrascoId"] = new SelectList(_context.Churrascos, "Id", "Nome");
            return View();
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,V_Com,ChurrascoId")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participante);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Redirect("/Churrascoes");
            }
            ViewData["ChurrascoId"] = new SelectList(_context.Churrascos, "Id", "Nome", participante.ChurrascoId);
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            ViewData["ChurrascoId"] = new SelectList(_context.Churrascos, "Id", "Nome", participante.ChurrascoId);
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,V_Com,ChurrascoId")] Participante participante)
        {
            if (id != participante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.Id))
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
            ViewData["ChurrascoId"] = new SelectList(_context.Churrascos, "Id", "Nome", participante.ChurrascoId);
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .Include(p => p.Churrasco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.Id == id);
        }
    }
}
