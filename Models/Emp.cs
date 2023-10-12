using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    public partial class Emp
    {
        public decimal? Empno { get; set; }

        public string? Ename { get; set; }

        public string? Job { get; set; }

        public decimal? Mgr { get; set; }

        public DateTime? Hiredate { get; set; }

        public decimal? Sal { get; set; }

        public decimal? Comm { get; set; }

        public decimal? Deptno { get; set; }
    }
}
