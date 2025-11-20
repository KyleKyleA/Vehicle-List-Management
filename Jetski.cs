using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Kyle Angeles
// Date: Oct 30 2025
// Description: Child Class of my choice 
// Description: Decided to do a JetSki Class
namespace ClassExercise4Inheritance
{
    public class Jetski : Vehicle
    {
        //Private Variables 
        // Using Random function to generate a randomize max speed
        private static Random rand = new Random();
        private int maxSpeed;

        /// <summary>
        /// Parameterized Constructor 
        /// for the selected vehicle in this case 
        /// Im doing a jetski
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="isNew"></param>
        /// <param name="maxSpeed"></param>
        public Jetski(string make, string model, int year, decimal price, bool isNew, int maxSpeed) : base (make, model,year, price, isNew)
        {
            MaxSpeed = rand.Next(40, 130); // Random max speed between 40 and 130 Km/h

        }

        /// <summary>
        /// One Public property for now
        /// </summary>
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Max Speed cannot be negative.");
                }
                maxSpeed = value;  
            } //Getting the max speed in Km/h since we are canadian
        }

        /// <summary>
        /// Overrides the VehicleType property to return "Jetski"
        /// </summary>
        public override string VehicleType
        {
            get { return "Jetski"; }
        }
        /// <summary>
        /// Returns the description of the JetSki
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return $"Jetski {Model} ({Year}) by {Make} — Max Speed: {MaxSpeed} km/h, {(IsNew ? "New" : "Used")}, ${Price:F2}";
        }
        
        /// <summary>
        /// Overrides the ToString method
        /// to return the description of the JetSki
        ///  When the user inputs the object 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetDescription();
        }



    }
}
