﻿using System;
using System.Collections.Generic;
namespace AirlineReservationConsoleSystem_CSharp
{

    internal class Program
    {
        // Global variables and data storage
        private static int MAX_FLIGHTS = 2; // Maximum number of flights the system can handle
        private static int MAX_BOOKINGS = 2; // Maximum number of bookings the system can handle

        // Arrays to store flight-related information
        private static string[] flightCodes = new string[MAX_FLIGHTS];
        private static string[] fromCity = new string[MAX_FLIGHTS];
        private static string[] toCity = new string[MAX_FLIGHTS];
        private static DateTime[] departureTimes = new DateTime[MAX_FLIGHTS];
        private static int[] durations = new int[MAX_FLIGHTS];
        private static double[] prices = new double[MAX_FLIGHTS];

        // Arrays to store booking-related information
        private static string[] passengerNames = new string[MAX_BOOKINGS];
        private static string[] bookingIDs = new string[MAX_BOOKINGS];
        private static double[] totalPrices = new double[MAX_BOOKINGS];

        // Discount codes and their corresponding discount values
        private static string[] discountCodes = { "SAVE10", "SAVE20", "SAVE15" };
        private static double[] discountValues = { 0.10, 0.20, 0.15 };

        // Counters to track the number of flights and bookings
        private static int flightCount = 0;
        private static int bookingCount = 0;

        // Entry point of the application
        static void Main(string[] args)
        {
            StartSystem();
        }


        /* ====================== Startup & Navigation Functions ====================== */
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║      WELCOME TO AIRLINE RESERVATION SYSTEM           ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ Please select an option:                             ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ 1. Start Application                                 ║");
            Console.WriteLine("║ 2. Exit Application                                  ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.Write("Enter your choice: ");

            int choice;
            bool on = true;

            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        on = false;
                        ShowMainMenu();
                        break;
                    case 2:
                        ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            } while (on);



        }

        // Displays the main menu and handles user navigation

        static int ShowMainMenu()
        {
            // Main menu loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                Console.WriteLine("║                MAIN MENU - AIRLINE SYSTEM            ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 1. Add a New Flight                                  ║");
                Console.WriteLine("║ 2. View All Available Flights                        ║");
                Console.WriteLine("║ 3. Find Flight by Code                               ║");
                Console.WriteLine("║ 4. Update Flight Departure Time                      ║");
                Console.WriteLine("║ 5. Cancel Flight Booking                             ║");
                Console.WriteLine("║ 6. Book Flight                                       ║");
                Console.WriteLine("║ 7. Display Flight Details                            ║");
                Console.WriteLine("║ 8. Search Bookings by Destination                    ║");
                Console.WriteLine("║ 0. Exit Application                                  ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝");

                Console.Write("Enter your choice: ");

                try
                {
                    // Get user choice
                    int choice = int.Parse(Console.ReadLine());

                    // Handle user choice
                    switch (choice)
                    {
                        //add flight
                        case 1:
                            try
                            {
                                Console.WriteLine("╔══════════════════════════════════════════════════╗");
                                Console.WriteLine("║               ADD NEW FLIGHT                     ║");
                                Console.WriteLine("╚══════════════════════════════════════════════════╝");

                                // Getting Flight Code 
                                string flightCode;
                                do
                                {
                                    Console.Write("\n✈ Enter Flight Code (e.g., FL123): ");
                                    flightCode = Console.ReadLine().Trim().ToUpper();
                                } while (string.IsNullOrWhiteSpace(flightCode));

                                // Getting From City 
                                string fromCity;
                                do
                                {
                                    Console.Write("Enter Departure City: ");
                                    fromCity = Console.ReadLine().ToUpper();
                                } while (string.IsNullOrWhiteSpace(fromCity));

                                // Getting To City 
                                string toCity;
                                do
                                {
                                    Console.Write("Enter Destination City: ");
                                    toCity = Console.ReadLine().ToUpper();
                                } while (string.IsNullOrWhiteSpace(toCity) || toCity == fromCity);

                                // Getting Departure Time 
                                DateTime departureTime;
                                bool validTime;
                                do
                                {
                                    Console.Write("Enter Departure Time (yyyy-mm-dd hh:mm) (2400-10-11 12:11): ");
                                    validTime = DateTime.TryParse(Console.ReadLine(), out departureTime);
                                } while (!validTime || departureTime < DateTime.Now);

                                // Getting Duration 
                                int duration;
                                do
                                {
                                    Console.Write("Enter Flight Duration (In Min): ");
                                } while (!int.TryParse(Console.ReadLine(), out duration) );

                                // Getting Flight Price
                                double flightPrice;
                                do
                                {
                                    Console.Write("Enter Flight Price: ");
                                } while (!double.TryParse(Console.ReadLine(), out flightPrice));


                                // Adding Flight
                                AddFlight(flightCode, fromCity, toCity, departureTime, duration, flightPrice);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\nError: {ex.Message}");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                            }
                            break;

                        //view all flights
                        case 2: DisplayAllFlights(); 
                            break;

                        //find flight by code
                        case 3:

                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                 FIND FLIGHT BY CODE                    ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                            Console.WriteLine("\n\n");
                            
                            string flightCodeToFind;

                            // Getting Flight Code
                            do
                            {
                                Console.Write("Enter Flight Code: ");
                                flightCodeToFind = Console.ReadLine().ToUpper();
                            } while (string.IsNullOrWhiteSpace(flightCodeToFind));

                            if(ConfirmAction("search for flight details"))
                            {  
                                 // Searching for Flight
                                 if (FindFlightByCode(flightCodeToFind))
                                    {
                                        Console.WriteLine($"\nFlight {flightCodeToFind} found!");
                                    }
                                 else
                                    {
                                        Console.WriteLine($"\nFlight {flightCodeToFind} not found.");
                                    }
                            }
                           
                            break;

                        //update flight departure
                        case 4:

                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║               UPDATE FLIGHT DEPARTURE                  ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                            Console.WriteLine("\n\n");

                            string flightCodeToUpdate;
                            do
                            {
                                Console.Write("Enter Flight Code to update: ");
                                flightCodeToUpdate = Console.ReadLine().ToUpper();
                            } while (string.IsNullOrWhiteSpace(flightCodeToUpdate));

                            // Find the flight and get its index
                            int flightIndex = -1;
                            for (int i = 0; i < flightCount; i++)
                            {
                                if (flightCodes[i] == flightCodeToUpdate)
                                {
                                    flightIndex = i;
                                    break;
                                }
                            }

                            if (flightIndex >= 0)
                            {
                                // Pass the departure time by reference
                                UpdateFlightDeparture(ref departureTimes[flightIndex]);
                            }
                            else
                            {
                                Console.WriteLine($"\nError: Flight {flightCodeToUpdate} not found.");
                                Console.WriteLine("\nPress Enter to continue...");
                                Console.ReadLine();
                            }
                            break;

                        //cancel flight booking
                        case 5:

                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                 CANCEL FLIGHT BOOKING                  ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                            Console.WriteLine("\n");

                            Console.Write("Enter Passenger Name: ");
                            string passengerName1 = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(passengerName1))
                            {
                                Console.WriteLine("\nInvalid name. Please try again.");
                                Console.WriteLine("Press Enter to return to the main menu...");
                                Console.ReadLine();
                                return 0;
                            }

                            CancelFlightBooking(passengerName1);
                            break;

                        //book flight
                        case 6: 
                            string passengerName;

                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                    FLIGHT BOOKING                      ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                            Console.WriteLine("\n\n");

                            Console.Write("Enter Passenger Name: ");
                            passengerName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(passengerName))
                            {
                                Console.WriteLine("Invalid name. Please try again.");
                                break;
                            }

                            Console.WriteLine("Enter Flight Code to book: ");
                            string flightCodeToBook = Console.ReadLine().ToUpper();
                            if (ConfirmAction("book this flight"))
                            {
                                BookFlight(passengerName, flightCodeToBook);
                            }
                            else
                            {
                                Console.WriteLine("\n Flight booking cancelled.");
                            }
                            break;

                        //display flight details
                        case 7:
                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                    FLIGHT DETAILS                      ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                            Console.WriteLine("\n\n");

                            Console.WriteLine("\nEnter Flight Code to view details: ");
                            string codeToDisplay = Console.ReadLine().ToUpper();
                            DisplayFlightDetails(codeToDisplay);
                            break;

                        //search bookings by destination
                        case 8:

                            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║             SEARCH BOOKINGS BY DESTINATION             ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                            Console.WriteLine("\n\n");

                            
                            Console.Write("Enter Destination City: ");
                            string destinationCity = Console.ReadLine().ToUpper();
                            SearchBookingsByDestination(destinationCity);
                            break;

                        //exit application
                        case 0: ExitApplication(); 
                            break;

                        //invalid choice
                        default: Console.WriteLine("Invalid choice! Try again."); break;
                    }
                }
                catch (FormatException)
                { 
                    // Handle invalid input
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.ReadLine();
            }

        }

        public static void ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  THANK YOU FOR USING                   ║");
            Console.WriteLine("║              AIRLINE RESERVATION SYSTEM                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\nExiting the application...");
            Environment.Exit(0);

        }

        /* ====================== Flight Management Functions ====================== */

        // Adds a new flight to the system
        public static void AddFlight(string flightCode, string fromCity1, string toCity1, DateTime departureTime, int duration, double flightPrice)
        {
            try
            {
                // Check for duplicate flight code
                for (int i = 0; i < flightCount; i++)
                {
                    if (flightCodes[i] == flightCode)
                    {
                        Console.WriteLine($"\nError: Flight code {flightCode} already exists!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        return;
                    }
                }

                // Check if array is full
                if (flightCount >= MAX_FLIGHTS)
                {
                    Console.WriteLine("\nError: Flight list is full! Cannot add more flights.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return;
                }

                // Show confirmation
                string flightDetails =
                    $"\nFlight Code: {flightCode}\n" +
                    $"From: {fromCity1} , To: {toCity1}\n" +
                    $"Departure: {departureTime.ToString("yyyy-MM-dd HH:mm")}\n" +
                    $"Duration: {duration} minutes ({duration / 60}h {duration % 60}m)\n"+
                    $"Flight price: {flightPrice}";

                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                     Flight Details                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                Console.WriteLine(flightDetails);
                if (ConfirmAction("add this flight"))
                {
                    // Add the flight
                    flightCodes[flightCount] = flightCode;
                    fromCity[flightCount] = fromCity1;
                    toCity[flightCount] = toCity1;
                    departureTimes[flightCount] = departureTime;
                    durations[flightCount] = duration;
                    prices[flightCount] = flightPrice;
                    flightCount++;

                    Console.WriteLine($"\n Flight {flightCode} added successfully!");
                    Console.WriteLine($"Total flights: {flightCount}/{MAX_FLIGHTS}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            
        }

        /* -------------------------- Flight Management Functions -------------------------- */
        public static void DisplayAllFlights()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║               AVAILABLE FLIGHTS SCHEDULE               ║");
            Console.WriteLine("╠════════════╦══════════╦══════════╦═════════════════════╣");
            Console.WriteLine("║ Flight Code║ Departure║ Arrival  ║   Departure Time    ║");
            Console.WriteLine("╠════════════╬══════════╬══════════╬═════════════════════╣");
            for (int i = 0; i < flightCount; i++)
            {
                if (string.IsNullOrEmpty(passengerNames[i]))
                {
                    Console.WriteLine($"║ {flightCodes[i],-10} ║ {fromCity[i],-8} ║ {toCity[i],-8} ║ {departureTimes[i].ToString("yyyy-MM-dd HH:mm"),-13}    ║");
                }
            }

            Console.WriteLine("╚════════════╩══════════╩══════════╩═════════════════════╝");
            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();
        }

        public static bool FindFlightByCode(string code)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    Console.WriteLine($"\nFlight Code: {flightCodes[i]}");
                    Console.WriteLine($"From: {fromCity[i]}");
                    Console.WriteLine($"To: {toCity[i]}");
                    Console.WriteLine($"Departure: {departureTimes[i].ToString("yyyy-MM-dd HH:mm")}");
                    Console.WriteLine($"Duration: {durations[i]} minutes ({durations[i] / 60}h {durations[i] % 60}m)");

                    if (string.IsNullOrEmpty(passengerNames[i]))
                    {
                        Console.WriteLine($"Price: {prices[i]:C} (Available)");
                    }
                    else
                    {
                        Console.WriteLine($"Booked Price: {totalPrices[i]:C}");
                    }

                    Console.WriteLine($"Status: {(string.IsNullOrEmpty(passengerNames[i]) ? "Available" : $"Booked by {passengerNames[i]}")}");
                    return true;
                }
            }
            return false;
        }

        public static void UpdateFlightDeparture(ref DateTime departure)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 UPDATE FLIGHT DEPARTURE                ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.WriteLine("\n\n");

                // Display current departure time
                Console.WriteLine($"Current departure time: {departure.ToString("yyyy-MM-dd HH:mm")}");

                // Get new departure time with validation
                DateTime newDeparture;
                bool validTime;
                do
                {
                    Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                    validTime = DateTime.TryParse(Console.ReadLine(), out newDeparture);

                    if (!validTime)
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                    else if (newDeparture < DateTime.Now)
                    {
                        Console.WriteLine("Departure time must be in the future. Please try again.");
                    }
                } while (!validTime || newDeparture < DateTime.Now);

                // Confirm update
                if (ConfirmAction($"update departure time to {newDeparture.ToString("yyyy-MM-dd HH:mm")}"))
                {
                    departure = newDeparture;
                    Console.WriteLine($"\n Departure time updated successfully!");
                    Console.WriteLine($"New departure: {departure.ToString("yyyy-MM-dd HH:mm")}");
                }
                else
                {
                    Console.WriteLine("\n✗ Departure time update cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

    
        static void CancelFlightBooking(string passengerName1)
            {
                bool found = false;

                for (int i = 0; i < flightCount; i++)
                {
                    if (passengerNames[i] == passengerName1)
                    {
                        found = true;

                        if (ConfirmAction($"cancel booking for {passengerName1}"))
                        {
                            // Cancel the booking
                            passengerNames[i] = null;
                            bookingIDs[i] = null;
                            totalPrices[i] = 0;
                            bookingCount--;

                            Console.WriteLine($"\nBooking for {passengerName1} cancelled successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nBooking cancellation cancelled.");
                        }
                        return;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"\nBooking not found for {passengerName1}.");
                }

                Console.WriteLine("\nPress Enter to return to the main menu...");
                Console.ReadLine();
            }
        

        /* -------------------------- Passenger Booking Functions -------------------------- */
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            if (!ValidateFlightCode(flightCode))
            {
                Console.WriteLine($"\n Flight {flightCode} not found.");
                return;
            }

            for (int i = 0; i < MAX_BOOKINGS; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    // Check if the flight is already booked
                    if (string.IsNullOrEmpty(passengerNames[i]))
                    {
                        // Get number of tickets
                        int numTickets = 1;
                        Console.Write("Enter number of tickets (By default 1): ");
                        string input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int tickets))
                        {
                            numTickets = tickets;
                        }

                        // Ask for discount code
                        Console.Write("Enter discount code (leave blank if none): ");
                        string discountCode = Console.ReadLine().ToUpper();
                        double discountApplied = 0;

                        // Validate discount code
                        if (!string.IsNullOrEmpty(discountCode))
                        {
                            for (int j = 0; j < discountCodes.Length; j++)
                            {
                                if (discountCodes[j] == discountCode)
                                {
                                    discountApplied = discountValues[j];
                                    Console.WriteLine($" Valid discount code! {discountApplied * 100}% discount applied.");
                                    break;
                                }
                            }
                        }

                        // Calculate total price
                        double basePrice = prices[i];
                        double totalPrice;
                        totalPrice = CalculateFare(basePrice, numTickets, discountApplied);



                        // Show price breakdown

                        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                    PRICE BREAKDOWN                     ║");
                        Console.WriteLine("╠════════════════════════════════════════════════════════╣");
                        
                        Console.WriteLine($"Base Price: {basePrice:C} x {numTickets}");
                        if (discountApplied > 0)
                        {
                            Console.WriteLine($"Discount: {discountApplied * 100}% (Code: {discountCode})");
                            Console.WriteLine($"Discount Amount: {basePrice * numTickets * discountApplied:C}");
                        }

                        Console.WriteLine($"Total Price: {totalPrice:C}");
                        Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                        if (ConfirmAction("confirm this booking"))
                        {
                            // Book the flight
                            passengerNames[i] = passengerName;
                            bookingIDs[i] = GenerateBookingID(passengerName);
                            totalPrices[i] = totalPrice;
                            bookingCount++;

                            Console.WriteLine($"\n Flight {flightCode} booked successfully for {passengerName}!");
                            Console.WriteLine($"Booking ID: {bookingIDs[i]}");
                            Console.WriteLine($"Total Charged: {totalPrice:C}");
                        }
                        else
                        {
                            Console.WriteLine("\n Booking cancelled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n Flight {flightCode} is already booked by {passengerNames[i]}.");
                    }
                    return;
                }
            }
        }

        public static bool ValidateFlightCode(string flightCode)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    return true;  
                }
            }
            return false;  
        }


        public static string GenerateBookingID(string passengerName)
        {
            Random random = new Random();
            string randomNum = random.Next(1000, 9999).ToString();

            return $"{passengerName}-{randomNum}";
        }

        public static void DisplayFlightDetails(string code)
        {
            Console.Clear();
            Console.WriteLine("\n\n");

            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    FLIGHT DETAILS                      ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            bool flightFound = false;

            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    flightFound = true;

                    // Display basic flight information
                    Console.WriteLine($"Flight Code: {flightCodes[i]}");
                    Console.WriteLine($"Route: {fromCity[i]} → {toCity[i]}");
                    Console.WriteLine($"Departure: {departureTimes[i].ToString("yyyy-MM-dd HH:mm")}");
                    Console.WriteLine($"Duration: {durations[i]} minutes ({durations[i] / 60}h {durations[i] % 60}m)");
                    Console.WriteLine($"Base Price: {prices[i]:C}");

                    // Display booking status and pricing
                    if (!string.IsNullOrEmpty(passengerNames[i]))
                    {
                        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                 BOOKING INFORMATION                    ║");
                        Console.WriteLine("╠════════════════════════════════════════════════════════╣");
                        Console.WriteLine($"Status: Booked");
                        Console.WriteLine($"Passenger: {passengerNames[i]}");
                        Console.WriteLine($"Booking ID: {bookingIDs[i]}");
                        Console.WriteLine($"Total Price Paid: {totalPrices[i]:C}");


                        // Check if discount was applied
                        if (prices[i] > totalPrices[i])
                        {
                            double discountAmount = prices[i] - totalPrices[i];
                            Console.WriteLine($"Discount Applied: {discountAmount:C} ({(discountAmount / prices[i]):P})");
                        }


                    }
                    else
                    {
                        Console.WriteLine("\nStatus: Available for booking");
                        Console.WriteLine("No current bookings for this flight");
                    }


                    break;
                }
            }

            if (!flightFound)
            {
                Console.WriteLine($"\nFlight with code {code} not found.");
            }

            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();
        }

        static void SearchBookingsByDestination(string destination)
        {
            Console.WriteLine($"\n\n");
            bool found = false;
            for (int i = 0; i < flightCount; i++)
            {
                if (toCity[i] == destination)
                {
                    
                    found = true;
                    Console.WriteLine($"Flight Code: {flightCodes[i]}");
                    Console.WriteLine($"From: {fromCity[i]} → To: {toCity[i]}");
                    Console.WriteLine($"Passenger Name: {passengerNames[i]}");
                    Console.WriteLine($"Booking ID: {bookingIDs[i]}");
                    Console.WriteLine($"Total Price Paid: {totalPrices[i]:C}");
                    Console.WriteLine("------------------------");
                }
            }
            if (!found)
            {

                Console.WriteLine($"No bookings found for destination: {destination}");
            }
            Console.WriteLine("\nPress Enter to return to main menu...");
            Console.ReadLine();

        }

        /* -------------------------- Overloaded Functions -------------------------- */
        public static int CalculateFare(int basePrice, int numTickets)
        {
            // Calculate total fare
            int total = basePrice * numTickets;

            return total;
         
        }
        public static double CalculateFare(double basePrice, int numTickets)
        {
            // Calculate total fare
            double total = basePrice * numTickets;

            return total;
        }
        public static double CalculateFare(double basePrice, int numTickets, double discount = 0)
        {
            double subtotal = basePrice * numTickets;
            double discountAmount = subtotal * discount;
            double total = subtotal - discountAmount;

            return Math.Round(total, 2); 
        }



        /* -------------------------- System Utilities -------------------------- */
        static bool ConfirmAction(string action)
        {

            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                        ║");
            Console.WriteLine($"║Are you sure you want to {action}? (Y/N)              ");
            Console.WriteLine("║                                                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n\n");

          
            char keyInfo = Console.ReadKey().KeyChar;

            // Check if user pressed Y/y (Yes) or N/n (No)
            while (true)
            {
                if (keyInfo == 'Y' || keyInfo == 'y')
                {
                    Console.WriteLine($"\nAction confirmed: {action}");
                    return true;
                }
                else if (keyInfo == 'N' || keyInfo == 'n')
                {
                    Console.WriteLine($"\nAction cancelled: {action}");
                    return false;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please press Y for Yes or N for No:");
                    keyInfo = Console.ReadKey().KeyChar;
                }
            }
        }

        static void StartSystem()
        {
            DisplayWelcomeMessage();
        }




    }
}