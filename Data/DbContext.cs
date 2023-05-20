using ControleVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculo.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Abastecimento> Abastecimentos { get; set; } = null!;
    public DbSet<Motorista> Motoristas { get; set; } = null!;
    public DbSet<MotoristaVeiculo> MotoristasVeiculos { get; set; } = null!;
    public DbSet<TurnoLancamento> TurnoLancamentos { get; set; } = null!;
    public DbSet<Veiculo> Veiculos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotoristaVeiculo>().HasKey(mv => new { mv.MotoristaId, mv.VeiculoId });
        modelBuilder.Entity<MotoristaVeiculo>().HasOne(mv => mv.Motorista).WithMany(m => m.MotoristaVeiculos).HasForeignKey(mv => mv.MotoristaId);
        modelBuilder.Entity<MotoristaVeiculo>().HasOne(mv => mv.Veiculo).WithMany(m => m.MotoristaVeiculos).HasForeignKey(mv => mv.VeiculoId);
        base.OnModelCreating(modelBuilder);
    }
}