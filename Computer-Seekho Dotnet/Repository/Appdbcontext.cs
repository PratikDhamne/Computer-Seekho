using ComputerSeekho.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Repository
{
    public class Appdbcontext: DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ComputerSeekho;Integrated Security=True");
            }
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Batch> Batches{ get; set; }

        public DbSet<ClosureReason> ClosureReasons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<Followup> Followups { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
