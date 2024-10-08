using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernApplicance
{
    // Class Refrigerator inherits from the base class Appliance
    public class Refrigerator : Appliance
    {
        // Private fields for specific refrigerator attributes
        int numberOfDoors; // The number of doors the refrigerator has
        int height; // The height of the refrigerator (in centimeters or inches)
        int width; // The width of the refrigerator (in centimeters or inches)

        // Public property to access and modify the number of doors
        public int NumberOfDoors
        {
            get => numberOfDoors; // Getter returns the current number of doors
            set => numberOfDoors = value; // Setter assigns a new value to number of doors
        }

        // Public property to access and modify the height of the refrigerator
        public int Height
        {
            get => height; // Getter returns the current height
            set => height = value; // Setter assigns a new value to height
        }

        // Public property to access and modify the width of the refrigerator
        public int Width
        {
            get => width; // Getter returns the current width
            set => width = value; // Setter assigns a new value to width
        }

        // Default constructor for Refrigerator
        public Refrigerator()
        {
            // This constructor is currently empty and does not initialize any fields
        }

        // Constructor for Refrigerator to initialize specific attributes
        public Refrigerator(string itemNumber, string brand, int quantity, int wattage, string color, double price, int numberOfDoors, int height, int width)
        : base(itemNumber, brand, quantity, wattage, color, price) // Calls the base class constructor to initialize common properties
        {
            NumberOfDoors = numberOfDoors; // Set the specific number of doors for the refrigerator
            Height = height; // Set the specific height for the refrigerator
            Width = width; // Set the specific width for the refrigerator
        }

        // Method to return a string representation of the number of doors
        public string GetNumberOfDoorsText()
        {
            // Determine the text representation based on the number of doors
            switch (NumberOfDoors)
            {
                case 2:
                    return "Two Doors"; // Return "Two Doors" if there are 2 doors
                case 3:
                    return "Three Doors"; // Return "Three Doors" if there are 3 doors
                case 4:
                    return "Four Doors"; // Return "Four Doors" if there are 4 doors
                default:
                    return "Unknown"; // Fallback for unexpected values
            }
        }

        // Override ToString method to provide a formatted string representation of the refrigerator
        public override string ToString()
        {
            // Return a formatted string that includes common properties and specific attributes
            return base.ToString() + // Call base ToString to include common properties from Appliance
                   $"Number of Doors: {GetNumberOfDoorsText()}\n" + // Include number of doors
                   $"Height: {Height}\n" + // Include height of the refrigerator
                   $"Width: {Width}\n"; // Include width of the refrigerator
        }

        // Override ToFileString method to provide a string representation suitable for file storage
        public override string ToFileString()
        {
            // Return a semicolon-separated string containing all relevant refrigerator details for file storage
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumberOfDoors};{Height};{Width}";
        }
    }
}
