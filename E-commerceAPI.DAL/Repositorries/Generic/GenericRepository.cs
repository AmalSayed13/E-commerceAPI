using E_commerceAPI.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.DAL.Repositorries.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    protected readonly EcommerceContext _context;

    public GenericRepository(EcommerceContext context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>()
            .AsNoTracking();
    }

    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>()
            .Find(id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>()
            .Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>()
            .Remove(entity);
    }

    public void Update(TEntity entity)
    {
    }
}
