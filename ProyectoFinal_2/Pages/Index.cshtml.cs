using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_2.Data;
using ProyectoFinal_2.Models;

namespace ProyectoFinal_2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataBaseContext _contexto;

        public IndexModel(DataBaseContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Productos> Productos { get; set; }

        public async Task OnGet()
        {
            Productos = await _contexto.Productos.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {

            var producto = await _contexto.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _contexto.Productos.Remove(producto);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
 
        }

        public async Task<IActionResult> OnPostAuditado(int id)
        {

            var auditar = await _contexto.Productos.FindAsync(id);
            if (auditar == null)
            {
                return NotFound();
            }

            auditar.Auditado = true;
            auditar.FechaControl = DateTime.Today;

            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}