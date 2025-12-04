using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
// Two libaries for file reading 
using System.IO;
using Microsoft.Win32;
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
        public void saveFile(string content)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt | All Files (*.*) | *.*",
                DefaultExt = ".txt" // Files default saved will be in txt files for now 
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName; // Using users file exploere to save files 
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(content);
                }

                //Confirmation Message
                MessageBox.Show("file has been saved: " + path);
            }
        }

        public string openFile(string content)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt | All Files (*.*) | *.*",
            };

            if (openFileDialog.ShowDialog() == true) {
                string path = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
        }
            return string.Empty;
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
