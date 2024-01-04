using Microsoft.EntityFrameworkCore;
using PelatologioApi.Entities;

namespace PelatologioApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        public DbSet<CustomerDbData> Customers { get; set; }
        public DbSet<TelephoneDbData> Telephone { get; set; }


    }


}
