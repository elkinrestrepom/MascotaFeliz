using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;


namespace MascotaFeliz.App.Frontend.Pages
{
    public class _BuscarClienteModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;
        public IEnumerable<Cliente> Clientes {get;set;}
        public Cliente Cliente { get; set; }

        public _BuscarClienteModel(IRepositorioCliente repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }


        public IActionResult OnGet(int clienteId)
        {
            Cliente = repositorioClientes.GetClientePorId(2);
            if(Cliente==null)
            {
                 return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}
