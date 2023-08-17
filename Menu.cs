using cSharp_PhonebookApplication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace cSharp_SimpleNoteApplication
{
    public class Menu
    {
        Contacts contacts = new Contacts();
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Phone Book Menu: \n1) Add new contect\n2) Edit contect\n3) Search for contect\n4) Delete contect\n5) Display All contects\n6) Exit");
            Console.ResetColor();
            while (true)
            {
                try
                {
                    Console.Write("\nPlease select an option: ");
                    string option = Console.ReadLine();
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    switch (NoOption)
                    {
                        case 1:
                            contacts.AddContact();
                            break;
                        case 2:
                            contacts.EditContact();
                            break;
                        case 3:
                            contacts.SearchContact();
                            break;
                        case 4:
                            contacts.DeleteContact();
                            break;
                        case 5:
                            contacts.DisplayContacts();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Are you sure you want to exit? (y/n) "); // Check if the user want to exit the application
                            string ExitInput = Console.ReadLine();
                            ExitInput.ToLower();
                            Console.ResetColor();
                            if (ExitInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Thank You");
                                Environment.Exit(0);
                            }
                            else
                            {
                                DisplayMenu();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        
    }
}

