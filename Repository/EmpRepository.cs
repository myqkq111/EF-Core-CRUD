using Microsoft.EntityFrameworkCore;
using Test3.Data;
using Test3.Models;

namespace Test3.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly ModelContext context;
        public EmpRepository(ModelContext _context)
        {
            context =  _context;
        }

        public async Task<IEnumerable<Emp>> GetAll()
        {
            return await context.Emps.ToListAsync();
        }
    }
}
