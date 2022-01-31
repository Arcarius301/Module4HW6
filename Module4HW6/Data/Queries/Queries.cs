using Microsoft.EntityFrameworkCore;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.Queries
{
    public class Queries
    {
        private readonly ApplicationContext _context;

        public Queries(ApplicationContext context)
        {
            _context = context;
        }
    }
}
