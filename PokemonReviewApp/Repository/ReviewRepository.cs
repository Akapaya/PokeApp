using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateReview(int reviewerId, int pokemonId, Review review)
        {
            var reviewReviewerEntity = _context.Reviewers.Where(c => c.Id == reviewerId).FirstOrDefault();
            var reviewPokemonEntity = _context.Pokemons.Where(c => c.Id == pokemonId).FirstOrDefault();

            if(reviewPokemonEntity == null || reviewReviewerEntity == null)
            {
                return false;
            }

            review.Reviewer = reviewReviewerEntity;
            review.Pokemon = reviewPokemonEntity;

            _context.Add(review);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(c => c.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(c => c.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(c => c.Id == reviewId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
