using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using AM.Infrastructeur.configurations;
using AM.Infrastructeur.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructeur
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        // OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                      Initial Catalog=AirportManagementDB;
                                      Integrated Security=true;
                                      MultipleActiveResultSets=True");

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    

    //onModel
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1err methode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            //2eme methode
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(P => P.Capacity).HasColumnName("PlaneCapacity");


            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //configure owend 

            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);

            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //heritage configurer automatiquement par ORM
            //modelBuilder.Entity<Passenger>()
            //            .HasDiscriminator<int>("IsTraveller")
            //            .HasValue<Passenger>(2)
            //            .HasValue<Traveller>(1)
            //            .HasValue<Staff>(0);

            //Configurede l'heritage table per type (TPT)

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


            //configure la cle primaire de la porteuse
            modelBuilder.Entity<Ticket>()
                        .HasKey(t => new { t.FlightFk, t.PassengerFk });

        }

        protected override void ConfigureConventions( ModelConfigurationBuilder ConfigurationBuilder)
        {
            ConfigurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
            base.ConfigureConventions(ConfigurationBuilder);
           
        
        }





    } }
