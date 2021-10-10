using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario:IRepositorioVeterinario   //Se crea clase para implementar la interface IRepositorioCliente
    {
        private readonly AppContext _appContext;   //Referenciar al contexto del Cliente

        public RepositorioVeterinario(AppContext appContext)   //Constructor
        {
            _appContext = appContext;   //Le decimos que la variable AppContext va a ser igual que lo que recibamos en appContext
        }   
        //
        //Implementar los métodos que habiamos firmado en IRepositorioCliente
        //
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);   //declarar variable con "var" para adicionar paciente
            _appContext.SaveChanges();   //Guarda los cambios
            return veterinarioAdicionado.Entity;   //Retorna el cliente y lo adiciona en la Base de Datos
        }


        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios;   //Retorna todos los Clientes que están en la base de datos
        }   


        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
           var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(c => c.ID == veterinario.ID);   //ID es la llave primaria de la entidad Persona
           if (veterinarioEncontrado != null)
           {
               veterinarioEncontrado.IdPersona = veterinario.IdPersona;  
               veterinarioEncontrado.Nombre = veterinario.Nombre;             
               veterinarioEncontrado.Apellido = veterinario.Apellido;
               veterinarioEncontrado.NumeroTelefono = veterinario.NumeroTelefono;
               veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;

               _appContext.SaveChanges();
           }
           return veterinarioEncontrado;
        }


        void IRepositorioVeterinario.DeleteVeterinario(int IdPersona)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(c => c.ID == IdPersona);  //ID es la llave primaria de la entidad Persona
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
            {
                
            }
        }


        Veterinario IRepositorioVeterinario.GetVeterinario(int IdPersona)
        {
           return _appContext.Veterinarios.FirstOrDefault(c => c.ID == IdPersona);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }
    }
}