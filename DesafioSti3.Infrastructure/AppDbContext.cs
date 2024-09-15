using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DesafioSTi3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSTi3.Domain.Enums;
using System.Reflection.Metadata;

namespace DesafioSti3.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Identificador);

                entity.Property(e => e.ValorFinal).HasPrecision(10, 2);

                entity.HasOne(e => e.Cliente)
                    .WithMany(e => e.Pedidos)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Preco).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.CPF).HasMaxLength(14);
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.HasKey(e => new { e.PedidoIdentificador, e.ProdutoId });

                entity.Property(e => e.PrecoUnitario).HasPrecision(10, 2);

                entity.HasOne(e => e.Pedido)
                    .WithMany(e => e.Itens)
                    .HasForeignKey(e => e.PedidoIdentificador)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Produto>(e => e.Produto)
                    .WithMany(e => e.ItensPedido)
                    .HasForeignKey(e => e.ProdutoId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

        }
    }
}
