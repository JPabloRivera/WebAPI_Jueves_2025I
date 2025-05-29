
using ShoppingAPI_Jueves_2025I.DAL.Entities;

namespace ShoppingAPI_Jueves_2025I.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        // Se crea método llamado seederAsync
        // Este método es una especie de MAIN()
        // Este método tiene la responsabilidad de prepoblar mis diferentes tablas de la BD

        public async Task SeederAsync()
        {
            // Primero se agrega método propio de EF que hace las veces del comando 'update-database'
            // En otras palabras un método que me creara la BD inmediatamente ponga en ejecución mi API
            await _context.Database.EnsureCreatedAsync();

            //A partir de aqui se crean métodos que serviran para prepoblar mi BD
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync(); // Esta linea guarda los datos en BD
        }


        #region Private Methos

        private async Task PopulateCountriesAsync()
        {
            // Método Any() indica si la tabla tiene al menos un registro
            // El método Any negado (!) me indica que no hay absolutamente nada en la tabla countries.
            if (!_context.Countries.Any())
            {
                // Así se crea un objeto país con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }

                });

                // Aqui se crea otro nuevo objeto país con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }
    }
        #endregion
 
}
