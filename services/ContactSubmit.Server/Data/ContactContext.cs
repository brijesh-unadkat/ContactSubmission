using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContactSubmit.Server.Data
{
    public class ContactContext :DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = builder.HasDefaultSchema("ContactManagement");
        }
    }
}
