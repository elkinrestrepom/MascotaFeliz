using System;

namespace MascotaFeliz.App.Dominio
{
    public class Cliente : Persona
    {
        public string DireccionCliente { get; set; }
        public Afiliado Afiliado { get; set; }
    }
}
