using MailService.Data;
using MailService.Models;
using Microsoft.EntityFrameworkCore;

namespace MailService.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateMailAsync(MailRecordModel mailRecordModel)
        {
            await _dbContext.Mails.AddAsync(mailRecordModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MailRecordModel>> GetMailsAsync()
        {
            var mails = await _dbContext.Mails.Include(m => m.Recipients).ToListAsync();
            return mails;
        }
    }
}
