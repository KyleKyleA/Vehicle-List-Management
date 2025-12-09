using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

// Two libaries for file reading 
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using ClassExercise4Inheritance;
using System.Text.Json;

// Author: Kyle Angeles
// File: MenuBar.cs
// Modified: Dec 7st 2025
// Description: This class handles the new GUI experience that I wanted to do which was to have a menu bar
// which handles the file operations that a user would expect from a typical application such as creating a new file, open a current saved file, and saving file
// Along with copy and paste functionality
namespace CarList
{
    internal class MenuBar
    {
        public MenuBar() {

        }

        /// <summary>
        /// Displays a message indicating that a new file has been created.
        /// </summary>
        public void newFile() {

            MessageBox.Show("New file created");
        }

        /// <summary>
        /// Function to save a file from the menu bar
        /// </summary>
        /// <param name="content"></param>
        public void saveFile(List<Vehicle> vehicles)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON (*.json) | *.json | All Files (*.*) | *.*", // File type filter 
                DefaultExt = ".json" // Files default saved will be in txt files for now 
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName; // Using users file exploer to save files 
                string jsonString = JsonSerializer.Serialize(vehicles, new JsonSerializerOptions { WriteIndented = true}); // Serializing the list of vehicles to json format
                File.WriteAllText(path, jsonString);
                //Confirmation Message
                MessageBox.Show("File has been saved: " + path);
            }
        }

        /// <summary>
        /// Opens a file selection dialog to allow the user to select the json file from their file explorer
        /// and deserializes the content into a list of vehicles
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON (*.json) | *.json | All Files (*.*) | *.*",
            };

            if (openFileDialog.ShowDialog() == true) {
               
               string path = openFileDialog.FileName;
               string jsonString = File.ReadAllText(path);
               return JsonSerializer.Deserialize<List<Vehicle>>(jsonString) ?? new List<Vehicle>();
            }

            return new List<Vehicle>(); // Return an empty list if no file is selected

        }


        /// <summary>
        /// Displays a message showing that the file has been copy from the data grid 
        /// and can be use to reinput information from the particular vehicle
        /// </summary>
        public void Copy()
    {
            MessageBox.Show("File has been copied");

    }
        /// <summary>
        /// Displays a message saying that the file or records from input and datagrid where pasted from clip board 
        /// </summary>
        public void Paste()
        {
            MessageBox.Show("pasted from clip board");
        }

}
}
