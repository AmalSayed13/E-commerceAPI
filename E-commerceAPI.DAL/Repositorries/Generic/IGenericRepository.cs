﻿namespace E_commerceAPI.DAL.Repositorries.Generic;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
