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
    public class AgendasController : Controller
    {
        private readonly Contexto _context;

        public AgendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Agendas.Include(a => a.barbeiro).Include(a => a.cliente).Include(a => a.horario);
            return View(await contexto.ToListAsync());
        }

        // GET: Agendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .Include(a => a.barbeiro)
                .Include(a => a.cliente)
                .Include(a => a.horario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agendas/Create
        public IActionResult Create()
        {
            ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "cpf");
            ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "cpf");
            ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "id");
            return View();
        }

        // POST: Agendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,barbeiroID,clienteId,horarioId,diaAgendado,trabalhoStatus,valor_total,tempo_total,idCaixa")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "cpf", agenda.barbeiroID);
            ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "cpf", agenda.clienteId);
            ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "id", agenda.horarioId);
            return View(agenda);
        }

        // GET: Agendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "cpf", agenda.barbeiroID);
            ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "cpf", agenda.clienteId);
            ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "id", agenda.horarioId);
            return View(agenda);
        }

        // POST: Agendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,barbeiroID,clienteId,horarioId,diaAgendado,trabalhoStatus,valor_total,tempo_total,idCaixa")] Agenda agenda)
        {
            if (id != agenda.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.id))
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
            ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "cpf", agenda.barbeiroID);
            ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "cpf", agenda.clienteId);
            ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "id", agenda.horarioId);
            return View(agenda);
        }

        // GET: Agendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .Include(a => a.barbeiro)
                .Include(a => a.cliente)
                .Include(a => a.horario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda != null)
            {
                _context.Agendas.Remove(agenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.id == id);
        }
    }
}
