using System;

namespace MascotaFeliz.App.Dominio
{
    public class Consulta
    {
        public int ID {get;set;}
        public int IdConsulta {get;set;}
        public string FechaVisita { get; set; }
        public int FrecuenciaRespiratoria { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public float Temperatura { get; set; }
        public float Peso { get; set; }
        public string Diagnostico { get; set; }
        public string Recomendaciones { get; set; }
        public EstadoAnimo EstadoAnimo { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
    }
}
