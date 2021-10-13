using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClientePorId(int idCliente);
        Cliente AddCliente(Cliente newCliente);
        Cliente UpdateCliente(Cliente updateCliente);
        void DeleteCliente(int idCliente);
        
    
    }
}