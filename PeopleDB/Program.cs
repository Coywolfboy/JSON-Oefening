using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PeopleDB
{
    class Program
    {
        static Group group = new Group();
        static string filePath = "../../../database.json";

        static void Main()
        {
            // try to load data
            LoadFromDisk();

            // Menu setup
            Menu menu = new Menu();
            menu.AddOption('1', "Set Group Name", SetGroupName);
            menu.AddOption('2', "Add Person", AddPerson);
            menu.AddOption('3', "Show Members", ShowMembers);

            menu.Start();

            // menu had ended. Save everything
            SaveToDisk();
        }

        // TODO in SetGroupName()
        static void SetGroupName()
        {
            Console.WriteLine("Enter the group name: ");
            group.Name = Console.ReadLine();
        }

        // TODO in AddPerson()
        static void AddPerson()
        {
            Person person = new Person();

            Console.WriteLine("Enter person's name: ");
            person.Name = Console.ReadLine();

            Console.WriteLine("Enter person's age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                person.Age = age;
            }

            Console.WriteLine("Enter person's hobbies (comma-separated): ");
            person.Hobbys = Console.ReadLine().Split(',').Select(h => h.Trim()).ToList();

            group.People.Add(person);
        }

        // TODO in ShowMembers()
        static void ShowMembers()
        {
            Console.WriteLine($"Group: {group.Name}");
            foreach (var person in group.People)
            {
                Console.WriteLine(person);
                Console.ReadLine();

            }
        }

        // TODO in SaveToDisk()
        static void SaveToDisk()
        {
            try
            {
                File.WriteAllText(filePath, group.Serialize());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to disk: {ex.Message}");
            }
        }

        // TODO in LoadFromDisk()
        static void LoadFromDisk()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    group = Group.Deserialize(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from disk: {ex.Message}");
            }
        }
    }
}
