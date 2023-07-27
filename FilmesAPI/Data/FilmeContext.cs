using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
  public class FilmeContext : DbContext
  {
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Sessao>()
          .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

      modelBuilder.Entity<Sessao>().HasOne(sessao => sessao.Cinema)
          .WithMany(cinema => cinema.Sessoes).HasForeignKey(sessao => sessao.CinemaId);
      modelBuilder.Entity<Sessao>().HasOne(sessao => sessao.Filme)
          .WithMany(filme => filme.Sessoes).HasForeignKey(sessao => sessao.FilmeId);
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
  }
}