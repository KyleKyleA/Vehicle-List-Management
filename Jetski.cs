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
            MaxSpeed = maxSpeed;

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

        // Overrides the VehicleType property to return "Jetski"
        public override string VehicleType
        {
            get { return "Jetski"; }
        }
        // Returns the description of the JetSki
        public override string GetDescription()
        {
            return $"Jetski {Model} ({Year}) by {Make} — {JumpForce} jump force, {MaxSpeed} km/h, {(IsNew ? "New" : "Used")}, ${Price:F2}";
        }

        // Added a feature that is incompared to the other vehicles in this case
        public void JumpForce()
        {
            Console.WriteLine($"{Make} {Model} jumps over a wave with at speeds of {MaxSpeed} km/h!");
        }



    }
}
