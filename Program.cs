I﻿PersonService personService = new PersonService();

while (true)
{
    Console.WriteLine("Enter command (add / get / exit): ");
    string command = Console.ReadLine();

    if (command.ToLower() == "add")
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Person person = new Person { Id = id, Name = name, Age = age };

        string cid = await personService.SavePerson(person);
        Console.WriteLine($"Person added to IPFS with CID: {cid}");
    }
    else if (command.ToLower() == "get")
    {
        Console.Write("Enter CID to retrieve: ");
        string cid = Console.ReadLine();

        try
        {
            var person = await personService.GetPerson(cid);
            Console.WriteLine($"Person retrieved: ID = {person.Id}, Name = {person.Name}, Age = {person.Age}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving person: {ex.Message}");
        }
    }
    else if (command.ToLower() == "exit")
    {
        Console.WriteLine("Exiting...");
        break; 
    }
    else
    {
        Console.WriteLine("Unknown command. Try 'add', 'get', or 'exit'.");
    }
}
