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

        
        //전체 조회
        public async Task<List<Emp>> GetAll()
        {
            if(context != null)
            {               
                return await context.Emps.ToListAsync();
            }
            return null;
        }


        //단일 항목 조회
         public async Task<Emp> Get(int? empno)
        {
            if(context != null)
            {               
                return await context.Emps.FirstOrDefaultAsync(e => e.Empno == empno);
            }
            return null;
        }


        //등록
        public async Task<int> Add(Emp emp)
        {
            if(context != null)
            {
                await context.Emps.AddAsync(emp);
                await context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }


        //삭제
        public async Task<int> Delete(int? empno)
        {
            int result = 0;

            if(context != null)
            {
                var emp = await context.Emps.FirstOrDefaultAsync(e => e.Empno == empno);

                if (emp != null)
                {
                    context.Emps.Remove(emp);

                    result = await context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }


        //수정
        public async Task Update(Emp emp)
        {
            if(context != null)
            {
               context.Emps.Update(emp); 

               await context.SaveChangesAsync();
            }
        }
    }
}
