using ClassExercise4Inheritance;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

//Author: Kyle Angeles
//Date: 11/30/25
//Moditifed: 11/30/25
// Description: Creating a data storage for a way to ensure the Vehicle 
// Description: inventory is saved between each launch of the program
namespace CarList
{
    internal class VehicleRepo
    {
        // Private variable
        private readonly string FilePath = "Vehicle.json";

        /// <summary>
        /// Save vehciles to JSON file
        /// </summary>
        /// <param name="vehicles"></param>
        public void Save(List<Vehicle> vehicles)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(vehicles, options);

                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving vehicle: {ex.Message}");

            }

        }

        /// <summary>
        /// Loading File to JSON file
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<Vehicle>(); //Return empty list if file is missing

                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading vehicles: {ex.Message}");
                return new List<Vehicle>();

            }

        }

        /// <summary>
        /// Function to remove the selected vehicle record
        /// </summary>
        /// <param name="vehicles"></param>
        /// <param name="vehicleToRemove"></param>
        public void Remove(List<Vehicle> vehicles, Vehicle vehicleToRemove)

        {

            if (vehicleToRemove != null)
            {
                vehicles.Remove(vehicleToRemove);
                Save(vehicles);
            }



        }
    }
}

