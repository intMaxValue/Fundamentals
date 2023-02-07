using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string brand = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                Car car = new Car(mileage, fuel);
                cars[brand] = car;
                
            }

            string commands;
            while ((commands = Console.ReadLine()) != "Stop")
            {
                string[] cmnd = commands.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmnd[0];
                string currCar = cmnd[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(cmnd[2]);
                    int fuel = int.Parse(cmnd[3]);

                    if (cars[currCar].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[currCar].Fuel -= fuel;
                        cars[currCar].Mileage += distance;
                        Console.WriteLine($"{currCar} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (cars[currCar].Mileage >= 100_000)
                    {
                        cars.Remove(currCar);
                        Console.WriteLine($"Time to sell the {currCar}!");
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(cmnd[2]);
                    cars[currCar].Fuel += fuel;
                    if (cars[currCar].Fuel > 75)
                    {
                        Console.WriteLine($"{currCar} refueled with {fuel + 75 - cars[currCar].Fuel} liters");
                        cars[currCar].Fuel = 75;
                    }
                    else
                    {
                        Console.WriteLine($"{currCar} refueled with {fuel} liters");
                        
                    }

                }
                else if (action == "Revert")
                {
                    int km = int.Parse(cmnd[2]);
                    cars[currCar].Mileage -= km;

                    if (cars[currCar].Mileage < 10_000)
                    {
                        cars[currCar].Mileage = 10_000;
                    }
                    else
                    {
                        Console.WriteLine($"{currCar} mileage decreased by {km} kilometers");
                    }
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    public class Car
    {
        public Car(int mileage, int fuel)
        {
            
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

    }
}
