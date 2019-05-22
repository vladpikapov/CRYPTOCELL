using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DAL.Entities;

namespace DAL.EF
{

    public partial class CryptoCellDB : DbContext
    {
        public CryptoCellDB()
            : base("name=CryptoCellDB")
        {
        }

        public virtual DbSet<CURREINCIES> CURREINCIES { get; set; }
        public virtual DbSet<USERS_INFO> USERS_INFO { get; set; }
        public virtual DbSet<USERS_LOG> USERS_LOG { get; set; }
        public virtual DbSet<USERS_TRANSACTIONS> USERS_TRANSACTIONS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CURREINCIES>()
                .Property(e => e.CurBalance)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CURREINCIES>()
                .Property(e => e.CurCourseNow)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CURREINCIES>()
                .Property(e => e.CurCourseLast)
                .HasPrecision(10, 2);

            modelBuilder.Entity<USERS_INFO>()
                .HasMany(e => e.CURREINCIES)
                .WithRequired(e => e.USERS_INFO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS_LOG>()
                .HasMany(e => e.USERS_INFO)
                .WithOptional(e => e.USERS_LOG)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<USERS_TRANSACTIONS>()
                .Property(e => e.SumOfTans)
                .HasPrecision(10, 3);
        }
    }
}
