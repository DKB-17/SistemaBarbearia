﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Migrations;
using SistemaBarbearia.Models;

namespace SistemaBarbearia.Controllers
{
    public class HorariosController : Controller
    {
        private readonly Contexto _context;

        public HorariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Horarios.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,inicio,fim")] Horario Hrs, TimeOnly intervalo)
        {
            if (ModelState.IsValid)
            {
                List<Horario> listaHrs = new List<Horario>();
                listaHrs.Add(new Horario() {inicio = Hrs.inicio, fim = Hrs.inicio.AddMinutes(intervalo.Minute) });
                if (!HorarioExists(listaHrs[0].inicio) && !HorarioExists(listaHrs[0].fim))
                {
                    for (int i = 0; listaHrs[i].fim < Hrs.fim ; i++)
                    {
                        listaHrs.Add(new Horario() {inicio = listaHrs[i].fim,fim = listaHrs[i].fim.AddMinutes(intervalo.Minute)});

                    }
                    
                    _context.AddRange(listaHrs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));  
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAll()
        {
            var horario = await _context.Horarios.ToListAsync();
            if (horario != null)
            {
                _context.Horarios.RemoveRange(horario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,inicio,fim")] Horario horario)
        {
            if (id != horario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!HorarioExists(horario.inicio))
                    {
                        _context.Update(horario);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.id))
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
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.id == id);
        }

        private bool HorarioExists(TimeOnly intervalor)
        {
            return _context.Horarios.Any(e => intervalor.IsBetween(e.inicio, e.fim));
        }
    }
}
