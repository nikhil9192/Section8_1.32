using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section8_1._32
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            LoadDataFromFile("C:\\Users\\NIKHIL SINGH\\source\\repos\\Section8_1.32\\Section8_1.32\\bin\\Debug\\Student.txt");

            while (true)
            {
                Console.WriteLine("1. Display Students");
                Console.WriteLine("2. Search by Name");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayStudents();
                            break;
                        case 2:
                            SearchByName();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static void LoadDataFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        students.Add(new Student
                        {
                            Name = parts[0].Trim(),
                            Class = parts[1].Trim()
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine("Data file not found.");
            }
        }

        static void DisplayStudents()
        {
            Console.WriteLine("Students:");
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }
        }

        static void SearchByName()
        {
            Console.Write("Enter a name to search: ");
            string searchName = Console.ReadLine();
            var results = students.Where(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var student in results)
                {
                    Console.WriteLine($"{student.Name}, {student.Class}");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
