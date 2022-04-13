using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWeb.Areas.Identity.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class ContacsController : Controller
    {
        private readonly Contexto _context;
        private UserManager<SistemaWebUser> _userManeger;

        public ContacsController(Contexto context, UserManager<SistemaWebUser> userManeger)
        {
            _context = context;
            _userManeger = userManeger;

        }

        // GET: Contacs
        public async Task<IActionResult> Index()
        {
            var usuario = _userManeger.GetUserId(User);
            var contexto = _context.Contacs.Include(c => c.Classificacao).Include(c => c.Tipo).Where(c => c.UsuarioId == usuario);
            
            return View(await contexto.ToListAsync());
        }

        // GET: Contacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacs = await _context.Contacs
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contacs == null)
            {
                return NotFound();
            }

            return View(contacs);
        }

        // GET: Contacs/Create
        public IActionResult Create()
        {
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "nomec");
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "nome");
            return View();
        }

        // POST: Contacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConta,descricao,dataPagamento,valor,dataVencimento,UsuarioId,TipoId,ClassificacaoId")] Contacs contacs)
        {
            if (ModelState.IsValid)
            {

                var usuario = _userManeger.GetUserId(User);
                contacs.UsuarioId = usuario;

                _context.Add(contacs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "nomec");
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "nome");
            return View(contacs);
        }

        // GET: Contacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacs = await _context.Contacs.FindAsync(id);
            if (contacs == null)
            {
                return NotFound();
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "nomec", contacs.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "nome", contacs.TipoId);
            return View(contacs);
        }

        // POST: Contacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConta,descricao,dataPagamento,valor,dataVencimento,UsuarioId,TipoId,ClassificacaoId")] Contacs contacs)
        {
            if (id != contacs.IdConta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = _userManeger.GetUserId(User);
                    contacs.UsuarioId = usuario;
                    _context.Update(contacs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContacsExists(contacs.IdConta))
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
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "nomec", contacs.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "nome", contacs.TipoId);
            return View(contacs);
        }

        // GET: Contacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacs = await _context.Contacs
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contacs == null)
            {
                return NotFound();
            }

            return View(contacs);
        }

        // POST: Contacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacs = await _context.Contacs.FindAsync(id);
            _context.Contacs.Remove(contacs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContacsExists(int id)
        {
            return _context.Contacs.Any(e => e.IdConta == id);
        }
    }
}
