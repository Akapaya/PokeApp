using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IcategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
        bool CategoryExists(int categoryId);
    }
}
