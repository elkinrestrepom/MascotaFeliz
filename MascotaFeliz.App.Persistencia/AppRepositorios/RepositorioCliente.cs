using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net.Security;
using System.IO.Pipes;
using System.Net.WebSockets;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;


namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioCliente:IRepositorioCliente
    { 
        //private readonly Contexto _contexto;

       /* public RepositorioCliente(Contexto _contexto)
        {
            _contexto = contexto;
        }*/
        List<Cliente> clientes;
       
        public RepositorioCliente()//Contexto contexto)
        {
            //_contexto = contexto;
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

        Cliente IRepositorioCliente.GetClientePorId(int idCliente)
        {
           return clientes.FirstOrDefault(c => c.Id == idCliente);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }


        public Cliente AddCliente(Cliente newCliente)
        {
            newCliente.Id = clientes.Max(r => r.Id) +1;
            clientes.Add(newCliente);
            return newCliente; 
            /*Cliente clienteAgregado = _contexto.Add(cliente).Entity;
            _contexto.SaveChanges();
            return clienteAgregado;*/
        }


        public Cliente UpdateCliente(Cliente updateCliente)
        {
            var cliente = clientes.SingleOrDefault(c=> c.Id == updateCliente.Id);
           //Cliente clienteEditar = Cliente.FirstOrDefault(c => c.Id == Updatecliente.Id);   //Id es la llave primaria de la entidad Persona
           if (cliente != null)
           {
               cliente.idPersona = updateCliente.idPersona;  
               cliente.nombres = updateCliente.nombres;             
               cliente.apellidos = updateCliente.apellidos;
               cliente.telefono = updateCliente.telefono;
               cliente.direccion = updateCliente.direccion;
              
           }
           return cliente;
        }


        public void DeleteCliente(int id)
        {
            var clienteEncontrado = clientes.FirstOrDefault(c => c.Id == id);
            if(clienteEncontrado != null)
            {
               clientes.Remove(clienteEncontrado);  
            }
            
        }




    }
}