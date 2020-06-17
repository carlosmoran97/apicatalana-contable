using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class PermisosUsuarios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PermisoId { get; set; }

        public virtual Permisos Permiso { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
