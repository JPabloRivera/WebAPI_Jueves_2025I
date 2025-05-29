using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2025I.DAL;
using ShoppingAPI_Jueves_2025I.DAL.Entities;
using ShoppingAPI_Jueves_2025I.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2025I.Domain.Services
{
    public class StateService : IStateService
    {

        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
                _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            try
            {
                var states = await _context.States.Include(s => s.Country).Where(s => s.CountryId == countryId).ToListAsync();
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<State>> GetStatesByNameAsync(String stateName)
        {
            try
            {
                var states = await _context.States.Where(s => s.Name == stateName).ToListAsync();
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;

                _context.States.Add(state); // El método Add() me permite crear el objeto en el contexto de mi BD

                await _context.SaveChangesAsync(); // Este método me permite guardar el Estado en mi tabla STATE

                return state;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state);

                await _context.SaveChangesAsync();

                return state;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid guid)
        {
            try
            {
                var state = await _context.States.FindAsync(guid);

                if (state == null)
                {
                    return null;
                }

                _context.States.Remove(state);

                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
