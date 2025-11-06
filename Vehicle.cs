using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Kyle Angeles
// Date: 10/29/25
// Description: Abstract Vehicle Class from the Car.cs and other vehicle types to inherit from
namespace ClassExercise4Inheritance
{
    public abstract class Vehicle
    {
        // p Variables
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
        /// Parameterized constructor
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="isNew"></param>
        /// <param name="vehicleID"></param>
        public Vehicle(string make, string model, int year, decimal price, bool isNew, int vehicleID)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.isNew = IsNew;
            
            // Increment and count the vehicleID
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
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.isNew = isNew;
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
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
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
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set {  price = value; }
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
        public int VehicleID { 
            
           get { return vehicleID; } 
        }

        // Abstract
        public abstract string GetDescription();

    }
}
