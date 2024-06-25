using System;
using PhoneBookApp.Models;
using PhoneBookApp.Services;

namespace PhoneBookApp;

internal class Program
{
    private static void Main()
    {   
        var phoneBookService = new PhoneBookService();

        while (true)
        {
            Console.WriteLine("Welcome to contact app");
            Console.WriteLine("Press 1 to add new Contact");
            Console.WriteLine("Press 2 to edit Contact");
            Console.WriteLine("Press 3 to remove Contact");
            Console.WriteLine("Press 4 to view all Contacts");
            Console.WriteLine("Press 5 to exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch(choice)

            {
                case "1":
                    AddPhoneBook(phoneBookService); 
                    break;
                case "2":
                    EditPhoneBook(phoneBookService);
                    break;
                case "3":
                    RemovePhoneBook(phoneBookService);
                    break;
                case "4":
                    ViewAllPhoneBook(phoneBookService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("invalid option , please try again");
                    break;

            }
        }
       
    }

    private static void AddPhoneBook (PhoneBookService phoneBookService)
    {
        Console.WriteLine("Enter name: ");
        var Name = Console.ReadLine();
        Console.Write("Enter phone name: ");
        var PhoneNumber = Console.ReadLine();

        phoneBookService.AddPhoneBook(Name, PhoneNumber);
    }

    private static void EditPhoneBook (PhoneBookService phoneBookService)
    {
        Console.Write("Enter the id of contact to edit: ");

        if(int.TryParse(Console.ReadLine(), out int id))
        {
            var phoneBook = new PhoneBook { id = id };

            Console.Write("Enter new name (leave blank to keep current): ");
            var newName = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                phoneBook.Name = newName;
            }

            Console.Write("Enter new phone number (leave blank to keep current): ");
            var newPhoneNumber = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                phoneBook.PhoneNumber = newPhoneNumber;
            }

            phoneBookService.EditPhoneBook(phoneBook);

        }else
        {
            Console.WriteLine("Invalid Id.");
        }
    }

    private static void RemovePhoneBook (PhoneBookService phoneBookService)
    {
        Console.Write("Enter the Id of the contact to remove: ");

        if(int.TryParse(Console.ReadLine(),out int id))
        {
            phoneBookService.RemovePhoneBook(id);
        }
        else
        {
            Console.WriteLine("Invalid Id.");
        }
    }

    private static void ViewAllPhoneBook (PhoneBookService phoneBookService)
    {
        phoneBookService.ViewAllPhoneBook();
    }
}
