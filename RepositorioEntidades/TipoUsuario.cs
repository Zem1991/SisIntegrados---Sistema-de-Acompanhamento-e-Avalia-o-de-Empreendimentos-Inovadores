//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepositorioEntidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            this.Aluno = new HashSet<Aluno>();
            this.Professor = new HashSet<Professor>();
        }
    
        public int TUIDusuario { get; set; }
        public string TUdescricao { get; set; }
    
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Professor> Professor { get; set; }
    }
}