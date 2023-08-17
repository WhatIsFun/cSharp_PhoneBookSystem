using cSharp_SimpleNoteApplication;

namespace cSharp_PhonebookApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("      Welcome To    ");
            Console.WriteLine(" +-+-+-+-+-+-+-+-+-+\r\n |W|h|a|t|I|s|F|u|n|\r\n +-+-+-+-+-+-+-+-+-+");
            Console.WriteLine(" Phonebook Application      \n");
            Console.ResetColor();
            Menu menu = new Menu();
            Contacts contacts = new Contacts();
            contacts.LoadContacts();
            menu.DisplayMenu();

        }
    }
}