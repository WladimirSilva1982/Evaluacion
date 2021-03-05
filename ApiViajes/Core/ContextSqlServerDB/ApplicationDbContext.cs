using ApiViajes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiViajes.Core.ContextSqlServerDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Viajero> Viajero { get; set; }
        public DbSet<ViajeDisponible> ViajeDisponible { get; set; }
        public DbSet<ViajeDispoViajero> ViajeDispoViajero { get; set; }
    }
}
