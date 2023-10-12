using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test3.Models;
using Test3.Repository;

namespace Test3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpController : ControllerBase
    {
        IEmpRepository repository;

        public EmpController(IEmpRepository _repository){
            repository = _repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Emp>> GetAll()
        {
                return await repository.GetAll();
        }

    }
}