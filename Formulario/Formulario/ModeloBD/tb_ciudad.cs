//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Formulario.ModeloBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_ciudad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_ciudad()
        {
            this.tb_user = new HashSet<tb_user>();
        }
    
        public int id { get; set; }
        public string ciudad { get; set; }
        public int departamento { get; set; }
    
        public virtual tb_departamento tb_departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_user> tb_user { get; set; }
    }
}
