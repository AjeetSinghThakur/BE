using BE.Dal;

namespace BE.Service
{
    public abstract class ServiceBase
    {
        protected readonly EntityDbContext DbContext;
        
        public ServiceBase(EntityDbContext dbContext)
        {
            DbContext = dbContext;
        }       
    }
}
