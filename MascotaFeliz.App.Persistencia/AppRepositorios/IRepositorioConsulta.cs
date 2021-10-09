using System.Collections.Generic;   // librería donde se encuentra definida está interface
using MascotaFeliz.App.Dominio;   // Indicarle donde está la entidad Cliente

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioConsulta
    {
        IEnumerable<Consulta> GetAllConsulta();   // Método para retornar la lista de Cliente
        Consulta AddConsulta(Consulta consulta);   // Método para adicionar y retorna Cliente
        Consulta UpdateConsulta(Consulta consulta);   // Método para Actualizar la Cliente en la BD y lo retorna
        void DeleteConsulta(int IdConsulta);   // Método para Borrar Cliente según su identificación
        Consulta GetConsulta(int IdConsulta);   //Método para retornar una Cliente dada su identificación
    }
}