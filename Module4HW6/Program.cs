using System;
using System.Collections.Generic;
using System.Linq;
using Module4HW6.Data;

namespace Module4HW6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ContextFactory().CreateDbContext(args))
            {
                var result = context.Artist;

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}