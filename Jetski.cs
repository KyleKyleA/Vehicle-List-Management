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
            get { return MaxSpeed; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Max Speed cannot be negative.");
                }
                MaxSpeed = value;  } //Getting the max speed in Km/h since we are canadian
        }

        // Returns the description of the JetSki
        public override string GetDescription()
        {
            return $"The Jetski was made in {Year} and the {Model} along with the Jetski's {Make} {(IsNew ? "New " : "Used")} and the (${Price:F2}) further the Max Speed is : {MaxSpeed} km/h"; ;
        }

        // Added a feature that is incompared to the other vehicles in this case
        public void JumpForce()
        {
            Console.WriteLine($"{Make} {Model} jumps over a wave with at speeds of {MaxSpeed} km/h!");
        }



    }
}
