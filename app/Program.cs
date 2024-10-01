using System;
using System.Collections.Generic;

// Интерфейс для записи
interface IRecord
{
    void SendMessage();
    DateTime CreationTime { get; }
}

// Класс для сообщения
class Message : IRecord
{
    public string Text { get; }
    public DateTime CreationTime { get; }

    public Message(string text)
    {
        Text = text;
        CreationTime = DateTime.Now;
    }

    public void SendMessage()
    {
        Console.WriteLine($"[{CreationTime}] [Message] {Text}");
    }
}

// Класс для человека
class Person : IRecord
{
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public DateTime CreationTime { get; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        CreationTime = DateTime.Now;
    }

    public void SendMessage()
    {
        Console.WriteLine($"[{CreationTime}] [Person] {FirstName} {LastName}, {Age}");
    }
}

// Класс для автомобиля
class Car : IRecord
{
    public string Model { get; }
    public int Year { get; }
    public DateTime CreationTime { get; }

    public Car(string model, int year)
    {
        Model = model;
        Year = year;
        CreationTime = DateTime.Now;
    }

    public void SendMessage()
    {
        Console.WriteLine($"[{CreationTime}] [Car] {Model}, {Year}");
    }
}

// Класс для управления записями
class CRUD
{
    private List<IRecord> records = new List<IRecord>();

    // Метод для добавления записи
    public void AddRecord(IRecord record)
    {
        records.Add(record);
    }

    // Метод для удаления записи по индексу
    public void RemoveRecord(int index)
    {
        if (index >= 0 && index < records.Count)
        {
            records.RemoveAt(index);
            Console.WriteLine("Запись удалена.");
        }
        else
        {
            Console.WriteLine("Некорректный номер записи.");
        }
    }

    // Метод для вывода всех записей
    public void PrintRecords()
    {
        if (records.Count == 0)
        {
            Console.WriteLine("Записей нет.");
        }
        else
        {
            for (int i = 0; i < records.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                records[i].SendMessage();
            }
        }
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        CRUD crud = new CRUD();
        string choice;

        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Print data");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("Q. Exit");
            Console.Write("Выберите действие: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    crud.PrintRecords();
                    break;
                case "2":
                    AddRecordMenu(crud);
                    break;
                case "3":
                    RemoveRecordMenu(crud);
                    break;
            }
        } while (choice.ToUpper() != "Q");
    }

    // Метод для добавления записи через меню
    static void AddRecordMenu(CRUD crud)
    {
        Console.WriteLine("Какой тип записи добавить?");
        Console.WriteLine("1. Message");
        Console.WriteLine("2. Person");
        Console.WriteLine("3. Car");
        Console.Write("Выберите тип: ");
        string type = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Введите сообщение: ");
                string message = Console.ReadLine();
                crud.AddRecord(new Message(message));
                break;
            case "2":
                Console.Write("Введите имя: ");
                string firstName = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                string lastName = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age = int.Parse(Console.ReadLine());
                crud.AddRecord(new Person(firstName, lastName, age));
                break;
            case "3":
                Console.Write("Введите модель автомобиля: ");
                string model = Console.ReadLine();
                Console.Write("Введите год выпуска: ");
                int year = int.Parse(Console.ReadLine());
                crud.AddRecord(new Car(model, year));
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }
    }

    // Метод для удаления записи через меню
    static void RemoveRecordMenu(CRUD crud)
    {
        Console.Write("Введите номер записи для удаления: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        crud.RemoveRecord(index);
    }
}
