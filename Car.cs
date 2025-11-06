using ClassExercise4Inheritance;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

// AUTHOR: Kyle Angeles
// CREATED: October 8, 2025
// UPDATED: October 30, 2025
// DESCRIPTION: This is the Car class for the CarViewer WPF application.
// DESCRIPTION: This class defines the properties and constructor for Car objects for the list of cars in the MainWindow.xaml.cs file.
// Car.Cs file "Class File"
// This inherits from the Vehicle Class



namespace ClassExercise4Inheritance
{
    public class Car : Vehicle
    {

        /// <summary>
        /// Parameterized updated car constructor
        /// since we are using the Objected Oriented Programming
        /// Concepted of Inheritances and abstract 
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="isNew"></param>
        public Car(string make, string model, int year, decimal price, bool isNew)
            : base(make, model, year, price, isNew)
        {
        }


        public void UpdateCar(string make, string model, int year, decimal price, bool isNew)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.IsNew = isNew;
        }

        ///<summary>
        /// What this function does it overrid the string method to display the car details 
        ///</summary>
        /// <returns> "The Car details "</returns>
        public override string GetDescription()
        {
            return $"The car was made in the {Year}. And the car {Model} and the creator of the car is {Make} {(IsNew ? "New " : "Used")} and the total (${Price})";


        }

        // This just helps the datagrid display nicely and all
        // Using the override string method
        public override string ToString()
        {
            return GetDescription();
        }
    }
}

