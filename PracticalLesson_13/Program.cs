using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using PracticalLesson_13;

namespace PracticalLesson_13
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //List<Fruit> fruits = new List<Fruit>
                //{
                //new Fruit("Strawberry", "Red"),
                //new Fruit("Banana", "Yellow"),
                //new Fruit("Apple", "Yellow"),
                //new Fruit("Blueberry", "Blue"),
                //new Fruit("Kiwi", "Brown"),
                //new Citrus("Lemon", "Yellow", 30),
                //new Citrus("Grapefruit", "Red", 20),
                //new Citrus("Orange", "Orange", 40),
                //new Citrus("Mandarin", "Orange", 35),
                //new Citrus("Lime", "Green", 25)
                //};

                List<Fruit> fruits = new List<Fruit>();

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"1 - Input fruit.\n2 - Input citrus.\n3 - Exit");
                    Console.Write("Choose operation: ");

                    int key = int.Parse(Console.ReadLine());

                    switch (key)
                    {
                        case 1:
                            Fruit fruit = new Fruit();
                            fruit.Input();
                            fruits.Add(fruit);
                            break;
                        case 2:
                            Citrus citrus = new Citrus();
                            citrus.Input();
                            fruits.Add(citrus);
                            break;
                        case 3:
                            i = 5;
                            break;
                        default:
                            Console.WriteLine("Wrong input!!!");
                            break;
                    }
                }
                Console.Clear();
                foreach (var fruit in fruits)
                {
                    fruit.Print();
                }
                Console.WriteLine("-------------------------------------------------");
                foreach (var fruit in fruits)
                {
                    if (fruit.Color.ToLower() == "yellow")
                    {
                        fruit.Print();
                    }
                }

                var sortedFruits = fruits.OrderBy(f => f.Name).ToList();
                try
                {

                    using (StreamWriter writer = new StreamWriter("sortedFruits.txt"))
                    {
                        foreach (var fruit in sortedFruits)
                        {
                            writer.WriteLine(fruit.ToString());
                        }
                    }
                }
                catch (IOException fileEx)
                {
                    Console.WriteLine("Error with writing data in file: " + fileEx.Message);
                }
                Console.WriteLine("-------------------------------------------------");

                try
                {
                    DataContractJsonSerializer fruitsSerializer = new DataContractJsonSerializer(typeof(List<Fruit>));

                    using (FileStream jsonSerializer = File.OpenWrite("fruits.json"))
                    {
                        fruitsSerializer.WriteObject(jsonSerializer, fruits);
                    }

                }
                catch (SerializationException serEx)
                {
                    Console.WriteLine("Exeption with serialization: " + serEx.Message);
                }

                try
                {
                    using (FileStream jsonDeserializer = File.OpenRead("fruits.json"))
                    {
                        DataContractJsonSerializer fruitsSerializer = new DataContractJsonSerializer(typeof(List<Fruit>));

                        var deserializedFruits = (List<Fruit>)fruitsSerializer.ReadObject(jsonDeserializer);

                        Console.WriteLine("Deserialized from Json:\n");
                        foreach (var fruit in deserializedFruits)
                        {
                            fruit.Print();
                        }
                    }

                }
                catch (SerializationException serEx)
                {
                    Console.WriteLine("Exeption with deserialization: " + serEx.Message);
                }
                catch (FileNotFoundException fileNotFoundEx)
                {
                    Console.WriteLine("File not found: " + fileNotFoundEx.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

        }
    }
}
