using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;


namespace PP4.DAL
{
    public partial class DBCPP4 : DbContext
    {
        
            public DBCPP4()
                : base("name=CSPrincipal")
            {
            this.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<Asientos> Asientos { get; set; }
            public virtual DbSet<Compra> Compra { get; set; }

        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }

        public virtual DbSet<Sala_Cantidad> Sala_Cantidad { get; set; }

    }
    }


