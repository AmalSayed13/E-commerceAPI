using E_commerceAPI.DAL.Repositorries.Generic;


namespace E_commerceAPI.DAL.Repositories.Category
{
    public interface ICategoryRepository : IGenericRepository<Data.Models.Category>
    {
        public Data.Models.Category? GetByName(string name);
    }
}
