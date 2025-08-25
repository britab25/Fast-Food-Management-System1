using Microsoft.EntityFrameworkCore;
using WebApiFrituraV2.Models;

public partial class TiendaFriturasDbContext : DbContext
{
    public TiendaFriturasDbContext() { }

    public TiendaFriturasDbContext(DbContextOptions<TiendaFriturasDbContext> options) : base(options) { }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public virtual DbSet<Pedido> Pedidos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<Proveedore> Proveedores { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    // Nuevos modelos
    public virtual DbSet<HistorialCaja> HistorialCaja { get; set; }
    public virtual DbSet<ReporteVentasDia> ReporteVentasDia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A72009FFF8");
            entity.HasIndex(e => e.NumeroDocumento, "UQ_Cliente_NumeroDocumento").IsUnique();
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);
        });

        // DetallePedido
        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.DetallePedidoId).HasName("PK__DetalleP__6ED21C0194E86DB2");
            entity.Property(e => e.DetallePedidoId).HasColumnName("DetallePedidoID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK_DetallePedidos_Pedidos");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_DetallePedidos_Productos");
        });

        // Factura
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805D5C6AB09");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Estado).HasMaxLength(50).HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaFactura).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facturas_Pedidos");
        });

        // Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA14102D65FE8F");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado).HasMaxLength(50).HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaPedido).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Clientes");
        });

        // Producto
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83D465D0CA");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CodigoProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoProveedor)
                .HasConstraintName("FK_Productos_Proveedores");
        });

        // Proveedore
        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.CodigoProveedor).HasName("PK__Proveedo__137549F547326773");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.NombreProveedor).HasMaxLength(100);
        });

        // Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798A3D8C7A0");
            entity.HasIndex(e => e.UsuarioLogin, "UQ__Usuarios__F96234F371E2D094").IsUnique();
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.ClaveHash).HasMaxLength(300);
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
            entity.Property(e => e.UsuarioLogin).HasMaxLength(50);
        });

        // HistorialCaja
        modelBuilder.Entity<HistorialCaja>(entity =>
        {
            entity.ToTable("HistorialCaja");
            entity.HasKey(e => e.HistorialCajaID);
            entity.Property(e => e.HistorialCajaID).HasColumnName("HistorialCajaID");
            entity.Property(e => e.UsuarioID).IsRequired();
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.TipoEvento).HasMaxLength(50);
            entity.Property(e => e.MontoInicial).HasColumnType("decimal(18,2)");
            entity.Property(e => e.MontoFinal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Observaciones).HasMaxLength(255);

            entity.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioID)
                .HasConstraintName("FK_HistorialCaja_Usuarios");
        });

        // ReporteVentasDia (sin clave)
        modelBuilder.Entity<ReporteVentasDia>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
