using System.Net.Security;
using System.Net.WebSockets;
using System.Net.Http;
//using Internal;
using System.Collections.Generic;
using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());   //Declarar referencia al Repositorio de Clientes
        private static IRepositorioConsulta _repoConsulta = new RepositorioConsulta(new Persistencia.AppContext());   //Declarar referencia al Repositorio de Clientes
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());   //Declarar referencia al Repositorio de Clientes

        static void Main(string[] args)
        {
            Console.WriteLine("VETERINARIA MASCOTA FELIZ");
            AddCliente();   //llamar primero los métodos antes de crear las bases de datos
            BuscarCliente(1);
            AddConsulta();
            BuscarConsulta(1);
            AddMascota();
            BuscarMascota(1);
        }

        //Clientes
        private static void AddCliente()   //creación de datos de clientes en la base de datos
        {
            var cliente = new Cliente()
            {
                IdPersona = 00001,
                Nombre = "Elkin",
                Apellido = "Restrepo",
                NumeroTelefono = "3006094015",
                DireccionCliente = "Cedritos, Bogotá",
                Afiliado = 0
            };
            var cliente2 = new Cliente()
            {
                IdPersona = 00002,
                Nombre = "Mayra",
                Apellido = "Ospina",
                NumeroTelefono = "3008945210",
                DireccionCliente = "Villa Colombia, Cali",
                Afiliado = 0
            };
            var cliente3 = new Cliente()
            {
                IdPersona = 00003,
                Nombre = "Diana",
                Apellido = "Gómez",
                NumeroTelefono = "3017841308",
                DireccionCliente = "NN, Bogotá",
                Afiliado = 0
            };
            var cliente4 = new Cliente()
            {
                IdPersona = 00004,
                Nombre = "Dumar",
                Apellido = "Rojas",
                NumeroTelefono = "3168684393",
                DireccionCliente = "NN, Bogotá",
                Afiliado = 0
            };
            var cliente5 = new Cliente()
            {
                IdPersona = 00005,
                Nombre = "Jorge",
                Apellido = "Moncada",
                NumeroTelefono = "3002596457",
                DireccionCliente = "El Caney, Cali",
                Afiliado = 0
            };

            _repoCliente.AddCliente(cliente);   //llamar al método para agregar al cliente en la base de datos
            _repoCliente.AddCliente(cliente2);
            _repoCliente.AddCliente(cliente3);
            _repoCliente.AddCliente(cliente4);
            _repoCliente.AddCliente(cliente5);
        }

        private static void BuscarCliente (int IdPersona)   //Crear método para buscar cliente que está en la base de datos
        {
            var cliente = _repoCliente.GetCliente(IdPersona);
            Console.WriteLine("Cliente:"+" "+cliente.Nombre+" "+cliente.Apellido);
        }


        //
        //Consultas
        private static void AddConsulta()   //creación de datos de clientes en la base de datos
        {
            var consulta = new Consulta{
                IdConsulta = 10001,
                FechaVisita = "2021_10_08",
                FrecuenciaRespiratoria = 70,
                FrecuenciaCardiaca = 40,
                Temperatura = 25,
                Peso = 5,
                Diagnostico = "Enfermo",
                Recomendaciones = "Darle de comer",
                EstadoAnimo = 0  
            };

            var consulta2 = new Consulta{
                IdConsulta = 10002,
                FechaVisita = "2021_10_08",
                FrecuenciaRespiratoria = 100,
                FrecuenciaCardiaca = 60,
                Temperatura = 35,
                Peso = 15,
                Diagnostico = "Sano",
                Recomendaciones = "Darle cariño",
                EstadoAnimo = 0   
            };
          
            _repoConsulta.AddConsulta(consulta);   //llamar al método para agregar al cliente en la base de datos
            _repoConsulta.AddConsulta(consulta2);
           
        }

        private static void BuscarConsulta (int ID)   //Crear método para buscar cliente que está en la base de datos
        {
            var consulta = _repoConsulta.GetConsulta(ID);
            Console.WriteLine("Consulta No.:"+" "+consulta.ID+" "+consulta.Diagnostico+" "+consulta.FechaVisita);
        }


        //
        //Mascotas
        private static void AddMascota()   //creación de datos de clientes en la base de datos
        {
            var mascota = new Mascota{
                IdMascota = 30001,
                NombreMascota = "Togo",
                Raza = "Golden Retriever",
                TipoMascota = 0  
            };
            var mascota2 = new Mascota{
                IdMascota = 30002,
                NombreMascota = "Orus",
                Raza = "Calico",
                TipoMascota = 0
            };
          
            _repoMascota.AddMascota(mascota);   //llamar al método para agregar al cliente en la base de datos
            _repoMascota.AddMascota(mascota2);
           
        }

        private static void BuscarMascota (int ID)   //Crear método para buscar cliente que está en la base de datos
        {
            var mascota = _repoMascota.GetMascota(ID);
            Console.WriteLine("Mascota:"+" "+mascota.NombreMascota+" "+mascota.Raza);
        }

    }
}
