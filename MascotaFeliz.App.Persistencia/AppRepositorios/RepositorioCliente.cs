using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioCliente:IRepositorioCliente   //Se crea clase para implementar la interface IRepositorioCliente
    {
        private readonly AppContext _appContext;   //Referenciar al contexto del Cliente

        public RepositorioCliente(AppContext appContext)   //Constructor
        {
            _appContext = appContext;   //Le decimos que la variable AppContext va a ser igual que lo que recibamos en appContext
        }   
        //
        //Implementar los métodos que habiamos firmado en IRepositorioCliente
        //
        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);   //declarar variable con "var" para adicionar paciente
            _appContext.SaveChanges();   //Guarda los cambios
            return clienteAdicionado.Entity;   //Retorna el cliente y lo adiciona en la Base de Datos
        }


        IEnumerable<Cliente> IRepositorioCliente.GetAllCliente()
        {
            return _appContext.Clientes;   //Retorna todos los Clientes que están en la base de datos
        }   


        Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
           var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.ID == cliente.ID);   //ID es la llave primaria de la entidad Persona
           if (clienteEncontrado != null)
           {
               clienteEncontrado.IdPersona = cliente.IdPersona;  
               clienteEncontrado.Nombre = cliente.Nombre;             
               clienteEncontrado.Apellido = cliente.Apellido;
               clienteEncontrado.NumeroTelefono = cliente.NumeroTelefono;
               clienteEncontrado.DireccionCliente = cliente.DireccionCliente;
               clienteEncontrado.Afiliado = cliente.Afiliado;

               _appContext.SaveChanges();
           }
           return clienteEncontrado;
        }


        void IRepositorioCliente.DeleteCliente(int IdPersona)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.ID == IdPersona);  //ID es la llave primaria de la entidad Persona
            if (clienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(clienteEncontrado);
            _appContext.SaveChanges();
            {
                
            }
        }


        Cliente IRepositorioCliente.GetCliente(int IdPersona)
        {
           return _appContext.Clientes.FirstOrDefault(c => c.ID == IdPersona);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }
    }
}