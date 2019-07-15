using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Domains.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=68.183.182.103;port=3306;user=root;password=1234;database=mydb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries", "mydb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("country_code")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.ToTable("provinces", "mydb");

                entity.HasIndex(e => e.CountriesId)
                    .HasName("fk_provinces_countries1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountriesId)
                    .IsRequired()
                    .HasColumnName("countries_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasColumnName("province_code")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasColumnName("province_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.CountriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_provinces_countries1");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.ToTable("transactions", "mydb");

                entity.HasIndex(e => e.CountriesId)
                    .HasName("fk_transactions_countries1_idx");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_transactions_users_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CountriesId)
                    .IsRequired()
                    .HasColumnName("countries_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId)
                    .IsRequired()
                    .HasColumnName("users_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CountriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_countries1");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "mydb");

                entity.HasIndex(e => e.ProvincesId)
                    .HasName("fk_users_provinces1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ProvincesId)
                    .IsRequired()
                    .HasColumnName("provinces_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provinces)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProvincesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_provinces1");
            });
        }
    }
}
