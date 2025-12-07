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
namespace CarList
{
    internal class MenuBar
    {
        public MenuBar() {

        }


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
                Filter = "JSON (*.json) | *.json | All Files (*.*) | *.*",
                DefaultExt = ".txt" // Files default saved will be in txt files for now 
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName; // Using users file exploere to save files 
                string jsonString = JsonSerializer.Serialize(vehicles, new JsonSerializerOptions { WriteIndented = true}); // Serializing the list of vehicles to json format
                using (StreamWriter writer = new StreamWriter(path))
        
                //Confirmation Message
                MessageBox.Show("File has been saved: " + path);
            }
        }

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

            return new List<Vehicle>();

        }


        public void Copy()
    {
            MessageBox.Show("File has been copied");

    }

    public void Paste()
        {
            MessageBox.Show("pasted from clip board");
        }

}
}
