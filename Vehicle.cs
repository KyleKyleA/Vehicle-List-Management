using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Kyle Angeles
// Date: 10/29/25
// Modified: 11/15/25
// Description: Abstract Vehicle Class from the Car.cs and other vehicle types to inherit from
namespace ClassExercise4Inheritance
{
    public abstract class Vehicle
    {
        // protected Variables
        protected string make;
        protected string model;
        protected int year;
        protected decimal price;
        protected Boolean isNew;
        protected static int vehicleCount = 0;
        protected int vehicleID;
      



        // Default Constructor 
        // for the Vehicle Class
        public Vehicle() {

            vehicleCount++;
            vehicleID = vehicleCount;

        }


        /// <summary>
        /// Parameterized constructor for the updating Vehicle
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="isNew"></param>
        protected Vehicle(string make, string model, int year, decimal price, bool isNew)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Price = price;
            this.IsNew = isNew;
            

            // Increment and count the vehicleID
            vehicleCount++;
            this.vehicleID = vehicleCount;
        }





        // Static Property which is the Vehicle Count 
        // Counts for all general vehicles
        public static int Count
        {
            get { return vehicleCount; }
        }
        
        // Public property for the Car Make
        public string Make
        {
            get { return make; }
            set { make = value; }
        }



        /// <summary>
        /// Gets the different types of models from the vehicle 
        /// Now we throwed in an exception if the model has either a white space or empty field
        /// it would throw it an argument exception
        /// Model Property we are using AgumentNullException
        /// </summary>
        public string Model
        {
            get { return model; }
            set { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be empty.");
                }
                model = value; }
        }
       

        /// <summary>
        /// Gets or sets the year value
        /// </summary>
        public int Year
        {
            get { return year; }
            set { year = value; }
        }




        /// <summary>
        /// If the user types in a price in value or the excated amount
        /// Added an exception handling if the price is negative it would throw an argument out of range exception
        /// using the Price Property that gets or sets the price value
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                price = value; }
        }
        

        /// <summary>
        /// Determines if the car is new or used by setting true to be new and false to be used
        /// </summary>
        public bool IsNew
        {
            get { return isNew;  }
            set {isNew = value;}
        }


        /// <summary>
        /// This gets the Vehicle ID to be displayed onto the data grid
        /// </summary>
        public int CarID { 
            
           get { return vehicleID; } 
        }

        /// <summary>
        /// Property for the vehicle type
        /// </summary>
        /// <returns></returns>
        public abstract string VehicleType
        {
            get;
        }


        // Abstract
        public abstract string GetDescription();

    }
}
