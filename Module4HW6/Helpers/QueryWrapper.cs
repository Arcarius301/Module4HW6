using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Module4HW6.Data;
using Module4HW6.Helpers;

namespace Module4HW6.Helpers
{
    public static class QueryWrapper
    {
        public static async Task Run(Func<Task> function, string[] args)
        {
            await using (var transaction = await new ContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
            {
                try
                {
                    await function();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
