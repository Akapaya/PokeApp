using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using System.Linq;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);

            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(c=>c.Pokemon).ToList();
        }

        public ICollection<Pokemon> RemovePokemonsByCategory(int categoryId)
        {
            var pokemonsToRemove = _context.Pokemons
                .Where(p => p.Categories != null && p.Categories.Any(c => c.CategoryId == categoryId))
                .ToList();

            foreach (var pokemon in pokemonsToRemove)
            {
                if (pokemon.Categories != null)
                {
                    var categoryToRemove = pokemon.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                    if (categoryToRemove != null)
                    {
                        pokemon.Categories.Remove(categoryToRemove);
                    }
                }
            }

            Save();

            return pokemonsToRemove;
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);

            return Save();
        }
    }
}
