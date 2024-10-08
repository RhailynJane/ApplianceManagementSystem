using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ModernApplicance
{
    public class Program
    {
        // A static list that holds all the appliances loaded from the file
        static List<Appliance> appliances = new List<Appliance>();

        // Path to the file that contains appliance data
        static string path = "..\\..\\res\\appliances.txt";

        // Entry point of the application
        static void Main(string[] args)
        {
            // Load appliances from the file into the 'appliances' list
            LoadAppliances();

            // Infinite loop to keep the program running until the user exits
            while (true)
            {
                // Display the main menu options to the user
                Console.WriteLine("\nWelcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit");
                Console.WriteLine("Enter option: ");

                // Read the user’s input (menu choice)
                string option = Console.ReadLine();

                // Switch statement to handle user input and call the corresponding method
                switch (option)
                {
                    case "1":
                        CheckoutAppliance(); // Allows user to check out an appliance
                        break;
                    case "2":
                        FindAppliancesByBrand(); // Finds appliances by their brand
                        break;
                    case "3":
                        DisplayAppliancesByType(); // Displays appliances based on their type
                        break;
                    case "4":
                        DisplayRandomAppliances(); // Randomly displays a list of appliances
                        break;
                    case "5":
                        SaveAppliances(); // Saves the appliance data to the file and exits the program
                        return; // Exits the application
                    default:
                        Console.WriteLine("Invalid option. Please try again."); // Invalid input
                        break;
                }
            }
        }

        // Loads appliance data from a file and populates the 'appliances' list
        public static void LoadAppliances()
        {
            // Check if the file exists at the specified path
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(path);

            // Loop through each line (appliance record)
            foreach (string line in lines)
            {
                // Split the line into individual fields using ';' as the delimiter
                string[] data = line.Split(';');

                // Determine the appliance type by checking the first digit of the item number
                if (data[0].StartsWith("1")) // If it starts with "1", it's a Refrigerator
                {
                    Refrigerator refrigerator = new Refrigerator(
                        data[0],                     // Item number
                        data[1],                     // Brand
                        int.Parse(data[2]),          // Quantity
                        int.Parse(data[3]),          // Wattage
                        data[4],                     // Color
                        double.Parse(data[5]),       // Price
                        int.Parse(data[6]),          // Number of doors (2, 3, or 4)
                        int.Parse(data[7]),          // Height
                        int.Parse(data[8])           // Width
                    );
                    appliances.Add(refrigerator);   // Add the refrigerator to the list
                }
                else if (data[0].StartsWith("2")) // If it starts with "2", it's a Vacuum
                {
                    Vacuum vacuum = new Vacuum(
                        data[0],                     // Item number
                        data[1],                     // Brand
                        int.Parse(data[2]),          // Quantity
                        int.Parse(data[3]),          // Wattage
                        data[4],                     // Color
                        double.Parse(data[5]),       // Price
                        data[6],                     // Grade
                        int.Parse(data[7])           // Battery voltage (18 V or 24 V)
                    );
                    appliances.Add(vacuum);          // Add the vacuum to the list
                }
                else if (data[0].StartsWith("3")) // If it starts with "3", it's a Microwave
                {
                    Microwave microwave = new Microwave(
                        data[0],                     // Item number
                        data[1],                     // Brand
                        int.Parse(data[2]),          // Quantity
                        int.Parse(data[3]),          // Wattage
                        data[4],                     // Color
                        double.Parse(data[5]),       // Price
                        double.Parse(data[6]),       // Capacity
                        data[7]                      // Room type (K or W)
                    );
                    appliances.Add(microwave);       // Add the microwave to the list
                }
                else if (data[0].StartsWith("4") || data[0].StartsWith("5")) // Dishwasher
                {
                    Dishwasher dishwasher = new Dishwasher(
                        data[0],                     // Item number
                        data[1],                     // Brand
                        int.Parse(data[2]),          // Quantity
                        int.Parse(data[3]),          // Wattage
                        data[4],                     // Color
                        double.Parse(data[5]),       // Price
                        data[6],                     // Feature
                        data[7]                      // Sound rating (Qt, Qr, Qu, M)
                    );
                    appliances.Add(dishwasher);      // Add the dishwasher to the list
                }
            }
        }

        // Allows the user to check out an appliance (reduce its quantity by 1)
        public static void CheckoutAppliance()
        {
            Console.WriteLine("Enter the item number of an appliance:");
            string itemNumber = Console.ReadLine(); // Read the item number from the user

            // Find the appliance with the entered item number
            Appliance appliance = appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);

            // If appliance is found and available in stock
            if (appliance != null)
            {
                if (appliance.Quantity > 0)
                {
                    appliance.Quantity--; // Reduce the quantity by 1
                    Console.WriteLine($"Appliance \"{appliance.ItemNumber}\" has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
            else
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        // Finds and displays appliances based on the brand entered by the user
        public static void FindAppliancesByBrand()
        {
            Console.WriteLine("Enter brand to search for:");
            string brand = Console.ReadLine().ToLower(); // Read brand name and convert to lowercase for case-insensitive search

            // Find all appliances that match the brand
            List<Appliance> matchingAppliances = appliances.Where(a => a.Brand.ToLower() == brand).ToList();

            // If any appliances match, display them
            if (matchingAppliances.Count > 0)
            {
                Console.WriteLine("\nMatching Appliances:");
                foreach (Appliance appliance in matchingAppliances)
                {
                    Console.WriteLine(appliance); // Use ToString() to display appliance info
                }
            }
            else
            {
                Console.WriteLine("No matching appliances found.");
            }
        }


        // Displays appliances based on type (Refrigerators, Vacuums, Microwaves, or Dishwashers)
        public static void DisplayAppliancesByType()
        {
            Console.WriteLine("\nAppliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.WriteLine("Enter type of appliance:");

            string type = Console.ReadLine(); // Get the type from the user

            if (type == "1") // Display refrigerators
            {
                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors), or 4 (four doors):");
                int doors = int.Parse(Console.ReadLine()); // Get number of doors

                // Validate number of doors
                if (doors != 2 && doors != 3 && doors != 4)
                {
                    Console.WriteLine("Invalid number of doors. Please enter 2, 3, or 4.");
                    return;
                }

                // Find all refrigerators that match the number of doors
                List<Refrigerator> refrigerators = appliances.OfType<Refrigerator>()
                    .Where(r => r.NumberOfDoors == doors).ToList();

                if (refrigerators.Count > 0)
                {
                    Console.WriteLine("\nMatching refrigerators:");
                    DisplayApplianceList(refrigerators);
                }
                else
                {
                    Console.WriteLine("No matching refrigerators found.");
                }
            }
            else if (type == "2") // Display vacuums
            {
                Console.WriteLine("Enter battery voltage value: 18 V (low) or 24 V (high):");
                int voltage = int.Parse(Console.ReadLine());

                // Validate battery voltage
                if (voltage != 18 && voltage != 24)
                {
                    Console.WriteLine("Invalid battery voltage. Please enter 18 or 24.");
                    return;
                }

                // Find vacuums that match the battery voltage
                List<Vacuum> vacuums = appliances.OfType<Vacuum>()
                    .Where(v => v.BatteryVoltage == voltage).ToList();

                if (vacuums.Count > 0)
                {
                    Console.WriteLine("\nMatching vacuums:");
                    DisplayApplianceList(vacuums);
                }
                else
                {
                    Console.WriteLine("No matching vacuums found.");
                }
            }
            else if (type == "3") // Display microwaves
            {
                Console.WriteLine("Enter room type (K for kitchen, W for workshop):");
                string roomType = Console.ReadLine().ToUpper(); // Read and convert to uppercase

                // Validate room type
                if (roomType != "K" && roomType != "W")
                {
                    Console.WriteLine("Invalid room type. Please enter K or W.");
                    return;
                }

                // Find microwaves that match the room type
                List<Microwave> microwaves = appliances.OfType<Microwave>()
                    .Where(m => m.RoomType == roomType).ToList();

                if (microwaves.Count > 0)
                {
                    Console.WriteLine("\nMatching microwaves:");
                    DisplayApplianceList(microwaves);
                }
                else
                {
                    Console.WriteLine("No matching microwaves found.");
                }
            }
            else if (type == "4") // Display dishwashers
            {
                Console.WriteLine("Enter sound rating (Qt for quiet, Qr for regular, Qu for loud, M for medium):");
                string soundRating = Console.ReadLine().ToUpper(); // Read and convert to uppercase

                // Validate sound rating
                if (soundRating != "QT" && soundRating != "QR" && soundRating != "QU" && soundRating != "M")
                {
                    Console.WriteLine("Invalid sound rating. Please enter Qt, Qr, Qu, or M.");
                    return;
                }

                // Find dishwashers that match the sound rating
                List<Dishwasher> dishwashers = appliances.OfType<Dishwasher>()
                    .Where(d => d.SoundRating == soundRating).ToList();

                if (dishwashers.Count > 0)
                {
                    Console.WriteLine("\nMatching dishwashers:");
                    DisplayApplianceList(dishwashers);
                }
                else
                {
                    Console.WriteLine("No matching dishwashers found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid appliance type selected.");
            }
        }

        // Displays a random selection of appliances
        public static void DisplayRandomAppliances()
        {
            Console.WriteLine("Enter number of appliances:");

            // Read user input for the number of appliances
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Please enter a valid number greater than zero.");
            }

            // Check if the count exceeds available appliances
            if (count > appliances.Count)
            {
                Console.WriteLine($"There are only {appliances.Count} appliances available.");
                count = appliances.Count; // Adjust count to available appliances
            }

            // Generate a random appliance list of the specified count
            Random random = new Random();
            List<Appliance> randomAppliances = appliances.OrderBy(x => random.Next()).Take(count).ToList();

            Console.WriteLine("Random Appliances:");
            DisplayApplianceList(randomAppliances);
        }




        // Saves the current state of appliances back to the file
        public static void SaveAppliances()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                // Loop through each appliance and write its data to the file
                foreach (Appliance appliance in appliances)
                {
                    writer.WriteLine(appliance.ToFileString());
                }
            }
            Console.WriteLine("Appliances saved successfully.");
        }

        // Utility method to display a list of appliances
        public static void DisplayApplianceList<T>(List<T> appliances) where T : Appliance
        {
            foreach (var appliance in appliances)
            {
                Console.WriteLine(appliance);
            }
        }
    }
}