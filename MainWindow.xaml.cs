using ClassExercise4Inheritance;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// AUTHOR: Kyle Angeles
// DATE: 10/12/2025
// DESCRIPTION: Creating a wpf application that manages a list of cars using collections or arrays
// DESCRIPTION: Using concepts of Object-Oriented Programming (OOP) such as classes and objects.
// Version: 1.0

//Main Class to run the program

namespace CarListManagement
{
    ///<summary>
    /// Interaction logic for MainWindow.xaml
    ///</summary>
    public partial class MainWindow : Window
    {
        // Using a List to store car objects
        List<Car> listOfCars = new List<Car>();
        int currentIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the program runs everything should of loaded within the window
        /// with the populated data on the combo box
        /// which should consist of the year which I've implemented in a loop
        /// and an array for the different car makes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Setting up the ComboBox with car makes
            // Setting car objects to the array
            // Using an array for the drop down menu
            // This showcases an array of listed car brands

            // Updating the status bar to indicate the application has loaded
            UpdateStatusBar("Application Loaded");
            string[] carMakes =
            {
                "Scion",
                "Dodge",
                "VolksWagen",
                "Lamborghini",
                "Subaru",
                "Nissan",
                "Toyota",
                "Mercedes-Benz",
                "Audi",
                "Aston Martin",
                "Porsche",
                "Mitsubishi",

            };

            // Setting the ComboBox's item source to the list of car makes
            MakeCar.ItemsSource = carMakes;
            MakeCar.SelectedIndex = 0;  // Default to the first item (E.G Scion)


            // Setting up the ComboBox with car years
            // Using a for loop to generate amount of years 
            List<int> carYears = new List<int>();
            int currentYear = DateTime.Now.Year;
            for (int i = 0; i < 50; i++)
            {
                carYears.Add(currentYear - i);
            }

            // Setting the ComboBox's item source to the list of car makes
            CarYear.ItemsSource = carYears;
            CarYear.SelectedIndex = 0; // Default to the first item (E.G 2020 which is the scion)

        }

        // Exit button event handler
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(" You are now exiting the application. Goodbye!");
            this.Close();
        }

         ///<summary>
        /// This function is used to reset the form to its default state.
        /// meaning that it clears every single field within the window. 
        ///</summary>
        private void ResetForm()
        {
            MakeCar.SelectedIndex = -1;
            ModelName.Clear();
            CarYear.SelectedIndex = -1;
            PriceCar.Clear();
            NewOrUsed.IsChecked = false;
            
            currentIndex = -1;
            dgCarInventory.SelectedIndex = -1; // Deselect any selected item in the datagrid
            ResultBox.Text = string.Empty;

            
            

        }

        // Reset button event handler
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        ///<summary>
        /// This Function is used to enter the values from the textboxes and dropdowns
        /// to the datagrid when the Enter button is clicked.
        ///</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            // This validates the user inputs before proceeding
            // If validation fails, the function returns early
            // This prevents any further processing with invalid data
            // Using the ValidateInputs function to check for valid inputs
            if (!ValidateInputs())
            {
                return;
            }


            // Gather data from input controls (make, model, price, and isnew)
            try
            {
                string make = MakeCar.SelectedItem.ToString();
                string model = ModelName.Text.Trim();
                int year = (int)CarYear.SelectedItem;
                decimal price = decimal.Parse(PriceCar.Text.Trim());
                bool isNew = NewOrUsed.IsChecked == true;

                // Check if this is a new entry or existing entry
                if (currentIndex == -1)
                {


                    // entering a new car entry - Create and add it
                    Car newCar = new Car(make, model, year, price, isNew);

                    listOfCars.Add(newCar);

                    // Display confirmation message using the car's ToString() method
                    MessageBox.Show($"Car added: {newCar}", "Success");
                    ResultBox.Text = "It Worked";
                }
                else
                {


                    Car existingCar = listOfCars[currentIndex];
                    // Combined the existing cars to actually you can update them based of the 
                    existingCar.UpdateCar(make, model, year, price, isNew);

                    MessageBox.Show($"Car modified: {existingCar}", "Success");

                    UpdateStatusBar("Car details updated.");



                }

                // Clears the datagrid
                dgCarInventory.Items.Clear();

                // Repopulate the datagrid
                foreach (Car car in listOfCars)
                {
                    dgCarInventory.Items.Add(car);
                }

                // Clear all input fields and reset the form
                ResetForm();
            }
            // Catching the ArgumentNullException for the model property in Vehicle.cs
            catch (ArgumentNullException ex)
            {
                UpdateStatusBar("Error: Car model cannot be empty.");
                ModelName.Focus();

            }
            // Catching for the price proepry from the vehicle.cs file onto the mainwindow.xaml.cs file
            catch (ArgumentOutOfRangeException ex)
            {
                PriceCar.Focus();
            }
            catch (Exception ex)
            {
                
            }
        }

        ///<summary>
        /// This function validates the user inputs in the form.
        /// Gives an error message if any input is invalid.
        /// validates whether the user input has any sort of white space or is empty
        /// manual validation for each input in the program 
        /// </summary>
        private bool ValidateInputs()
                    {
                        string errorMessage = "";

                        if (MakeCar.SelectedIndex == -1)
                        {
                            errorMessage += "Please select a car make.\n";
                        }


                        if (string.IsNullOrWhiteSpace(ModelName.Text))
                        {
                            errorMessage += "Car Model cannot be blank. "; // Model name is empty or whitespace return false
                        }

                        if (CarYear.SelectedIndex == -1)
                        {
                            errorMessage += "Please select a car year.\n";
                        }

                        if (string.IsNullOrEmpty(PriceCar.Text))
                        {
                            errorMessage += "Price cannot be blank.\n";
                        }
                        else if (string.IsNullOrWhiteSpace(PriceCar.Text) || !decimal.TryParse(PriceCar.Text, out decimal price) || price < 0)
                        {
                            errorMessage += "Please enter a valid number\n";
                        }
                       

                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            MessageBox.Show(errorMessage, "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false; // If all the inputs are invalid 
                        }

                        return true; // All inputs are valid

                    }

        //<summary>
        /// This populates the data grid with some values in the list
        /// Which is displayed when the windows is loaded 
        ///<param name="sender"></param>
        ///<param name="e"></param>
        ///</summary>
        private void dgCarInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCarInventory.SelectedIndex != -1)
            {
                currentIndex = dgCarInventory.SelectedIndex;
                Car selectedCar = (Car)dgCarInventory.SelectedItem;
                MakeCar.Text = selectedCar.Make;
                ModelName.Text = selectedCar.Model;
                CarYear.Text = selectedCar.Year.ToString();
                PriceCar.Text = selectedCar.Price.ToString("F2");
                NewOrUsed.IsChecked = selectedCar.IsNew;
                



            }

            
        }

        ///<summary>
        /// This function just checks whether the car model is new or used. If new, it adds it to the new list
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        private void NewOrUsed_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox != null && checkBox.IsChecked == true)
            {
                List<Car> newCars = listOfCars.Where(car => car.IsNew).ToList();
            }
        }

        private void UpdateStatusBar(string message)
        {
            string timestamp = DateTime.Now.ToString("hh:mm tt");
            StatusTextBlock.Text = $"{timestamp} - {message}";
        }
    }
}
