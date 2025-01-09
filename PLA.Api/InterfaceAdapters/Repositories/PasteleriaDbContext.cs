namespace PLA.Api.InterfaceAdapters.Repositories;

public partial class PasteleriaDbContext : DbContext
{
    public PasteleriaDbContext(DbContextOptions<PasteleriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<RegistroActividad> RegistroActividades { get; set; }

    public virtual DbSet<TipoAccion> TipoAccion { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Anticipo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Comentario).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Direccion).IsUnicode(false);
            entity.Property(e => e.Estatus);
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Presio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ubicacion);
            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Usuarios");
        });

        modelBuilder.Entity<RegistroActividad>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AntiguoValor).IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.NombreTabla)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NuevoValor).IsUnicode(false);

            entity.HasOne(d => d.IdTipoAccionNavigation).WithMany(p => p.RegistroActividades)
                .HasForeignKey(d => d.IdTipoAccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroActividades_TipoAccion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RegistroActividades)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroActividades_Usuarios");
        });

        modelBuilder.Entity<TipoAccion>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
