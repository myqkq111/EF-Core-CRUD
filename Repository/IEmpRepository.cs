using Test3.Models;

namespace Test3.Repository
{
    public interface IEmpRepository
    {
       Task<IEnumerable<Emp>> GetAll();
    }
}