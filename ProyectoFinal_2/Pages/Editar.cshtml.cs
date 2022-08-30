using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal_2.Data;
using ProyectoFinal_2.Models;

namespace ProyectoFinal_2.Pages
{
    public class EditarModel : PageModel
    {
        private readonly DataBaseContext _contexto;

        public EditarModel(DataBaseContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Productos Productos { get; set; }

        public async Task OnGet(int id)
        {
            Productos = await _contexto.Productos.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProductoDesdeBD = await _contexto.Productos.FindAsync(Productos.Id);
                ProductoDesdeBD.Codigo = Productos.Codigo;
                ProductoDesdeBD.Nombre = Productos.Nombre;
                ProductoDesdeBD.Cantidad = Productos.Cantidad;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
