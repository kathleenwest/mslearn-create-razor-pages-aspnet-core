using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

/// <summary>
/// Pizza Model
/// </summary>
public class Pizza
{
    /// <summary>
    /// Identifier (Unique Integer) for the Pizza object
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the Pizza
    /// </summary>
    [Required]
    public string? Name { get; set; }
    
    /// <summary>
    /// Size of the Pizza (enum PizzaSize)
    /// </summary>
    public PizzaSize Size { get; set; }
    
    /// <summary>
    /// Is this Pizza Gluten Free (True if Yes)
    /// </summary>
    public bool IsGlutenFree { get; set; }

    /// <summary>
    /// Price of the Pizza 
    /// </summary>
    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
}

/// <summary>
/// Pizza Size Options
/// </summary>
public enum PizzaSize { Small, Medium, Large }