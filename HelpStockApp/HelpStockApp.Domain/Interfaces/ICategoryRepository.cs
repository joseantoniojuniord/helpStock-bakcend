using HelpStockApp.Domain.Entities;

namespace HelpStockApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetById(int? id);

        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
<<<<<<< Updated upstream:HelpStockApp/HelpStockApp.Domain/Interfaces/ICategoryRepository.cs
}
=======
}
>>>>>>> Stashed changes:HelpStockApp/StockHelpApp.Domain/Interfaces/ICategoryRepository.cs
