using Microsoft.EntityFrameworkCore;

namespace Gestion_Reportes.Models
{
    public class Gestion_Reportes_DBModel : DbContext
    {
        public Gestion_Reportes_DBModel(DbContextOptions<Gestion_Reportes_DBModel> options) : base(options)
        {
        }

        public DbSet<Reporte> Reportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.ToTable("reportes"); 

                entity.HasKey(e => e.Id_Reporte); 

                entity.Property(e => e.Id_Reporte).HasColumnName("id_reporte");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.UrlReporte).HasColumnName("urlreporte");
                entity.Property(e => e.UrlVistaPrevia).HasColumnName("urlvistaprevia");
            });
        }

    }
}
