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
}
