using ShoppingAPI_Jueves_2025I.DAL.Entities;
using System.Threading.Tasks;

namespace ShoppingAPI_Jueves_2025I.Domain.Interfaces
{
    public interface IStateService
    {

        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId);

        Task<IEnumerable<State>> GetStatesByNameAsync(String stateName);

        Task<State> CreateStateAsync(State state);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid guid);

    }
}
