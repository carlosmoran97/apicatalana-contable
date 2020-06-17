using System;
using System.Collections.Generic;

namespace apiCatalanaContables.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
