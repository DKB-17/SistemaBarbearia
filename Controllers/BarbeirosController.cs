using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Models;

namespace SistemaBarbearia.Controllers
{
    public class BarbeirosController : Controller
    {
        private readonly Contexto _context;

        public BarbeirosController(Contexto context)
        {
            _context = context;
        }

        // GET: Barbeiros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barbeiros.ToListAsync());
        }

        // GET: Barbeiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbeiro = await _context.Barbeiros
                .FirstOrDefaultAsync(m => m.id == id);
            if (barbeiro == null)
            {
                return NotFound();
            }

            return View(barbeiro);
        }

        // GET: Barbeiros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barbeiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cpf,telefone")] Barbeiro barbeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barbeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barbeiro);
        }

        // GET: Barbeiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbeiro = await _context.Barbeiros.FindAsync(id);
            if (barbeiro == null)
            {
                return NotFound();
            }
            return View(barbeiro);
        }

        // POST: Barbeiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cpf,telefone")] Barbeiro barbeiro)
        {
            if (id != barbeiro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barbeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarbeiroExists(barbeiro.id))
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
            return View(barbeiro);
        }

        // GET: Barbeiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbeiro = await _context.Barbeiros
                .FirstOrDefaultAsync(m => m.id == id);
            if (barbeiro == null)
            {
                return NotFound();
            }

            return View(barbeiro);
        }

        // POST: Barbeiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barbeiro = await _context.Barbeiros.FindAsync(id);
            if (barbeiro != null)
            {
                _context.Barbeiros.Remove(barbeiro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarbeiroExists(int id)
        {
            return _context.Barbeiros.Any(e => e.id == id);
        }
    }
}
