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
    
    public partial class Professor
    {
        public Professor()
        {
            this.Projeto = new HashSet<Projeto>();
        }
    
        public int PRIDprofessor { get; set; }
        public string PRemail { get; set; }
        public string PRsenha { get; set; }
        public string PRdisciplinaPrincipal { get; set; }
        public string PRdepartamento { get; set; }
        public int PRtipoProfessor { get; set; }
        public string PRprojetosQueOrienta { get; set; }
        public string PRprojetosQueOrientou { get; set; }
        public string PRnome { get; set; }
    
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Projeto> Projeto { get; set; }
    }
}