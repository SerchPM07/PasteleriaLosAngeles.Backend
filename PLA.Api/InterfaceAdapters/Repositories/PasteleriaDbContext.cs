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
            entity.ToTable("Pedidos");
            entity.Property(e => e.Anticipo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Comentario).IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Estatus);
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario);
            entity.Property(e => e.NombreCliente)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoCliente)
               .HasMaxLength(15)
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
            entity.ToTable("RegistroActividades");
            entity.Property(e => e.AntiguoValor).IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.IdTipoAccion);
            entity.Property(e => e.IdUsuario);
            entity.Property(e => e.NombreTabla)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NuevoValor)
                .IsRequired()
                .IsUnicode(false);

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
            entity.ToTable("TipoAccion");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Usuarios");
            entity.Property(e => e.ApellidoMaterno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
