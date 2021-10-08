using System;

namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int ID {get;set;}
        public string NombreMascota { get; set; }
        public string Raza {get; set;}   
        public TipoMascota TipoMascota { get; set; }
        public Cliente Cliente { get; set; }     
    }
}
