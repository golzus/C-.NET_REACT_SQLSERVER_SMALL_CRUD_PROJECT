using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DalRepository.models
{
    public class AdvContext:DbContext
    {
        // הוספת DbSet עבור הטבלאות
        public DbSet<AdvertisementByVisits> AdvertisementByVisits { get; set; }

        public DbSet<User> Users { get; set; }

        // הגדרת שורת החיבור למסד הנתונים
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL3048;Database=adv;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        // אפשר להגדיר קשרים מורכבים ושינויים נוספים באמצעות OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
