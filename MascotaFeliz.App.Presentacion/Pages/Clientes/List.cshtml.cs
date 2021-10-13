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
    public class ListModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;

        public IEnumerable<Cliente> Clientes {get;set;}
        
        public ListModel(IRepositorioCliente repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        public void OnGet()
        {
            Clientes = repositorioClientes.GetAllClientes();
        }
    }
}
