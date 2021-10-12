using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;


namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioCliente:IRepositorioCliente
    { 
        private readonly Contexto _contexto;

       /* public RepositorioCliente(Contexto _contexto)
        {
            _contexto = contexto;
        }*/
        List<Cliente> clientes;
       
        public RepositorioCliente(Contexto contexto)
        {
            _contexto = contexto;
            clientes = new List<Cliente>()
            {

                new Cliente{Id=1,idPersona="00001",nombres="Elkin", apellidos="Restrepo",telefono="3006094015",direccion="Cedritos, Bogotá"},
                new Cliente{Id=2,idPersona="00002",nombres="Mayra", apellidos="Ospina",telefono="3008945210",direccion="Villa Colombia, Cali"},
                new Cliente{Id=3,idPersona="00003",nombres="Diana", apellidos="Gómez",telefono="3017841308",direccion="Chía, Bogotá"},
                new Cliente{Id=4,idPersona="00004",nombres="Dumar", apellidos="Rojas",telefono="3168684393",direccion="NN, Bogotá"},
                new Cliente{Id=5,idPersona="00005",nombres="Luis", apellidos="Moncada",telefono="3002596457",direccion="El Caney, Cali"}
            };
        }
        

        public IEnumerable<Cliente> GetAllClientes()
        {
            return clientes;
        }


        public Cliente AddCliente(Cliente cliente)
        {
            Cliente clienteAgregado = _contexto.Add(cliente).Entity;
            _contexto.SaveChanges();
            return clienteAgregado;
        }


        Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
           Cliente clienteEditar = _contexto.Clientes.FirstOrDefault(c => c.Id == cliente.Id);   //Id es la llave primaria de la entidad Persona
           if (clienteEditar != null)
           {
               clienteEditar.idPersona = cliente.idPersona;  
               clienteEditar.nombres = cliente.nombres;             
               clienteEditar.apellidos = cliente.apellidos;
               clienteEditar.telefono = cliente.telefono;
               clienteEditar.direccion = cliente.direccion;
              
               _contexto.SaveChanges();
           }
           return clienteEditar;
        }


        Cliente IRepositorioCliente.GetClientePorId(int idCliente)
        {
           return clientes.FirstOrDefault(c => c.Id == idCliente);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }
    }
}