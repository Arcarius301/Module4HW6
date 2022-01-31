using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Module4HW6.Data;
using Module4HW6.Data.Queries;
using Module4HW6.Helpers;

namespace Module4HW6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                #if DEBUG
                var initializer = new DbInitializer(context);
                await QueryWrapper.Run(() => initializer.AddData(), args);
                #endif
                var queries = new Queries(context);
                await QueryWrapper.Run(() => queries.ShowSongs(), args);
                await QueryWrapper.Run(() => queries.ShowGroupedByGenre(), args);
                await QueryWrapper.Run(() => queries.ShowFilteredSongs(), args);
            }

            Console.Read();
        }
    }
}