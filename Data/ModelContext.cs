using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Test3.Models;

namespace Test3.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emp> Emps { get; set; }

        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //     => optionsBuilder.UseOracle("User Id=scott;Password=tiger;Data Source=localhost:1521;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SCOTT");

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasPrecision(4)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedOnAdd()
                    .UseHiLo("EMP_SEQ");
                entity.Property(e => e.Comm)
                    .HasColumnType("NUMBER(7,2)")
                    .HasColumnName("COMM");
                entity.Property(e => e.Deptno)
                    .HasPrecision(2)
                    .HasColumnName("DEPTNO");
                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENAME");
                entity.Property(e => e.Hiredate)
                    .HasColumnType("DATE")
                    .HasColumnName("HIREDATE");
                entity.Property(e => e.Job)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("JOB");
                entity.Property(e => e.Mgr)
                    .HasPrecision(4)
                    .HasColumnName("MGR");
                entity.Property(e => e.Sal)
                    .HasColumnType("NUMBER(7,2)")
                    .HasColumnName("SAL");
            });
            modelBuilder.HasSequence("EMP_SEQ").IncrementsBy(10);

            OnModelCreatingPartial(modelBuilder);
        }

        internal Task<List<Emp>> ToListAsync()
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
