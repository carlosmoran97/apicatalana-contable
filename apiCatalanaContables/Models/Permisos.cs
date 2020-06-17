using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            PermisosUsuarios = new HashSet<PermisosUsuarios>();
        }

        public int Id { get; set; }
        public string Permiso { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<PermisosUsuarios> PermisosUsuarios { get; set; }
    }
}
