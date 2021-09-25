using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_CRUD.Models;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<EF_CRUD.Models.Client> Client { get; set; }
        public DbSet<EF_CRUD.Models.JuridicalPerson> JuridicalPeople { get; set; }
        public DbSet<EF_CRUD.Models.PhysicalPerson> PhysicalPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasDiscriminator<EF_CRUD.Models.ClientType>("client_type")
                .HasValue<Client>(EF_CRUD.Models.ClientType.BASE)
                .HasValue<PhysicalPerson>(EF_CRUD.Models.ClientType.PF)
                .HasValue<JuridicalPerson>(EF_CRUD.Models.ClientType.PJ);

            modelBuilder.Entity<Adress>()
                .Property(c => c.AdressType)
                .HasConversion<string>();

                
            modelBuilder.Entity<Phone>()
                .Property(c => c.PhoneType)
                .HasConversion<string>();
        }

        public DbSet<EF_CRUD.Models.Adress> Adress { get; set; }

        public DbSet<EF_CRUD.Models.Phone> Phone { get; set; }

    }
