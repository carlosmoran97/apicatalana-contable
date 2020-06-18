using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Areas = new HashSet<Areas>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Areas> Areas { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }

    public partial class EmpresasApi
    {
        public EmpresasApi()
        {
            
        }
        public int id { get; set; }
        public string nombreEmpresa { get; set; }
        public string abreviatura { get; set; }

    }


}
