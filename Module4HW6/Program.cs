using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Module4HW6.Data;
using Module4HW6.Helpers;

namespace Module4HW6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                var queries = new Queries(context);
#if DEBUG
                await QueryWrapper.Run(() => queries.FillDatabase(), args);
#endif
            }

            Console.Read();
        }
    }
}