using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class _RegistroVeterinariosModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly IRepositorioVeterinario repositorioVeterinario; 
        [BindProperty]
        public Veterinario Veterinario{get;set;}
        public _RegistroVeterinariosModel(IRepositorioVeterinario repositorioVeterinario)   //El error puede ser lo que esta en IRepositorioCliente:  Cliente UpdateCliente(Cliente cliente);
        {
            this.repositorioVeterinario = repositorioVeterinario;
        }
        public IActionResult OnGet(int IdPersona)
        {
            Veterinario = repositorioVeterinario.GetVeterinario(IdPersona);
            if(Veterinario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();   //No me acuerdo a que se asocia
        }
        public IActionResult OnPost()
        {
            Veterinario = repositorioVeterinario.UpdateVeterinario(Veterinario);
            return Page();
        }

    }
}
