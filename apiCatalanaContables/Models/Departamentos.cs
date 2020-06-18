using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Cargos = new HashSet<Cargos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Departamento { get; set; }
        public int? AreaId { get; set; }

        public virtual Areas Area { get; set; }
        public virtual ICollection<Cargos> Cargos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }

    public partial class DepartamentosApi
    {
        public DepartamentosApi()
        {
            
        }

        public int id { get; set; }
        public int id_area { get; set; }
        public string nombreDpto { get; set; }

        
    }
}
