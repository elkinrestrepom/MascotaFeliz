using System;

namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int ID {get;set;}
        public string NombreMascota { get; set; }
        public Afiliado Afiliado { get; set; }
        public TipoMascota TipoMascota { get; set; }
        public string DireccionMascota { get; set; }        
    }
}
