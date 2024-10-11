using System;
using System.Collections.Generic;

namespace TravelAgency
{
    internal class Program

    {
        static List<Itinerary> itineraries = new List<Itinerary>();

        private static void Main(string[] args)

        {
            Console.WriteLine("\nWelcome to Algonquin College Student Travel Agency!");


            while (true)

            {
                Console.WriteLine();

                Console.WriteLine("Travel Agency Menu");

                Console.WriteLine("1. View all itineraries");

                Console.WriteLine("2. Add a new itinerary");

                Console.WriteLine("3. Change an existing itinerary");

                Console.WriteLine("4. Exit");

                Console.Write("\nEnter a choice: ");

                string? choice = Console.ReadLine();


                switch (choice)

                {
                    case "1":
                        ViewItineraries();
                        break;

                    case "2":
                        AddItinerary();
                        break;

                    case "3":
                        ChangeItinerary();
                        break;

                    case "4":
                        Console.WriteLine("Thank you for using Algonquin College Student Travel Agency!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                        break;

                }

            }

        }

        static string GetResponse(string request)
        {
            string? response = null;

            while (string.IsNullOrWhiteSpace(response))

            {
                Console.Write(request);

                response = Console.ReadLine();

            }

            return response;

        }

        static void ViewItineraries()
        {
            if (itineraries.Count == 0)

            {
                Console.WriteLine("No itinerary exists in the system.");
                return;

            }

            for (int i = 0; i < itineraries.Count; i++)

            {
                var itinerary = itineraries[i];

                Console.WriteLine($"{i}: Passenger: {itinerary.PassengerName}, From: {itinerary.DepartureCity}, To: {itinerary.ArrivalCity}, Cost: {itinerary.Cost}");

            }

        }

        static void AddItinerary()
        {
            string passengerName = GetResponse("Enter passenger's name: ");
            string departureCity = GetResponse("Enter departure city: ");
            string arrivalCity = GetResponse("Enter arrival city: ");

            try

            {
                Itinerary newItinerary = new Itinerary(passengerName, departureCity, arrivalCity);

                itineraries.Add(newItinerary);

                Console.WriteLine($"Itinerary has been added to the system. Cost: {newItinerary.Cost}");

            }

            catch (Exception ex)
            
            {
                Console.WriteLine($"Error: {ex.Message}");

            }

        }

        static void ChangeItinerary()
        {
            if (itineraries.Count == 0)

            {
                Console.WriteLine("No itinerary exists in the system.");
                return;

            }

            ViewItineraries();

            Console.Write($"Enter the index of the itinerary to change (0-{itineraries.Count - 1}): ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < itineraries.Count)

            {
                var itinerary = itineraries[index];
                Console.WriteLine($"Changing itinerary for {itinerary.PassengerName}");
                string newDepartureCity = GetResponse("Enter new departure city: ");
                string newArrivalCity = GetResponse("Enter new arrival city: ");

                try
                {
                    itinerary.ChangeItinerary(newDepartureCity, newArrivalCity);
                    Console.WriteLine($"Itinerary changed. New Cost: {itinerary.Cost} (including change fee of {Itinerary.ChangeFee})");
                }

                catch (Exception ex)

                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }

            else

            {
                Console.WriteLine("Invalid index.");
            }

        }

    }

}
