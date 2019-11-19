using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    class DBCPP4 : DbContext
    {
            public DBCPP4() : base("name=CSPrincipal") { }

            public virtual DbSet<Asientos> Asientos { get; set; }
            public virtual DbSet<Compra> Compra { get; set; }

        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }

    }
    }


