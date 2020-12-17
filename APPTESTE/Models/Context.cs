using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPTESTE.Models
{
    public class Context : DbContext
    {
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Churrasco> Churrascos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BANCOTESTE;Integrated Security=True");
        }
    }
}
