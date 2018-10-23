using Microsoft.EntityFrameworkCore;
using PythonSucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PythonSucks.Data
{
    public class EFRepository<RepoType> : IRepository<RepoType> where RepoType : BaseEntity
    {
        private readonly PythonSucksDbContext _context;
        private DbSet<RepoType> _entities;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EFRepository(PythonSucksDbContext context)
        {
            this._context = context;
        }

        public RepoType GetById(Guid id)
        {
            return this.Entities.Find(id);
        }


        public void Insert(RepoType entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);
            UpdateTimeStamps();
            
            this._context.SaveChanges();
        }
        private void UpdateTimeStamps()
        {
            var createdEntities = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            var updatedEntities = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var createdEntity in createdEntities)
            {
                var entity = (BaseEntity)createdEntity.Entity;
                entity.CreateDate = DateTime.UtcNow;
                entity.UpdateDate = DateTime.UtcNow;
            }
            foreach (var updatedEntity in updatedEntities)
            {
                var entity = (BaseEntity)updatedEntity.Entity;
                entity.UpdateDate = DateTime.UtcNow;
            }

        }

        public void Update(RepoType entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            UpdateTimeStamps();
            this._context.SaveChanges();
        }

        public void DeleteWithoutCommit<TRelated>(TRelated entity) where TRelated : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _context.Set<TRelated>().Remove(entity);
        }

        public void Delete(RepoType entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);

            this._context.SaveChanges();
        }

        public virtual IQueryable<RepoType> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private DbSet<RepoType> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<RepoType>();
                return _entities;
            }
        }
    }
}
