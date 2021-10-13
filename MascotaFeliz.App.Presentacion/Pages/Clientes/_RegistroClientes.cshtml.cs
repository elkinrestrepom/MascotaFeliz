using System.Linq.Expressions;
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
        
        [BindProperty]
        public Cliente Cliente { get; set; }

        public _RegistroClientesModel(IRepositorioCliente repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }

        public IActionResult OnGet(int? idCliente)
        {
            if(idCliente.HasValue)
            {
                Cliente = repositorioClientes.GetClientePorId(idCliente.Value);
            }
            else
            {
                Cliente = new Cliente();
            }
            if(Cliente==null)
            {
                 return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }

        public IActionResult OnPost()
        {
            try
            {
               if(Cliente.Id>0)
                {
                    Cliente = repositorioClientes.UpdateCliente(Cliente);
                }
                else
                {
                    repositorioClientes.AddCliente(Cliente);
                }
                return Page(); 
            }
            catch
            {
                return RedirectToPage("../Error");
            }
            
        }
    }
}
