using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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


        //전체 조회
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emp = await repository.GetAll();
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //단일 항목 조회
       [HttpGet("{empno}")]
        public async Task<IActionResult> Get(int? empno)
        {

            if(empno == null){
                return BadRequest();
            }

            try
            {
                var emp = await repository.Get(empno);

                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        //등록
        [HttpPost]
        public async Task<IActionResult> Add(Emp emp)
        {
             try
                {
                    var res = await repository.Add(emp);
           
                    if (res> 0)
                    {
                        return Ok(emp);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
        }


        //삭제
        [HttpDelete("{empno}")]
        public async Task<IActionResult> Delete(int? empno)
        {
            int result = 0;

            if(empno == null)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.Delete(empno);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //수정
        [HttpPut]
        public async Task<IActionResult> Update(Emp emp)
        {    
            try
            {
                await repository.Update(emp);

                return Ok(emp);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    return NotFound();
                }

                return BadRequest();
            } 
        }









    }
}