using Test3.Models;

namespace Test3.Repository
{
    public interface IEmpRepository
    {
        //전체 조회
       Task<List<Emp>> GetAll();

        //단일 항목 조회
       Task<Emp> Get(int? empno);

        //등록
       Task<int> Add(Emp emp);

        //삭제
       Task<int> Delete(int? empno); 

        //수정
       Task Update(Emp emp);
    }
}