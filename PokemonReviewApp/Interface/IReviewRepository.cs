﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
        bool CreateReview(int reviewerId, int pokemonId, Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();
    }
}
