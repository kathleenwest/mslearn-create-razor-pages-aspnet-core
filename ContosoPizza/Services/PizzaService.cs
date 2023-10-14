using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    /// <summary>
    /// Pizza Service
    /// Get, Add, and Deletion of Pizzas from Data layer
    /// </summary>
    public class PizzaService
    {
        /// <summary>
        /// Reference to the Injected Data Service Dependency 
        /// </summary>
        private readonly PizzaContext _context = default!;

        /// <summary>
        /// Constructor
        /// Injects the Data Service "PizzaContext"
        /// </summary>
        /// <param name="context">(PizzaContext) reference to data service</param>
        public PizzaService(PizzaContext context) 
        {
            _context = context;

        } // end of constructor
        
        /// <summary>
        /// Gets all available pizzas from the data service
        /// </summary>
        /// <returns>a IList of Pizza model objects</returns>
        public IList<Pizza> GetPizzas()
        {
            // Validate the data service is initialized
            if(_context.Pizzas != null)
            {
                // Use the data service to retrieve the list of pizzas
                return _context.Pizzas.ToList();
            }

            // Default, return new, but empty list
            return new List<Pizza>();
        }

        /// <summary>
        /// Adds a new pizza via the data service. 
        /// </summary>
        /// <param name="pizza">A (valid) Pizza class object model</param>
        public void AddPizza(Pizza pizza)
        {
            // Validate the data service is initialized
            if (_context.Pizzas != null)
            {
                // Use the data service to add a new pizza object
                _context.Pizzas.Add(pizza);

                // Request the data service save/persist the changes
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a specific pizza (by id) from the data service
        /// </summary>
        /// <param name="id">Unique identifer (int) of the pizza object</param>
        public void DeletePizza(int id)
        {
            // Validate the data service is initialized
            if (_context.Pizzas != null)
            {
                // Find the reference (if applicable) to the Pizza object in the database
                Pizza? pizza = _context.Pizzas.Find(id);

                // First validate the pizza exists via the data service
                if (pizza != null)
                {
                    // Remove the pizza via the data service
                    _context.Pizzas.Remove(pizza);

                    // Request the data service save/persist the changes
                    _context.SaveChanges();
                }
            }            
        } 

    } // end of class
} // end of namesapce
