using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class _RegistroClientesModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;
        public Cliente Cliente { get; set; }

        public _RegistroClientesModel(IRepositorioCliente repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public IActionResult OnGet(int saludoId)
        {
            Cliente = repositorioClientes.GetClientePorId(saludoId);
            if(Cliente==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}
