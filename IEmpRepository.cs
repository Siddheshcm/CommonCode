using MyFirstMVC_SundayBatch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMVC_SundayBatch.Repository
{
    #region Normal Repository
    public interface IEmpRepository
    {
        IEnumerable<Emp> GetEmps();
        Emp GetEmpByID(int empId);
        void InsertEmp(Emp emp);
        void DeleteEmp(int empID);
        void UpdateEmp(Emp emp);
        void Save();
    }
    public class EmpRepository : IEmpRepository
    {
        private CodingFactoryDBEntities context;
        public EmpRepository(CodingFactoryDBEntities _context)
        {
            this.context = _context;
        }
        public IEnumerable<Emp> GetEmps()
        {
            return context.Emps.ToList();
        }
        public Emp GetEmpByID(int empId)
        {
            return context.Emps.Find(empId);
        }
        public void InsertEmp(Emp emp)
        {
            context.Emps.Add(emp);
        }
        public void DeleteEmp(int empID)
        {
            Emp emp = context.Emps.Find(empID);
            context.Emps.Remove(emp);
        }
        public void UpdateEmp(Emp emp)
        {
            context.Entry(emp).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
    #endregion
    public class EmpRepositoryG : IGenericRepository<Emp>
    {
        IGenericRepository<Emp> genRepository;
       
        public EmpRepositoryG(IGenericRepository<Emp> _genRepository)
        {
            genRepository = _genRepository;
        }
        public IEnumerable<Emp> Get(Expression<Func<Emp, bool>> filter = null, string includeProperties = "")
        {
            return this.genRepository.Get(filter, includeProperties);
        }
        public virtual Emp GetByID(object id)
        {
            return this.genRepository.GetByID(id);
        }
        public virtual void Insert(Emp entity)
        {
            this.genRepository.Insert(entity);
            this.genRepository.Save();
        }
        public virtual void Delete(object id)
        {
            Emp emp = this.genRepository.GetByID(id);
        }
        public virtual void Delete(Emp entityToDelete)
        {
            this.genRepository.Delete(entityToDelete);
            this.genRepository.Save();
        }
        public virtual void Update(Emp entityToUpdate)
        {
            this.genRepository.Update(entityToUpdate);
            this.genRepository.Save();
        }
        public virtual void Save()
        {
            this.genRepository.Save();
        }
    }
}
