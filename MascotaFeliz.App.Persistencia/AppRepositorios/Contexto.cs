using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;


namespace MascotaFeliz.App.Persistencia
{
    public class Contexto : DbContext
    {
        //public DbSet<Persona> Personas {get;set;} 
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Cliente> Clientes {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {       
            if(!optionsBuilder.IsConfigured) 
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");
            }
        } 

    } 

}