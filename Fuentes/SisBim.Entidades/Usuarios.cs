//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SisBim.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Reservas = new HashSet<Reservas>();
        }
    
        public string RUT { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<int> IdPerfil { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
    
        public virtual Perfiles Perfiles { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
