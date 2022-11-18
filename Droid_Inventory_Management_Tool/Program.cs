// Noah Braasch
// October 14 2022

using System;

namespace Droid_Inventory_Management_Tool
{
    class Program
    {
        /// <summary>
        /// At this point main remains mostly emply as all of the user interaction occurs in the user interface class. 
        /// perhaps in the future this code could be expanded necessitating more code in main or another class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            DroidCollection StandardCollection = new DroidCollection();

            UserInterface.Initialize(StandardCollection);

        }
    }
}
