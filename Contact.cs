using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace cSharp_PhonebookApplication
{
    public class Contacts
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public static List<Contacts> contacts = new List<Contacts>();
        private static string PhoneBookDirectory = "Phone Book";
        private static string ContactsFile = "Phone Book/Contacts.xml";
        public void AddContact()
        {
            Console.WriteLine("Please enter a contact name:");
            string ContactName = Console.ReadLine();
            Console.WriteLine("Please enter a contact phone number:");
            string phoneNum = Console.ReadLine();
            contacts.Add(new Contacts { Name = ContactName, PhoneNumber = phoneNum });
            SaveContacts();
        }
        public void SaveContacts()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contacts>));
                using (TextWriter NewContact = new StreamWriter(ContactsFile))
                {
                    serializer.Serialize(NewContact, contacts);
                    Console.WriteLine("Contact saved successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving the new contact: {ex.Message}");
            }
        }
        public void LoadContacts()
        {
            // Create Folder if it doesn't exist
            Directory.CreateDirectory(PhoneBookDirectory);
            try
            {
                if (File.Exists(ContactsFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Contacts>));
                    using (FileStream stream = File.OpenRead(ContactsFile))
                    {
                        contacts = (List<Contacts>)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    SaveContacts(); //Create xml file if it doesn't exist
                }
                Console.WriteLine("Contacts loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading contacts: {ex.Message}");
            }
        }
        static Contacts FindNoteByTitle(string searchName)
        {
            return contacts.Find(contact => contact.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }
        public void EditContact()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.Write("Enter the contact name to edit: ");
            string searchName = Console.ReadLine();
            Contacts contactToEdit = FindNoteByTitle(searchName);
            if (contactToEdit != null)
            {
                Console.Write("Enter new contact name: ");
                contactToEdit.Name = Console.ReadLine();

                Console.Write("Enter new contact phone number: ");
                contactToEdit.PhoneNumber = Console.ReadLine();

                Console.WriteLine("contact edited successfully!");
                SaveContacts();
            }
            else
            {
                Console.WriteLine("No contact with the specified name found.");
            }
        }
        public void SearchContact()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.Write("Enter the contact name to search: ");
            string searchName = Console.ReadLine();

            Contacts contactToSearch = FindNoteByTitle(searchName);
            if (contactToSearch != null)
            {
                Console.WriteLine($"Contact name: {contactToSearch.Name}");
                Console.WriteLine($"Contact Phone Number: {contactToSearch.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("No contact with the specified name found.");
            }
        }
        public void DeleteContact()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.Write("Enter the contact name to delete: ");
            string searchName = Console.ReadLine();

            Contacts contactToDelete = FindNoteByTitle(searchName);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);

                Console.WriteLine("Contact deleted successfully!");
                SaveContacts();
            }
            else
            {
                Console.WriteLine("No contact with the specified title found.");
            }
        }
        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.WriteLine("Contacts:");
            Console.WriteLine("--------------------------------------------------------------");

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Contact {i + 1}");
                Console.ResetColor();

                Console.WriteLine($"Contact Name: {contacts[i].Name}, Phone Number: {contacts[i].PhoneNumber}");
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
    }
}
