using MailService.Models;
using Microsoft.EntityFrameworkCore;

namespace MailService.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region DB_SETS

        public DbSet<MailRecordModel> Mails { get; set; }
        public DbSet<RecipientModel> Recipients { get; set; }
        #endregion

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
    }
}
