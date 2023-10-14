using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    /// <summary>
    /// PizzaList Page Model Class
    /// </summary>
    public class PizzaListModel : PageModel
    {
        /// <summary>
        /// Reference to injected and dependency Pizza Service
        /// </summary>
        private readonly PizzaService _service;
        
        /// <summary>
        /// List of all Available Pizzas
        /// </summary>
        public IList<Pizza> PizzaList { get; set; } = default!;

        /// <summary>
        /// Property to Hold Newly Added Pizza from Page
        /// </summary>
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Reference to Scoped PizzaService</param>
        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Executes on Page Load
        /// </summary>
        public void OnGet()
        {
            // Retrieve list of all availabe pizzas
            PizzaList = _service.GetPizzas();
        }

        /// <summary>
        /// Executes on Page Form Submission
        /// </summary>
        /// <returns>result IActionResult</returns>
        public IActionResult OnPost()
        {
            // Validate the page model is valid before continuing
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            // Add a new pizza from the page model via the Pizza Service
            _service.AddPizza(NewPizza);

            // Refresh this page model
            return RedirectToAction("Get");
        }

        /// <summary>
        /// Deletes the Pizza object from the data given a valid identifier
        /// </summary>
        /// <param name="id">Unique identifier (int) of the pizza object</param>
        /// <returns>result IActionResult</returns>
        public IActionResult OnPostDelete(int id)
        {
            // Delete pizza from the page model via the Pizza Service
            _service.DeletePizza(id);

            // Refresh this page model
            return RedirectToAction("Get");
        }

    } // end of class
} // end of namespace