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
    public class _RegistroClientesModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly IRepositorioCliente repositorioCliente; 
        [BindProperty]
        public Cliente Cliente{get;set;}
        public _RegistroClientesModel(IRepositorioCliente repositorioCliente)  
        {
            this.repositorioCliente = repositorioCliente;
        }
        public IActionResult OnGet(int IdPersona)
        {
            Cliente = repositorioCliente.GetCliente(IdPersona);
            if(Cliente==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();   //No me acuerdo a que se asocia
        }
        public IActionResult OnPost()
        {
            Cliente = repositorioCliente.UpdateCliente(Cliente);
            return Page();
        }

    }
}
