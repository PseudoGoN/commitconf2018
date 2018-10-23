using System;
using System.Linq;

namespace PythonSucks.Repository
{
    public partial interface IRepository<RepoType> where RepoType : BaseEntity
    {
        RepoType GetById(Guid id);
        void Insert(RepoType entity);
        void Update(RepoType entity);
        void Delete(RepoType entity);
        void DeleteWithoutCommit<TRelated>(TRelated entity) where TRelated:BaseEntity;
        IQueryable<RepoType> Table { get; }
    }
}
