// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    /// <summary>
    /// This class handles all user input and output. As there only ever needs to be one user interface
    /// instance, the class is static and is passed a droid collection called the standard collection
    /// perhaps other collections could be passed if for example one was read from a file instead
    /// </summary>
    static class UserInterface
    {
        /// <summary>
        /// Checks for the users operating system, to see if the console buffer can be set
        /// prints the welcome message
        /// </summary>
        /// <param name="passedCollection">the collection passed from main</param>
        public static void Initialize(DroidCollection passedCollection) {
            if (OperatingSystem.IsWindows() == true)
            #pragma warning disable CA1416 // Validate platform compatibility
                Console.BufferHeight = (Int16.MaxValue - 1);
            #pragma warning restore CA1416 // Validate platform compatibility

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Droid Inventory Management System®");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            MainMenu(passedCollection);
        }
        /// <summary>
        /// prints the main menu options and checks for user input
        /// </summary>
        /// <param name="StandardCollection">the same collection passed</param>
        private static void MainMenu(DroidCollection StandardCollection)
        {
            uint menuInput = 0;
            bool terminate = false;
            while (terminate == false)           
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please Select an option from the menu below:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Add new droid");
                Console.WriteLine("2. Print droid list");
                Console.WriteLine("3. Exit");
                menuInput = ValidIntInput(1, 3);
                switch (menuInput)
                {
                    case 1:
                        AddNewDroid(StandardCollection);
                        break;
                    case 2:
                        PrintDroidList(StandardCollection);
                        break;
                    case 3:
                        //inverts the valid bool return so the loop ends when terminate equals false (the user selects yes)
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Are you sure? Y/N");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        terminate = !ValidBoolInput();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter one of a valid options above.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
        /// <summary>
        /// Different from the adding methods in other classes, this function
        /// walks the user through the creation of a droid before passing that droid to the 
        /// droid collection addition method
        /// </summary>
        /// <param name="PassedCollection">same collection</param>
        private static void AddNewDroid(DroidCollection PassedCollection)
        {
            string[] typeArray = { "General Utility", "General Protocol", "Janitor", "Astromech" };
            string[] materialArray = { "Aluminum", "Steel", "Tungsten Carbide", "Gold" };
            string[] colorArray = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Protective Coating", "No Color" };

            uint type = 0;
            string material = "";
            string color = "";
            bool toolbox = false;
            bool computer = false;
            bool scanner = false;
            uint numberLanguages = 0;
            bool broom = false;
            bool vacuum = false;
            bool navigation = false;
            uint numberShips = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("What kind of droid would you like to add?");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int x = 0; x < typeArray.Length; ++x)
            {
                Console.WriteLine((x + 1) + ". " + typeArray[x]);
            }
            type = ValidIntInput(1, typeArray.Length);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("From what material is it created?");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int x = 0; x < materialArray.Length; ++x) 
            {
                Console.WriteLine((x+1) + ". " + materialArray[x]);
            }
            material = materialArray[(ValidIntInput(1, materialArray.Length)-1)];

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("What color is it?");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int x = 0; x < colorArray.Length; ++x)
            {
                Console.WriteLine((x+1) + ". " + colorArray[x]);
            }
            color = colorArray[(ValidIntInput(1, colorArray.Length)-1)];

            switch (type)
            {
                case 1:
                    CreateUtility();
                    AddUtility();
                    break;
                case 2:
                    CreateProtocol();
                    AddProtocol();
                    break;
                case 3:
                    CreateJanitor();
                    AddJanitor();
                    break;
                case 4:
                    CreateAstromech();
                    AddAstromech();
                    break;
            }
            
            // This next block was challenging. It feels like I have just constructed
            //manual inheritance and Im curious as to if theres a way to make it more effiecient

            // Prompts for Utility droid menu options
            void CreateUtility()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have a toolbox? Y/N");
                toolbox = ValidBoolInput();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have a computer connection? Y/N");
                computer = ValidBoolInput();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have a scanner? Y/N");
                scanner = ValidBoolInput();
            }
            // Prompts for protocol droid inputs
            void CreateProtocol()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("How many languages would you like the droid to have?");
                numberLanguages = ValidIntInput(0, 99);
            }
            // Prompts for janitor droid inputs
            void CreateJanitor() 
            {
                CreateUtility();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have a broom? Y/N");
                broom = ValidBoolInput();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have a vacuum? Y/N");
                vacuum = ValidBoolInput();
            }
            //prompts for astromech inputs
            void CreateAstromech() 
            {
                CreateUtility();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Does the droid have navigation? Y/N");
                navigation = ValidBoolInput();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("How many ships does the droid have?");
                numberShips = ValidIntInput(0, 99);
            }

            // What I wanted to do here originally was have one method that added a droid to the 
            //collection and the object type changed based on the number of methods that were initialized
            // Im not sure if thats possible but it feels like it should be...
            // It feels like with all the extra methods ive created here, all of the OOP i did 
            // before feels less magical.
            
            // Adds a created utility droid to the collection
            void AddUtility() 
            {
                PassedCollection.AddDroid(new UtilityDroid(material, color, toolbox, computer, scanner));
            }
            // adds a created protocol droid to the collection
            void AddProtocol() 
            {
                PassedCollection.AddDroid(new ProtocolDroid(material, color, numberLanguages));
            }
            // adds a created janitor droid to the collection
            void AddJanitor() 
            {
                PassedCollection.AddDroid(new JanitorDroid(material, color, toolbox, computer, scanner, broom, vacuum));
            }
            // adds a created astromech droid to the collection
            void AddAstromech() 
            {
                PassedCollection.AddDroid(new AstromechDroid(material, color, toolbox, computer, scanner, navigation, numberShips));
            }
        }
        /// <summary>
        /// Prints the output of the droid collections tostring method
        /// </summary>
        /// <param name="collection">passed collection</param>
        public static void PrintDroidList(DroidCollection collection)
        {
            Console.WriteLine(collection.ToString());
        }
        /// <summary>
        /// asks the user for a yes or no answer to an input and verifies the quality of the input
        /// </summary>
        /// <returns>yes or no</returns>
        private static bool ValidBoolInput()
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.Gray;
            input = Console.ReadLine();
            while (true)
            {
                if (input != "N" && input != "n" && input != "Y" && input != "y")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid option.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine();
                }
                else
                    break;
            }
            if (input != "Y" && input != "y")
                return true;
            else
                return false;
        }
        /// <summary>
        /// asks the user for a numberical input and verifies the quality
        /// </summary>
        /// <param name="minValue">minimum valid answer from the user</param>
        /// <param name="maxValue">maximum valid input from the user</param>
        /// <returns>the input value from the user</returns>
        private static uint ValidIntInput(int minValue, int maxValue)
        {
            uint input = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            while (true)
            {
                try
                {
                    input = UInt32.Parse(Console.ReadLine());
                    if (input > maxValue || input < minValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error invalid input. Please try again.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return input;
        }
    }
}
