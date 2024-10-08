using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernApplicance
{
    // Abstract class representing a general appliance.
    // This class cannot be instantiated directly and serves as a base for specific appliance types.
    public abstract class Appliance
    {
        // Private fields to store appliance properties
        string itemNumber; // Unique identifier for the appliance
        string brand; // Brand name of the appliance
        int quantity; // Quantity available for checkout
        int wattage; // Power consumption in watts
        string color; // Color of the appliance
        double price; // Price of the appliance

        // Public properties to access and modify private fields
        public string ItemNumber { get => itemNumber; set => itemNumber = value; } // Gets or sets the item number
        public string Brand { get => brand; set => brand = value; } // Gets or sets the brand
        public int Quantity { get => quantity; set => quantity = value; } // Gets or sets the quantity
        public int Wattage { get => wattage; set => wattage = value; } // Gets or sets the wattage
        public string Color { get => color; set => color = value; } // Gets or sets the color
        public double Price { get => price; set => price = value; } // Gets or sets the price

        // Default constructor
        public Appliance()
        {
            // Initialize default values if necessary
        }

        // Constructor that initializes an appliance with specified values
        public Appliance(string itemNumber, string brand, int quantity, int wattage, string color, double price)
        {
            ItemNumber = itemNumber; // Set item number
            Brand = brand; // Set brand
            Quantity = quantity; // Set quantity
            Wattage = wattage; // Set wattage
            Color = color; // Set color
            Price = price; // Set price
        }

        // Override ToString method to provide a formatted string representation of the appliance
        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\n" + // Output the item number
                   $"Brand: {Brand}\n" + // Output the brand
                   $"Quantity: {Quantity}\n" + // Output the quantity
                   $"Wattage: {Wattage}\n" + // Output the wattage
                   $"Color: {Color}\n" + // Output the color
                   $"Price: {Price}\n"; // Output the price
        }

        // Abstract method to be implemented by derived classes for saving appliance details to a file
        public abstract string ToFileString();
    }
}
