using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry( int countryId);
        bool CountryExists(int countryId);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool Save();
    }
}
