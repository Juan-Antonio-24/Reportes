using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Reportes.Models;

namespace Gestion_Reportes.Controllers
{
    public class ReportesController : Controller
    {
        private readonly Gestion_Reportes_DBModel _context;

        public ReportesController(Gestion_Reportes_DBModel context)
        {
            _context = context;
        }

        // GET: Reportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reportes.ToListAsync());
        }

        // GET: Reportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reportes
                .FirstOrDefaultAsync(m => m.Id_Reporte == id.Value);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // GET: Reportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reportes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Reporte,Nombre,Descripcion,UrlReporte,UrlVistaPrevia")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reportes.FindAsync(id.Value);
            if (reporte == null)
            {
                return NotFound();
            }
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Reporte,Nombre,Descripcion,UrlReporte,UrlVistaPrevia")] Reporte reporte)
        {
            if (id != reporte.Id_Reporte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteExists(reporte.Id_Reporte))
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
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reportes
                .FirstOrDefaultAsync(m => m.Id_Reporte == id.Value);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte != null)
            {
                _context.Reportes.Remove(reporte);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteExists(int id)
        {
            return _context.Reportes.Any(e => e.Id_Reporte == id);
        }

        public IActionResult PanelReportes()
        {
            var reportes = _context.Reportes.ToList();
            return View(reportes);
        }

        public IActionResult VistaReporte(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reporte = _context.Reportes.FirstOrDefault(r => r.Id_Reporte == id.Value);
            if (reporte == null)
            {
                return NotFound();
            }

            ViewBag.NombreReporte = reporte.Nombre;
            ViewBag.UrlReporte = reporte.UrlReporte;
            return View(reporte);
        }
    }
}
