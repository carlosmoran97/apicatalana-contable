using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Cargos
    {
        public Cargos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Cargo { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Departamentos Departamento { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }


    public partial class CargosApi
    {
        public CargosApi()
        {
           
        }

        public int id { get; set; }
        public int id_Dpto { get; set; }
        public string nombrecargo { get; set; }

       
    }
}
