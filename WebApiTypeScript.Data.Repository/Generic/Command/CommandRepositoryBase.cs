using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Core.Interfaces.Repository.Command;

namespace WebApiTypeScript.Data.Repository.Generic.Command
{
	public abstract class EfCommandRepositoryBase<T> : ICommandRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext context;

        protected EfCommandRepositoryBase(DbContext context)
        {
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			this.context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			this.context.Entry(entity).State = EntityState.Added;

            await this.context.SaveChangesAsync();
        }

        public virtual async Task AddListAsync(ICollection<T> entityList)
        {
			if (entityList == null)
			{
				throw new ArgumentNullException(nameof(entityList));
			}

			foreach (var entity in entityList)
            {
                this.context.Entry(entity).State = EntityState.Added;
            }

            await this.context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			var attachedEntity = this.context.Set(typeof(T)).Attach(this.context.Set(typeof(T)).Find(entity.Id));
            this.context.Entry(attachedEntity).State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }

        public virtual async Task DeleteListAsync(ICollection<T> entityList)
        {
			if (entityList == null)
			{
				throw new ArgumentNullException(nameof(entityList));
			}

			foreach (var entity in entityList)
            {
                var attachedEntity = this.context.Set(typeof(T)).Attach(this.context.Set(typeof(T)).Find(entity.Id));
                this.context.Entry(attachedEntity).State = EntityState.Deleted;
            }
            await this.context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			var attachedEntity = this.context.Set(typeof(T)).Attach(this.context.Set(typeof(T)).Find(entity.Id));
            this.context.Entry(attachedEntity).CurrentValues.SetValues(entity);
            this.context.Entry(attachedEntity).State = EntityState.Modified;

            await this.context.SaveChangesAsync();
        }

        public virtual async Task UpdateListAsync(List<T> entities)
        {
			if (entities == null)
			{
				throw new ArgumentNullException(nameof(entities));
			}

			foreach (var entity in entities)
            {
                var attachedEntity = this.context.Set(typeof(T)).Attach(this.context.Set(typeof(T)).Find(entity.Id));

                this.context.Entry(attachedEntity).CurrentValues.SetValues(entity);
                this.context.Entry(attachedEntity).State = EntityState.Modified;
            }

            await this.context.SaveChangesAsync();
        }

    }
}