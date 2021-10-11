
using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Persistencia.AppRepositorios;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.Contexto());
        
        static void Main(string[] args)
        {

            Console.WriteLine("Escriba el IdPersona:");
            string id = Console.ReadLine();
            Console.WriteLine("Escriba el nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Escriba el apellido:");
            string last = Console.ReadLine();
            Console.WriteLine("Escriba el teléfono:");
            string phone = Console.ReadLine();
            Console.WriteLine("Escriba la dirección:");
            string address = Console.ReadLine();

            Cliente cliente = new Cliente(){
                idPersona = id,
                nombres = name,
                apellidos = last,
                telefono = phone,
                direccion = address,
            };
            
            AddCliente();
            BuscarCliente(1);
        }

        private static void AddCliente()
        {
            var cliente = new Cliente{
                idPersona = "00001",
                nombres = "Elkin",
                apellidos = "Restrepo",
                telefono = "3006094015",
                direccion = "Cedritos, Bogotá",
               
            };
            var cliente2 = new Cliente{
                idPersona = "00002",
                nombres = "Mayra",
                apellidos = "Ospina",
                telefono = "3008945210",
                direccion = "Villa Colombia, Cali",
                
            };
            var cliente3 = new Cliente{
                idPersona = "00003",
                nombres = "Diana",
                apellidos = "Gómez",
                telefono = "3017841308",
                direccion = "NN, Bogotá",
               
            };
            var cliente4 = new Cliente{
                idPersona = "00004",
                nombres = "Dumar",
                apellidos = "Rojas",
                telefono = "3168684393",
                direccion = "NN, Bogotá",
                
            };
            var cliente5 = new Cliente{
                idPersona = "00005",
                nombres = "Jorge",
                apellidos = "Moncada",
                telefono = "3002596457",
                direccion = "El Caney, Cali",
                
            };
            _repoCliente.AddCliente(cliente);   //llamar al método para agregar al cliente en la base de datos
            _repoCliente.AddCliente(cliente2);
            _repoCliente.AddCliente(cliente3);
            _repoCliente.AddCliente(cliente4);
            _repoCliente.AddCliente(cliente5);
        }

        private static void BuscarCliente(int idCliente)
        {
            var cliente = _repoCliente.GetCliente(idCliente);
            Console.WriteLine("Cliente:"+" "+cliente.nombres+" "+cliente.apellidos);
        }
    }
}
