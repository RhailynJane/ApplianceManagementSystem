using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernApplicance
{
    // Class Microwave inherits from the base class Appliance
    public class Microwave : Appliance
    {
        // Private fields for specific microwave attributes
        double capacity; // Capacity of the microwave (in liters or cubic feet)
        string roomType; // Indicates the type of room where the microwave is used (e.g., kitchen or work site)

        // Public property for accessing and modifying the capacity of the microwave
        public double Capacity
        {
            get => capacity; // Getter returns the current capacity
            set => capacity = value; // Setter assigns a new value to capacity
        }

        // Public property for accessing and modifying the room type of the microwave
        public string RoomType
        {
            get => roomType; // Getter returns the current room type
            set => roomType = value; // Setter assigns a new value to room type
        }

        // Default constructor for Microwave
        public Microwave()
        {
            // This constructor is currently empty, and no default values are set
        }

        // Parameterized constructor for Microwave to initialize specific attributes
        public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, double price, double capacity, string roomType)
        : base(itemNumber, brand, quantity, wattage, color, price) // Calls the base class constructor to initialize common properties
        {
            Capacity = capacity; // Set the specific capacity for the microwave
            RoomType = roomType; // Set the specific room type for the microwave
        }

        // Override ToString method to provide a formatted string representation of the microwave
        public override string ToString()
        {
            // Return a formatted string that includes common properties and specific attributes
            return base.ToString() + // Call base ToString to include common properties from Appliance
                   $"Capacity: {Capacity}\n" + // Include specific capacity of the microwave
                   $"RoomType: {(RoomType.Equals("K", StringComparison.OrdinalIgnoreCase) ? "Kitchen" : "Work Site")}\n"; // Convert "K" to "Kitchen" and anything else to "Work Site"
        }

        // Override ToFileString method to provide a string representation suitable for file storage
        public override string ToFileString()
        {
            // Return a semicolon-separated string containing all relevant microwave details for file storage
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomType}";
        }
    }
}

