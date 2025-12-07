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
        // private variable in this class
        private static string path = "vehicles.json";
        
        /// <summary>
        /// This function just adds vehicle to local json file
        /// Referred back to old Java codes to see what i did for saving files
        /// Referenced Kyle Chapman's code 
        /// </summary>
        /// <param name="newVehicle"></param>
        /// <returns></returns>
        internal static bool Add(Vehicle newVehicle)
        {
            string jsonString = JsonSerializer.Serialize(newVehicle);
            File.AppendAllText("vehicles.json", jsonString);
            return true;
        }


        /// <summary>
        /// Load vehicles from the added JSON file
        /// </summary>
        /// <returns></returns>
        internal static List<Vehicle> Load()

        {
            if (!File.Exists("vehicles.json"))
            {
                return new List<Vehicle>();
            }

            string jsonString = File.ReadAllText("vehicles.json");
            return JsonSerializer.Deserialize<List<Vehicle>>(jsonString) ?? new List<Vehicle>();
        }

        /// <summary>
        /// Save vehicle from the added json file
        /// when changes are made
        /// </summary>
        /// <param name="newVehicle"></param>
        internal static void Save(List<Vehicle> vehicles)
        {

            string jsonString = JsonSerializer.Serialize(vehicles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        /// <summary>
        /// Function to delete vehicle from json file
        /// </summary>
        /// <param name="VehicleToDelete"></param>
        internal static void Delete(Vehicle VehicleToDelete)
        {
            string path = "vehicles.json";


            if (!File.Exists(path)) {
                return;
            }

            string jsonString = File.ReadAllText(path);
            List<Vehicle> vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonString) ?? new List<Vehicle>();

            vehicles.RemoveAll(v => v.CarID == VehicleToDelete.CarID);

            string updatedJson = JsonSerializer.Serialize(vehicles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, updatedJson);

            Console.WriteLine($"Vehicle with ID: {VehicleToDelete.CarID} deleted.");


        }
    }
}
         

