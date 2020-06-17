using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            PermisosUsuarios = new HashSet<PermisosUsuarios>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public int? EmpresaId { get; set; }
        public int? AreaId { get; set; }
        public int? DepartamentoId { get; set; }
        public int? CargoId { get; set; }
        public string Dui { get; set; }
        public string Password { get; set; }
        public int? Idempleado { get; set; }
        public int? RolId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Areas Area { get; set; }
        public virtual Cargos Cargo { get; set; }
        public virtual Departamentos Departamento { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual Roles Rol { get; set; }
        public virtual ICollection<PermisosUsuarios> PermisosUsuarios { get; set; }
    }
}
