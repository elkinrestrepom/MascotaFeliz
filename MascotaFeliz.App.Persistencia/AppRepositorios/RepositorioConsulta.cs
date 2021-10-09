using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioConsulta:IRepositorioConsulta  //Se crea clase para implementar la interface IRepositorioCliente
    {
        private readonly AppContext _appContext;   //Referenciar al contexto del Cliente

        public RepositorioConsulta(AppContext appContext)   //Constructor
        {
            _appContext = appContext;   //Le decimos que la variable AppContext va a ser igual que lo que recibamos en appContext
        }   
        //
        //Implementar los métodos que habiamos firmado en IRepositorioCliente
        //
        Consulta IRepositorioConsulta.AddConsulta(Consulta consulta)
        {
            var consultaAdicionado = _appContext.Consultas.Add(consulta);   //declarar variable con "var" para adicionar paciente
            _appContext.SaveChanges();   //Guarda los cambios
            return consultaAdicionado.Entity;   //Retorna el cliente y lo adiciona en la Base de Datos
        }


        IEnumerable<Consulta> IRepositorioConsulta.GetAllConsulta()
        {
            return _appContext.Consultas;   //Retorna todos los Clientes que están en la base de datos
        }   


        Consulta IRepositorioConsulta.UpdateConsulta(Consulta consulta)
        {
           var consultaEncontrado = _appContext.Consultas.FirstOrDefault(c => c.ID == consulta.ID);   //ID es la llave primaria de la entidad Persona
           if (consultaEncontrado != null)
           {
               consultaEncontrado.IdConsulta = consulta.IdConsulta;  
               consultaEncontrado.FechaVisita = consulta.FechaVisita;             
               consultaEncontrado.FrecuenciaRespiratoria = consulta.FrecuenciaRespiratoria;
               consultaEncontrado.FrecuenciaCardiaca = consulta.FrecuenciaCardiaca;
               consultaEncontrado.Temperatura = consulta.Temperatura;
               consultaEncontrado.Peso = consulta.Peso;
               consultaEncontrado.Diagnostico = consulta.Diagnostico;
               consultaEncontrado.Recomendaciones = consulta.Recomendaciones;
               consultaEncontrado.EstadoAnimo = consulta.EstadoAnimo;
               

               _appContext.SaveChanges();
           }
           return consultaEncontrado;
        }


        void IRepositorioConsulta.DeleteConsulta(int IdConsulta)
        {
            var consultaEncontrado = _appContext.Consultas.FirstOrDefault(c => c.ID == IdConsulta);  //ID es la llave primaria de la entidad Persona
            if (consultaEncontrado == null)
                return;
            _appContext.Consultas.Remove(consultaEncontrado);
            _appContext.SaveChanges();
            {
                
            }
        }


        Consulta IRepositorioConsulta.GetConsulta(int IdConsulta)
        {
           return _appContext.Consultas.FirstOrDefault(c => c.ID == IdConsulta);   //Busca y retorna un cliente  //ID es la llave primaria de la entidad Persona
        }
    }
}