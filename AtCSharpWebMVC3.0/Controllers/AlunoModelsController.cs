using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtCSharpWebMVC3._0.Data;
using AtCSharpWebMVC3._0.Models;

namespace AtCSharpWebMVC3._0.Controllers
{
    public class AlunoModelsController : Controller
    {
        private readonly AtCSharpWebMVC3_0Context _context;
        private IWebHostEnvironment _environment;

        public AlunoModelsController(AtCSharpWebMVC3_0Context context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: AlunoModels
        public async Task<IActionResult> Index()
        {
              return _context.AlunoModel != null ? 
                          View(await _context.AlunoModel.ToListAsync()) :
                          Problem("Entity set 'AtCSharpWebMVC3_0Context.AlunoModel'  is null.");
        }

        // GET: AlunoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunoModel == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // GET: AlunoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Idade,DateTime,ImageFile,Upload,ImageFileName")] AlunoModel alunoModel)
        {
                if(alunoModel.Upload != null)
                {
                    alunoModel.ImageFileName = alunoModel.Upload.FileName;
                    var file = Path.Combine(_environment.ContentRootPath,
                        "wwwroot/imagens",
                        alunoModel.Upload.FileName);
                    using (var filestream = new FileStream(file, FileMode.Create))
                    {
                        alunoModel.Upload.CopyTo(filestream);
                    }
                }
            alunoModel.ImageFile = alunoModel.ImageFileName;
            alunoModel.DateTime = DateTime.Now;
            _context.Add(alunoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         
        }

        // GET: AlunoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunoModel == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel.FindAsync(id);
            if (alunoModel == null)
            {
                return NotFound();
            }
            return View(alunoModel);
        }

        // POST: AlunoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlunoModel alunoModel)
        {
            
            if (id != alunoModel.Id)
            {
                return NotFound();
            }

            
                try
                {

                        alunoModel.ImageFileName = alunoModel.Upload.FileName;
                        var file1 = Path.Combine
                            (_environment.ContentRootPath
                            , "wwwroot/imagens"
                            , alunoModel.Upload.FileName);

                        using (var filestream = new FileStream(file1, FileMode.Create))
                        {
                            alunoModel.Upload.CopyTo(filestream);
                        }


                alunoModel.ImageFile = alunoModel.ImageFileName;
                    alunoModel.DateTime = DateTime.Now;
                    

                    _context.Update(alunoModel);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoModelExists(alunoModel.Id))
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

        // GET: AlunoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunoModel == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // POST: AlunoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunoModel == null)
            {
                return Problem("Entity set 'AtCSharpWebMVC3_0Context.AlunoModel'  is null.");
            }
            var alunoModel = await _context.AlunoModel.FindAsync(id);
            if (alunoModel != null)
            {
                _context.AlunoModel.Remove(alunoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoModelExists(int id)
        {
          return (_context.AlunoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
