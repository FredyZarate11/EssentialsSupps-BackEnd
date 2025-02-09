using System;
using System.Collections.Generic;
using EssentialsSupps_Backend.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace EssentialsSupps_Backend.Infrastructure.Data;

public partial class EssentialsSuppsdbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public EssentialsSuppsdbContext()
    {
    }

    public EssentialsSuppsdbContext(DbContextOptions<EssentialsSuppsdbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Paymenthistory> Paymenthistories { get; set; }

    public virtual DbSet<Paymentmethod> Paymentmethods { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Personmedium> Personmedia { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productcategory> Productcategories { get; set; }

    public virtual DbSet<Productmedium> Productmedia { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saledetail> Saledetails { get; set; }

    public virtual DbSet<Salesstatus> Salesstatuses { get; set; }

    public virtual DbSet<Shoppingcart> Shoppingcarts { get; set; }

    public virtual DbSet<Shoppingcartitem> Shoppingcartitems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.IdAudit).HasName("audit_pkey");

            entity.ToTable("audit");

            entity.Property(e => e.IdAudit).HasColumnName("id_audit");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Newvalue)
                .HasMaxLength(255)
                .HasColumnName("newvalue");
            entity.Property(e => e.Oldvalue)
                .HasMaxLength(255)
                .HasColumnName("oldvalue");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(255)
                .HasColumnName("name_category");
        });

        modelBuilder.Entity<Paymenthistory>(entity =>
        {
            entity.HasKey(e => e.IdPaymenthistory).HasName("paymenthistory_pkey");

            entity.ToTable("paymenthistory");

            entity.HasIndex(e => e.Transactionid, "paymenthistory_transactionid_key").IsUnique();

            entity.Property(e => e.IdPaymenthistory).HasColumnName("id_paymenthistory");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .HasColumnName("result");
            entity.Property(e => e.Saleid).HasColumnName("saleid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Transactionid)
                .HasMaxLength(255)
                .HasColumnName("transactionid");

            entity.HasOne(d => d.Sale).WithMany(p => p.Paymenthistories)
                .HasForeignKey(d => d.Saleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_paymenthistory_sale");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Paymenthistories)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("fk_paymenthistory_status");
        });

        modelBuilder.Entity<Paymentmethod>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("paymentmethod_pkey");

            entity.ToTable("paymentmethod");

            entity.Property(e => e.IdPayment).HasColumnName("id_payment");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.NamePayment)
                .HasMaxLength(255)
                .HasColumnName("name_payment");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("person_pkey");

            entity.ToTable("person");

            entity.HasIndex(e => e.EmailPerson, "person_email_person_key").IsUnique();

            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.EmailPerson)
                .HasMaxLength(255)
                .HasColumnName("email_person");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Laslogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("laslogin");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Updateat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateat");

            entity.HasOne(d => d.Role).WithMany(p => p.People)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_role");
        });

        modelBuilder.Entity<Personmedium>(entity =>
        {
            entity.HasKey(e => e.IdPersonmedia).HasName("personmedia_pkey");

            entity.ToTable("personmedia");

            entity.Property(e => e.IdPersonmedia).HasColumnName("id_personmedia");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Isprimary).HasColumnName("isprimary");
            entity.Property(e => e.Personid).HasColumnName("personid");
            entity.Property(e => e.UrlMedia)
                .HasMaxLength(255)
                .HasColumnName("url_media");

            entity.HasOne(d => d.Person).WithMany(p => p.Personmedia)
                .HasForeignKey(d => d.Personid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_personmedia_person");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.HasIndex(e => e.CodeProduct, "idx_product_code");

            entity.HasIndex(e => e.CodeProduct, "product_code_product_key").IsUnique();

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.CodeProduct)
                .HasMaxLength(255)
                .HasColumnName("code_product");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(255)
                .HasColumnName("name_product");
            entity.Property(e => e.PriceProduct)
                .HasPrecision(15, 2)
                .HasColumnName("price_product");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Updateat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateat");
        });

        modelBuilder.Entity<Productcategory>(entity =>
        {
            entity.HasKey(e => e.IdProductcategory).HasName("productcategory_pkey");

            entity.ToTable("productcategory");

            entity.Property(e => e.IdProductcategory).HasColumnName("id_productcategory");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Productid).HasColumnName("productid");

            entity.HasOne(d => d.Category).WithMany(p => p.Productcategories)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productcategory_category");

            entity.HasOne(d => d.Product).WithMany(p => p.Productcategories)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productcategory_product");
        });

        modelBuilder.Entity<Productmedium>(entity =>
        {
            entity.HasKey(e => e.IdProductmedia).HasName("productmedia_pkey");

            entity.ToTable("productmedia");

            entity.Property(e => e.IdProductmedia).HasColumnName("id_productmedia");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Isprimary).HasColumnName("isprimary");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.UrlMedia)
                .HasMaxLength(255)
                .HasColumnName("url_media");

            entity.HasOne(d => d.Product).WithMany(p => p.Productmedia)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productmedia_product");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.NameRole)
                .HasMaxLength(255)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("sale_pkey");

            entity.ToTable("sale");

            entity.Property(e => e.IdSale).HasColumnName("id_sale");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Paymentmethod).HasColumnName("paymentmethod");
            entity.Property(e => e.Saledate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("saledate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Totalamount)
                .HasPrecision(15, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.PaymentmethodNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Paymentmethod)
                .HasConstraintName("fk_sale_paymentmethod");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("fk_sale_status");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_person");
        });

        modelBuilder.Entity<Saledetail>(entity =>
        {
            entity.HasKey(e => e.IdSaledetail).HasName("saledetail_pkey");

            entity.ToTable("saledetail");

            entity.Property(e => e.IdSaledetail).HasColumnName("id_saledetail");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Price)
                .HasPrecision(15, 2)
                .HasColumnName("price");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Saleid).HasColumnName("saleid");
            entity.Property(e => e.Total)
                .HasPrecision(15, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Product).WithMany(p => p.Saledetails)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saledetail_product");

            entity.HasOne(d => d.Sale).WithMany(p => p.Saledetails)
                .HasForeignKey(d => d.Saleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saledetail_sale");
        });

        modelBuilder.Entity<Salesstatus>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("salesstatus_pkey");

            entity.ToTable("salesstatus");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(255)
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<Shoppingcart>(entity =>
        {
            entity.HasKey(e => e.IdShoppingcart).HasName("shoppingcart_pkey");

            entity.ToTable("shoppingcart");

            entity.Property(e => e.IdShoppingcart).HasColumnName("id_shoppingcart");
            entity.Property(e => e.Updateat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateat");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Shoppingcarts)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shoppingcart_person");
        });

        modelBuilder.Entity<Shoppingcartitem>(entity =>
        {
            entity.HasKey(e => new { e.Shoppingcartid, e.Productid }).HasName("shoppingcartitems_pkey");

            entity.ToTable("shoppingcartitems");

            entity.Property(e => e.Shoppingcartid).HasColumnName("shoppingcartid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.Product).WithMany(p => p.Shoppingcartitems)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shoppingcartitems_product");

            entity.HasOne(d => d.Shoppingcart).WithMany(p => p.Shoppingcartitems)
                .HasForeignKey(d => d.Shoppingcartid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shoppingcartitems_cart");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
