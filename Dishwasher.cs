using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernApplicance // Declare the namespace for the project
{
    // Class Dishwasher inherits from the base class Appliance
    public class Dishwasher : Appliance
    {
        // Private fields for specific dishwasher attributes
        string feature; // Unique features of the dishwasher (e.g., energy-saving)
        string soundRating; // Sound rating indicating noise levels during operation (e.g., Quiet)

        // Public properties to access and modify private fields
        public string Feature
        {
            get => feature; // Getter for the feature property
            set => feature = value; // Setter for the feature property
        }

        public string SoundRating
        {
            get => soundRating; // Getter for the sound rating property
            set => soundRating = value; // Setter for the sound rating property
        }

        // Default constructor for Dishwasher
        public Dishwasher()
        {
            // Initialize default values if necessary (currently does nothing)
        }

        // Constructor for Dishwasher that initializes specific attributes
        public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, double price, string feature, string soundRating)
        : base(itemNumber, brand, quantity, wattage, color, price) // Calls the base class constructor to initialize common attributes
        {
            Feature = feature; // Set the specific feature for the dishwasher
            SoundRating = soundRating; // Set the sound rating for the dishwasher
        }

        // Override ToString method to provide a formatted string representation of the dishwasher
        public override string ToString()
        {
            // Convert abbreviated SoundRating to full form
            string fullSoundRating; // Variable to hold the expanded sound rating

            // Determine the full sound rating based on the abbreviated value
            switch (SoundRating)
            {
                case "Qt":
                    fullSoundRating = "Quietest"; // Expand "Qt" to "Quietest"
                    break;
                case "Qr":
                    fullSoundRating = "Quieter"; // Expand "Qr" to "Quieter"
                    break;
                case "Qu":
                    fullSoundRating = "Quiet"; // Expand "Qu" to "Quiet"
                    break;
                case "M":
                    fullSoundRating = "Moderate"; // Expand "M" to "Moderate"
                    break;
                default:
                    fullSoundRating = "Unknown"; // Fallback in case of unexpected values
                    break;
            }

            // Return a formatted string representation of the dishwasher, including common and specific properties
            return base.ToString() + // Call base ToString to include common properties
                   $"Feature: {Feature}\n" + // Include specific feature
                   $"SoundRating: {fullSoundRating}\n"; // Display the full sound rating
        }

        // Override ToFileString method to save dishwasher details to a file
        public override string ToFileString()
        {
            // Return a string representation suitable for file storage, separating values with semicolons
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating}";
        }
    }
}