using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.Entities;

namespace Data.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<CostDefine> CostDefines { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Defect> Defects { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OneData> OneDatas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<DeviceDefect> DeviceDefects { get; set; }
        public DbSet<DeviceImage> DeviceImages { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<RequestDevice> RequestDevices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AllMessage> AllMessages { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PayType> PayTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<AllMessage>().

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.HasDefaultSchema("bituser");
            modelBuilder.Entity<Duty>()
                .HasQueryFilter(u => !u.IsDelete);
            //modelBuilder.HasDefaultSchema("bituser");
            modelBuilder.Entity<Brand>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Carousel>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Cost>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<CostDefine>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Defect>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Faq>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Message>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<OneData>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<ProductGroup>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Product>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Reception>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Rule>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Service>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Shipping>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Ticket>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Video>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<DeviceDefect>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<DeviceImage>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Leave>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Debtor>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<RequestDevice>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Duty>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Payment>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<AllMessage>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Sale>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<PayType>()
                .HasQueryFilter(u => !u.IsDelete);
            base.OnModelCreating(modelBuilder);
        }

    }
}
