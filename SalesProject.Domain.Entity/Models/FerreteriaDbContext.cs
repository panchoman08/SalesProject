using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesProject.Domain.Entity.Models;

public partial class FerreteriaDbContext : DbContext
{
    public FerreteriaDbContext()
    {
    }

    public FerreteriaDbContext(DbContextOptions<FerreteriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<BuyDet> BuyDets { get; set; }

    public virtual DbSet<BuyOrder> BuyOrders { get; set; }

    public virtual DbSet<BuyOrderDet> BuyOrderDets { get; set; }

    public virtual DbSet<BuyReturn> BuyReturns { get; set; }

    public virtual DbSet<BuyReturnDet> BuyReturnDets { get; set; }

    public virtual DbSet<CategorySalePrice> CategorySalePrices { get; set; }

    public virtual DbSet<Cellar> Cellars { get; set; }

    public virtual DbSet<CellarTransfer> CellarTransfers { get; set; }

    public virtual DbSet<CellarTransferDet> CellarTransferDets { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerCat> CustomerCats { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<MinMaxProd> MinMaxProds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCat> ProductCats { get; set; }

    public virtual DbSet<ProductSalePrice> ProductSalePrices { get; set; }

    public virtual DbSet<ProductStum> ProductSta { get; set; }

    public virtual DbSet<RolUser> RolUsers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDet> SaleDets { get; set; }

    public virtual DbSet<SaleOrder> SaleOrders { get; set; }

    public virtual DbSet<SaleOrderDet> SaleOrderDets { get; set; }

    public virtual DbSet<SaleReturn> SaleReturns { get; set; }

    public virtual DbSet<SaleReturnDet> SaleReturnDets { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierCat> SupplierCats { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    public virtual DbSet<TransactionState> TransactionStates { get; set; }

    public virtual DbSet<UserSy> UserSys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=ferreteria_db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brand__3213E83FCAF95264");

            entity.ToTable("brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__buy__3213E83FCC3D173F");

            entity.ToTable("buy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyOrderId).HasColumnName("buy_order_id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_doc");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.BuyOrder).WithMany(p => p.Buys)
                .HasForeignKey(d => d.BuyOrderId)
                .HasConstraintName("fk_buy_order_id");

            entity.HasOne(d => d.Document).WithMany(p => p.Buys)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_document_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Buys)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_supplier");

            entity.HasOne(d => d.TransState).WithMany(p => p.Buys)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_status_id");

            entity.HasOne(d => d.User).WithMany(p => p.Buys)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_buy");
        });

        modelBuilder.Entity<BuyDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_det_id");

            entity.ToTable("buy_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Buy).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.BuyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_id");

            entity.HasOne(d => d.Cellar).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_buy_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_product_id");
        });

        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_order");

            entity.ToTable("buy_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_doc");
            entity.Property(e => e.OutputDocumentId).HasColumnName("output_document_id");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document).WithMany(p => p.BuyOrderDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bo_document_id");

            entity.HasOne(d => d.OutputDocument).WithMany(p => p.BuyOrderOutputDocuments)
                .HasForeignKey(d => d.OutputDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bo_output_doc_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier_buy_order");

            entity.HasOne(d => d.TransState).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_state");

            entity.HasOne(d => d.User).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_sys_id");
        });

        modelBuilder.Entity<BuyOrderDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_order_det");

            entity.ToTable("buy_order_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyOrderId).HasColumnName("buy_order_id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.BuyOrder).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.BuyOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order");

            entity.HasOne(d => d.Cellar).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_buy_order_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_product_id");
        });

        modelBuilder.Entity<BuyReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_return_id");

            entity.ToTable("buy_return");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("date")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("noDoc");
            entity.Property(e => e.Observation)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_br_document_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier_id");

            entity.HasOne(d => d.User).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_ret_user_id");
        });

        modelBuilder.Entity<BuyReturnDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_return_det_id");

            entity.ToTable("buy_return_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.BuyReturnId).HasColumnName("buy_return_id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Buy).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("fk_buy_id_return");

            entity.HasOne(d => d.BuyReturn).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.BuyReturnId)
                .HasConstraintName("fk_buy_return_id");

            entity.HasOne(d => d.Cellar).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_buy_ret_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_product_buy_return");
        });

        modelBuilder.Entity<CategorySalePrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F01330517");

            entity.ToTable("category_sale_price");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cellar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cellar__3213E83FD1566C65");

            entity.ToTable("cellar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CellarTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cell_transfer_id");

            entity.ToTable("cellar_transfer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarDestinationId).HasColumnName("cellar_destination_id");
            entity.Property(e => e.CellarOriginId).HasColumnName("cellar_origin_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.NoTransfer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_transfer");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CellarDestination).WithMany(p => p.CellarTransferCellarDestinations)
                .HasForeignKey(d => d.CellarDestinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_dest_id");

            entity.HasOne(d => d.CellarOrigin).WithMany(p => p.CellarTransferCellarOrigins)
                .HasForeignKey(d => d.CellarOriginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_origin_id");

            entity.HasOne(d => d.User).WithMany(p => p.CellarTransfers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_user");
        });

        modelBuilder.Entity<CellarTransferDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cellar_trans_det");

            entity.ToTable("cellar_transfer_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarTransId).HasColumnName("cellar_trans_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.CellarTrans).WithMany(p => p.CellarTransferDets)
                .HasForeignKey(d => d.CellarTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_customer");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CreditLimit)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("credit_limit");
            entity.Property(e => e.Cui)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cui");
            entity.Property(e => e.Defaulter).HasColumnName("defaulter");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Category).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_cat");
        });

        modelBuilder.Entity<CustomerCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F909144A8");

            entity.ToTable("customer_cat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F967504E6");

            entity.ToTable("document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.InternalCorrelative).HasColumnName("internal_correlative");
            entity.Property(e => e.Serie)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("serie");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_document_type_id");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F67370C3B");

            entity.ToTable("document_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_inventory_id");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.CellarTransId).HasColumnName("cellar_trans_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Buy).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("fk_inv_buy_id");

            entity.HasOne(d => d.Cellar).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CellarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_id");

            entity.HasOne(d => d.CellarTrans).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CellarTransId)
                .HasConstraintName("fk_cellarTrans_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_inv_sale_id");
        });

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__measure__3213E83FE5D54483");

            entity.ToTable("measure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MinMaxProd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_min_max");

            entity.ToTable("min_max_prod");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Maximum).HasColumnName("maximum");
            entity.Property(e => e.Minimum).HasColumnName("minimum");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Cellar).WithMany(p => p.MinMaxProds)
                .HasForeignKey(d => d.CellarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_min_max_cellar");

            entity.HasOne(d => d.Product).WithMany(p => p.MinMaxProds)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_prod_min_max");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_product");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BuyPrice)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("buy_price");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("fk_brand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_category");

            entity.HasOne(d => d.Measure).WithMany(p => p.Products)
                .HasForeignKey(d => d.MeasureId)
                .HasConstraintName("fk_measure");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_status");
        });

        modelBuilder.Entity<ProductCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F7946F596");

            entity.ToTable("product_cat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductSalePrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_prod_sale_price");

            entity.ToTable("product_sale_price");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CatSalePriceId).HasColumnName("cat_sale_price_id");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.CatSalePrice).WithMany(p => p.ProductSalePrices)
                .HasForeignKey(d => d.CatSalePriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prod_cat_sale_price_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSalePrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prod_id");
        });

        modelBuilder.Entity<ProductStum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83FD573BED4");

            entity.ToTable("product_sta");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol_user__3213E83FAF9D09D1");

            entity.ToTable("rol_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale");

            entity.ToTable("sale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_doc");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_customer");

            entity.HasOne(d => d.Document).WithMany(p => p.Sales)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_document_id");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("fk_sale_order_id");

            entity.HasOne(d => d.TransState).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_tran_sta");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_user");
        });

        modelBuilder.Entity<SaleDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_det");

            entity.ToTable("sale_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Cellar).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.CellarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_product_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_id");
        });

        modelBuilder.Entity<SaleOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_order");

            entity.ToTable("sale_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_doc");
            entity.Property(e => e.OutputDocumentId).HasColumnName("output_document_id");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_customer");

            entity.HasOne(d => d.Document).WithMany(p => p.SaleOrderDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_so_document_id");

            entity.HasOne(d => d.OutputDocument).WithMany(p => p.SaleOrderOutputDocuments)
                .HasForeignKey(d => d.OutputDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_so_output_doc_id");

            entity.HasOne(d => d.TransState).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_status");

            entity.HasOne(d => d.User).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_user");
        });

        modelBuilder.Entity<SaleOrderDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_order_det");

            entity.ToTable("sale_order_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Cellar).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_sale_order_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_product_id");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.SaleOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order");
        });

        modelBuilder.Entity<SaleReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_return_id");

            entity.ToTable("sale_return");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("date")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("noDoc");
            entity.Property(e => e.Observation)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_id");

            entity.HasOne(d => d.Document).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sr_document_id");

            entity.HasOne(d => d.User).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_ret_user");
        });

        modelBuilder.Entity<SaleReturnDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_return_det_id");

            entity.ToTable("sale_return_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Cellar).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_sale_return_cellar_id");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_product_sale_return");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_sale_id_return");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("fk_sale_return_id");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83FAE08B4A1");

            entity.ToTable("supplier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Category).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suppplier_cat");
        });

        modelBuilder.Entity<SupplierCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83F9C9734EA");

            entity.ToTable("supplier_cat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_transaction_detail");

            entity.ToTable("transaction_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.BuyReturnId).HasColumnName("buy_return_id");
            entity.Property(e => e.CellarId).HasColumnName("cellar_id");
            entity.Property(e => e.CellarTransferId).HasColumnName("cellar_transfer_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.NoDoc).HasColumnName("noDoc");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.Units).HasColumnName("units");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");

            entity.HasOne(d => d.Buy).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("fk_td_buy_id");

            entity.HasOne(d => d.BuyReturn).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.BuyReturnId)
                .HasConstraintName("fk_td_buy_return_id");

            entity.HasOne(d => d.Cellar).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.CellarId)
                .HasConstraintName("fk_td_cellar_id");

            entity.HasOne(d => d.CellarTransfer).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.CellarTransferId)
                .HasConstraintName("fk_td_cellar_trans");

            entity.HasOne(d => d.Product).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_td_product_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_td_sale_id");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("fk_td_sale_return_id");
        });

        modelBuilder.Entity<TransactionState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FE13D0724");

            entity.ToTable("transaction_state");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserSy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sys__3213E83F87CC2EB7");

            entity.ToTable("user_sys");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Rol).WithMany(p => p.UserSies)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("fk_rol_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
