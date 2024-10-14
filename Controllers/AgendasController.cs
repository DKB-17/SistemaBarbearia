using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static SistemaBarbearia.Models.Agenda;

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
            var contexto = _context.Agendas.Include(a => a.barbeiro)
                                            .Include(a => a.cliente)
                                            .Include(a => a.horario)
                                            .Include(a => a.servicos);
                                            
            ViewBag.Agendas = await _context.Agendas.ToListAsync();
            ViewBag.Servicos = await _context.Servicos.ToListAsync();
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
        public async Task<IActionResult> Create()
        {

            var sTrabalho = Enum.GetValues(typeof(trabalho)).Cast<trabalho>().Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() });
            ViewBag.sTrabalho = sTrabalho;

            ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "nome");
            ViewBag.Servicos = await _context.Servicos.ToListAsync();
            ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "inicio");
            return View();
        }

        // POST: Agendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, nome, cpf, telefone")] Cliente cliente, [Bind("id,barbeiroID,clienteId,horarioId,diaAgendado,valor_total")] Agenda agenda, string[] servicosCheck)
        {
            
            if (ModelState.IsValid)
            {
                
                if (servicosCheck != null)
                {
                    foreach (var servicoId in servicosCheck)
                    {
                        Servico s = _context.Servicos.Find(int.Parse(servicoId));
                        agenda.servicos.Add(s);
                    }
                }
                if (!(_context.Clientes.Any(c => c.cpf == cliente.cpf)))
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                }
                agenda.clienteId = _context.Clientes.FirstOrDefault(s => s.cpf == cliente.cpf).id;
                agenda.trabalhoStatus = trabalho.Falta;
                _context.Add(agenda);
                await _context.SaveChangesAsync();
            }
            //ViewData["barbeiroID"] = new SelectList(_context.Barbeiros, "id", "nome", agenda.barbeiroID);
            //ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "cpf", agenda.clienteId);
            //ViewData["horarioId"] = new SelectList(_context.Horarios, "id", "inicio", agenda.horarioId);
            return RedirectToAction(nameof(Index));
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
                var cx = await _context.Caixas.FirstOrDefaultAsync(m => m.dia.Equals(agenda.diaAgendado));
                if (cx != null)
                {
                    cx.lucro -= agenda.valor_total;
                    if (cx.lucro < 0)
                    {
                        cx.lucro = 0;
                    }
                    _context.Update(cx);
                }

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
