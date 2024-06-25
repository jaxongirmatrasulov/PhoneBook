using System.Numerics;
using System.Xml.Linq;
using PhoneBookApp.Models;

namespace PhoneBookApp.Services;

public class PhoneBookServices
{
    private List<PhoneBook> phoneBooks = [];
    private int phoneBookId = 1;

    public void AddPhoneBook(string name, string phoneNumber)
    {
        var newPhoneBook = new PhoneBook
        {
            id = phoneBookId++,
            Name = name,
            PhoneNumber = phoneNumber

        };
        phoneBooks.Add(newPhoneBook);
        Console.WriteLine("Contact added succesfuly");
    }

    public void EditPhoneBook(PhoneBook updatePhoneBook)
    {
        var phoneBook = phoneBooks.FirstOrDefault(c => c.id == updatePhoneBook.id);

        if (phoneBook != null)
        {
            phoneBook.Name = updatePhoneBook.Name;
            phoneBook.PhoneNumber = updatePhoneBook.PhoneNumber;
            Console.WriteLine("Contact update succesfuly");

        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }

    public void RemovePhoneBook(int id)
    {
        var phoneBook = phoneBooks.FirstOrDefault(c => c.id == id);

        if (phoneBook != null)
        {
            phoneBooks.Remove(phoneBook);
            Console.WriteLine("Contact remove succesfuly");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }

    public void ViewAllContacts()
    {
        if (phoneBooks.Count == 0)
        {
            Console.WriteLine("No contacts available");
        }
        else
        {
            Console.WriteLine("Contacts:");

            foreach (var phoneBook in phoneBooks)
            {
                Console.WriteLine($"id: {phoneBook.id}, Name: {phoneBook.Name}, PhoneNumvber: {phoneBook.PhoneNumber}");

            }
        }
    }
}
