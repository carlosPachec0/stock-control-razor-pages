using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal_2.Data;
using ProyectoFinal_2.Models;

namespace ProyectoFinal_2.Pages
{
    public class CrearModel : PageModel
    {
        private readonly DataBaseContext _contexto;

        public CrearModel(DataBaseContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Productos Productos { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            //Productos.FechaControl = DateTime.Today;

            _contexto.Add(Productos);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
