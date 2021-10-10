using System.Collections.Generic;   // librería donde se encuentra definida está interface
using MascotaFeliz.App.Dominio;   // Indicarle donde está la entidad Cliente

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinario();   // Método para retornar la lista de Cliente
        Veterinario AddVeterinario(Veterinario veterinario);   // Método para adicionar y retorna Cliente
        Veterinario UpdateVeterinario(Veterinario veterinario);   // Método para Actualizar la Cliente en la BD y lo retorna
        void DeleteVeterinario(int IdPersona);   // Método para Borrar Cliente según su identificación
        Veterinario GetVeterinario(int IdPersona);   //Método para retornar una Cliente dada su identificación
    }
}