using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Areas
    {
        public Areas()
        {
            Departamentos = new HashSet<Departamentos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Area { get; set; }
        public int? EmpresaId { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<Departamentos> Departamentos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }


    public  class AreasApi
    {
        public AreasApi()
        {

        }

        public int id { get; set; }
        public string nombreArea { get; set; }
        public int  id_empresa { get; set; }

        
    }

}
