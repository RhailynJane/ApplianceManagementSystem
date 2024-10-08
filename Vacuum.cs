using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernApplicance
{
    // Class Vacuum inherits from the base class Appliance
    public class Vacuum : Appliance
    {
        // Private fields for specific vacuum attributes
        string grade; // The grade or quality level of the vacuum (e.g., standard, premium)
        int batteryVoltage; // The voltage of the battery used in the vacuum

        // Public property for accessing and modifying the grade of the vacuum
        public string Grade
        {
            get => grade; // Getter returns the current grade
            set => grade = value; // Setter assigns a new value to grade
        }

        // Public property for accessing and modifying the battery voltage of the vacuum
        public int BatteryVoltage
        {
            get => batteryVoltage; // Getter returns the current battery voltage
            set => batteryVoltage = value; // Setter assigns a new value to battery voltage
        }

        // Default constructor for Vacuum
        public Vacuum()
        {
            // This constructor is currently empty and does not initialize any fields
        }

        // Constructor for Vacuum to initialize specific attributes
        public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, double price, string grade, int batteryVoltage)
        : base(itemNumber, brand, quantity, wattage, color, price) // Calls the base class constructor to initialize common properties
        {
            Grade = grade; // Set the specific grade for the vacuum
            BatteryVoltage = batteryVoltage; // Set the specific battery voltage for the vacuum
        }

        // Override ToString method to provide a formatted string representation of the vacuum
        public override string ToString()
        {
            // Determine the voltage level based on the battery voltage
            string voltageLevel = (BatteryVoltage == 18) ? "Low" : "High"; // Set voltage level to "Low" if 18V, otherwise "High"

            // Return a formatted string that includes common properties and specific attributes
            return base.ToString() + // Call base ToString to include common properties from Appliance
                   $"Grade: {Grade}\n" + // Include specific grade of the vacuum
                   $"BatteryVoltage: {voltageLevel}\n"; // Display the voltage level as either "Low" or "High"
        }

        // Override ToFileString method to provide a string representation suitable for file storage
        public override string ToFileString()
        {
            // Return a semicolon-separated string containing all relevant vacuum details for file storage
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage}";
        }
    }
}
