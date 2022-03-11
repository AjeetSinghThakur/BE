using BE.Dal;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BE.WebApi.Filters
{
    public class TransactionFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before action execution
            var dbContext = (EntityDbContext)context.HttpContext.RequestServices.GetService(typeof(EntityDbContext));
            await dbContext.BeginTransaction();

            var resultContext = await next();

            //after action execution
            if(resultContext.Exception == null)
            {
                await dbContext.Commit();
            }
            else
            {
                await dbContext.Rollback();
            }
        }
    }
}
