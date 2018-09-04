using RegistroEjemplo.Entidades;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEjemplo.DAL.Scripts
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Persona { get; set; }

        public Contexto() : base("Constr") { }
    }
}
