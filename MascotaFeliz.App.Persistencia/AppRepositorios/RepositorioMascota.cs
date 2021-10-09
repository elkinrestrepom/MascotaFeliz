using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota:IRepositorioMascota   //Se crea clase para implementar la interface IRepositorioCliente
    {
        private readonly AppContext _appContext;   //Referenciar al contexto del Cliente

        public RepositorioMascota(AppContext appContext)   //Constructor
        {
            _appContext = appContext;   //Le decimos que la variable AppContext va a ser igual que lo que recibamos en appContext
        }   
        //
        //Implementar los métodos que habiamos firmado en IRepositorioCliente
        //
        Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionado = _appContext.Mascotas.Add(mascota);   //declarar variable con "var" para adicionar paciente
            _appContext.SaveChanges();   //Guarda los cambios
            return mascotaAdicionado.Entity;   //Retorna el cliente y lo adiciona en la Base de Datos
        }


        IEnumerable<Mascota> IRepositorioMascota.GetAllMascota()
        {
            return _appContext.Mascotas;   //Retorna todos los Clientes que están en la base de datos
        }   


        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota)
        {
           var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(c => c.ID == mascota.ID);   //ID es la llave primaria de la entidad Persona
           if (mascotaEncontrado != null)
           {
               mascotaEncontrado.IdMascota = mascota.IdMascota;  
               mascotaEncontrado.NombreMascota = mascota.NombreMascota;             
               mascotaEncontrado.Raza = mascota.Raza;
               mascotaEncontrado.TipoMascota = mascota.TipoMascota;
               mascotaEncontrado.Cliente = mascota.Cliente;

               _appContext.SaveChanges();
           }
           return mascotaEncontrado;
        }


        void IRepositorioMascota.DeleteMascota(int IdMascota)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(c => c.ID == IdMascota);  //ID es la llave primaria de la entidad Persona
            if (mascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
            {
                
            }
        }


        Mascota IRepositorioMascota.GetMascota(int IdMascota)
        {
           return _appContext.Mascotas.FirstOrDefault(c => c.ID == IdMascota);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }
    }
}