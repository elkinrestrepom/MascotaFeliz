using System.Collections.Generic;   // librería donde se encuentra definida está interface
using MascotaFeliz.App.Dominio;   // Indicarle donde está la entidad Cliente

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascota();   // Método para retornar la lista de Cliente
        Mascota AddMascota(Mascota mascota);   // Método para adicionar y retorna Cliente
        Mascota UpdateMascota(Mascota mascota);   // Método para Actualizar la Cliente en la BD y lo retorna
        void DeleteMascota(int IdMascota);   // Método para Borrar Cliente según su identificación
        Mascota GetMascota(int IdMascota);   //Método para retornar una Cliente dada su identificación
    }
}