using Microsoft.EntityFrameworkCore;
using Sacolao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Data
{
    public class SacolaoContext : DbContext
    {
        public SacolaoContext(DbContextOptions<SacolaoContext> options) : base(options) { }

        public DbSet<Fruta> Frutas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<FrutaCompra> FrutasCompras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FrutaCompra>().HasKey(AD => new { AD.FrutaId, AD.CompraId });

            builder.Entity<Fruta>()
               .HasData(new List<Fruta>(){
                    new Fruta(1, "Banana", "Amarela", "banana.jpg", 50, 5),
                    new Fruta(2, "Maça", "Vermelha", "maca.jpg", 150, 2),
                    new Fruta(3, "Melancia", "Verde", "melancia.jpg", 15, 9)
               });

            builder.Entity<Usuario>()
               .HasData(new List<Usuario>(){
                    new Usuario(1, "Teste 1", "teste@teste.com.br", "123456"),
                    new Usuario(2, "Teste 2", "teste2@teste.com.br", "123456")
               });
        }
    }
}
