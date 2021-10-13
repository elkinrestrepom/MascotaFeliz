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
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;

        public Cliente Cliente { get; set; }

        public DeleteModel(IRepositorioCliente repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }

        public IActionResult OnGet(int? idCliente)
        {
            Cliente = repositorioClientes.GetClientePorId(idCliente.Value);
            if(Cliente==null)
            {
                 return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
        
        public IActionResult OnPost(Cliente clienteborrado)
        {
            repositorioClientes.DeleteCliente(clienteborrado.Id);
            return RedirectToPage("../Clientes/List");
        }

    }
}
