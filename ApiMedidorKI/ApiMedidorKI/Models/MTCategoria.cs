//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiMedidorKI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MTCategoria
    {
        public MTCategoria()
        {
            this.MTReto = new HashSet<MTReto>();
        }
    
        public int CodigoCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public string UsuarioModifico { get; set; }
    
        public virtual ICollection<MTReto> MTReto { get; set; }
    }
}
