using System.Collections.Generic;   // librería donde se encuentra definida está interface
using MascotaFeliz.App.Dominio;   // Indicarle donde está la entidad Cliente

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAllCliente();   // Método para retornar la lista de Cliente
        Cliente AddCliente(Cliente cliente);   // Método para adicionar y retorna Cliente
        Cliente UpdateCliente(Cliente cliente);   // Método para Actualizar la Cliente en la BD y lo retorna
        void DeleteCliente(int IdPersona);   // Método para Borrar Cliente según su identificación
        Cliente GetCliente(int IdPersona);   //Método para retornar una Cliente dada su identificación
    }
}