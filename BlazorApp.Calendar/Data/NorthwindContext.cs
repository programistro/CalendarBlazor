using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Calendar.Data
{
    public partial class NorthwindContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Northwind");
            }
        }
        partial void OnModelBuilding(ModelBuilder builder);
        
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BlazorApp.Calendar.Models.CustomerCustomerDemo>().HasKey(table => new
            {
                table.CustomerID,
                table.CustomerTypeID
            });

            builder.Entity<BlazorApp.Calendar.Models.EmployeeTerritory>().HasKey(table => new
            {
                table.EmployeeID,
                table.TerritoryID
            });

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>().HasKey(table => new
            {
                table.OrderID,
                table.ProductID
            });

            builder.Entity<BlazorApp.Calendar.Models.Employee>()
                   .HasOne(i => i.Employee1)
                   .WithMany(i => i.Employees1)
                   .HasForeignKey(i => i.ReportsTo)
                   .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<BlazorApp.Calendar.Models.CustomerCustomerDemo>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<BlazorApp.Calendar.Models.CustomerCustomerDemo>()
                  .HasOne(i => i.CustomerDemographic)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerTypeID)
                  .HasPrincipalKey(i => i.CustomerTypeID);

            builder.Entity<BlazorApp.Calendar.Models.EmployeeTerritory>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<BlazorApp.Calendar.Models.EmployeeTerritory>()
                  .HasOne(i => i.Territory)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.TerritoryID)
                  .HasPrincipalKey(i => i.TerritoryID);

            builder.Entity<BlazorApp.Calendar.Models.Order>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<BlazorApp.Calendar.Models.Order>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>()
                  .HasOne(i => i.Order)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.OrderID)
                  .HasPrincipalKey(i => i.OrderID);

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.ProductID)
                  .HasPrincipalKey(i => i.ProductID);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .HasOne(i => i.Supplier)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.SupplierID)
                  .HasPrincipalKey(i => i.SupplierID);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .HasOne(i => i.Category)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.CategoryID)
                  .HasPrincipalKey(i => i.CategoryID);

            builder.Entity<BlazorApp.Calendar.Models.Territory>()
                  .HasOne(i => i.Region)
                  .WithMany(i => i.Territories)
                  .HasForeignKey(i => i.RegionID)
                  .HasPrincipalKey(i => i.RegionID);

            builder.Entity<BlazorApp.Calendar.Models.Order>()
                  .Property(p => p.Freight);

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>()
                  .Property(p => p.UnitPrice);

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>()
                  .Property(p => p.Quantity);

            builder.Entity<BlazorApp.Calendar.Models.OrderDetail>()
                  .Property(p => p.Discount);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .Property(p => p.UnitPrice);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .Property(p => p.UnitsInStock);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .Property(p => p.UnitsOnOrder);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .Property(p => p.ReorderLevel);

            builder.Entity<BlazorApp.Calendar.Models.Product>()
                  .Property(p => p.Discontinued);

            this.OnModelBuilding(builder);
        }


        public DbSet<BlazorApp.Calendar.Models.Category> Categories
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Customer> Customers
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.CustomerCustomerDemo> CustomerCustomerDemos
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.CustomerDemographic> CustomerDemographics
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Employee> Employees
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.EmployeeTerritory> EmployeeTerritories
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Order> Orders
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.OrderDetail> OrderDetails
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Product> Products
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Region> Regions
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Supplier> Suppliers
        {
            get;
            set;
        }

        public DbSet<BlazorApp.Calendar.Models.Territory> Territories
        {
            get;
            set;
        }

        public async Task SeedAsync()
        {
            try
            {
                AddData();

                if (ChangeTracker.HasChanges())
                {
                    await SaveChangesAsync();
                }
            }
            catch
            {
                //
            }
        }

        public void Seed()
        {
            try
            {
                AddData();

                if (ChangeTracker.HasChanges())
                {
                    SaveChanges();
                }
            }
            catch
            {
                //
            }
        }

        public void AddData()
        {
            if (!Customers.Any())
            {
                Customers.AddRange(BlazorApp.Calendar.Data.CustomersData.Data);
            }

            if (!Categories.Any())
            {
                Categories.AddRange(BlazorApp.Calendar.Data.CategoriesData.Data);
            }

            if (!Employees.Any())
            {
                Employees.AddRange(BlazorApp.Calendar.Data.EmployeesData.Data);
            }

            if (!Orders.Any())
            {
                Orders.AddRange(BlazorApp.Calendar.Data.OrdersData.Data);
            }

            if (!OrderDetails.Any())
            {
                OrderDetails.AddRange(BlazorApp.Calendar.Data.OrderDetailsData.Data);
            }

            if (!Products.Any())
            {
                Products.AddRange(BlazorApp.Calendar.Data.ProductsData.Data);
            }

            if (!Regions.Any())
            {
                Regions.AddRange(BlazorApp.Calendar.Data.RegionsData.Data);
            }

            if (!Territories.Any())
            {
                Territories.AddRange(BlazorApp.Calendar.Data.TerritoriesData.Data);
            }

            if (!Suppliers.Any())
            {
                Suppliers.AddRange(BlazorApp.Calendar.Data.SuppliersData.Data);
            }
        }
    }
}
