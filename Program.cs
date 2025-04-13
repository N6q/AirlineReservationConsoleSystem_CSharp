using System;
namespace AirlineReservationConsoleSystem_CSharp
{

    internal class Program
    {
        // Global variables and data storage
        static int MAX_FLIGHTS = 2;
        static string[] flightCodes = new string[MAX_FLIGHTS];
        static string[] fromCity = new string[MAX_FLIGHTS];
        static string[] toCity = new string[MAX_FLIGHTS];
        static DateTime[] departureTimes = new DateTime[MAX_FLIGHTS];
        static int[] durations = new int[MAX_FLIGHTS];
        static string[] passengerNames = new string[MAX_FLIGHTS];
        static string[] bookingIDs = new string[MAX_FLIGHTS];
        static int flightCount = 0;
        static int bookingCount = 0;

        static void Main(string[] args)
        {
            StartSystem();
        }

        /* -------------------------- Startup & Navigation Functions -------------------------- */
        static void DisplayWelcomeMessage()
        {
            string welcomeMessage = "Welcome to the Airline Reservation System!";

            int choice;
            bool on = true;

            do
            {
                Console.Clear();
                Console.WriteLine(welcomeMessage);
                Console.WriteLine("1. Start Application");
                Console.WriteLine("2. Exit Application");
                Console.Write("Enter your choice: ");
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

        static int ShowMainMenu()
        {
            // Main menu loop
            while (true)
            {
                Console.Clear();
                // Display menu options
                Console.WriteLine("\nChoose an Array Exercise:");
                Console.WriteLine("1. Add a new Flight ");
                Console.WriteLine("2. View all Flights (Available) ");
                Console.WriteLine("3. Find Flight by Code ");
                Console.WriteLine("4. Update Flight Departure ");
                Console.WriteLine("5. Cancel Flight Booking ");
                Console.WriteLine("6. Book Flight  ");
                Console.WriteLine("7. Display Flight Details ");
                Console.WriteLine("8. Search Bookings by Destination ");
                Console.WriteLine("0. Exit Application");
                Console.Write("Enter your choice: ");

                try
                {
                    // Get user choice
                    int choice = int.Parse(Console.ReadLine());

                    // Handle user choice
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("\n=== ADD NEW FLIGHT ===\n");

                                // Getting Flight Code 
                                string flightCode;
                                do
                                {
                                    Console.Write("Enter Flight Code: ");
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

                                // Adding Flight
                                AddFlight(flightCode, fromCity, toCity, departureTime, duration);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\nError: {ex.Message}");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                            }
                            break;


                        //case 2: ViewAllRooms(); break;
                        //case 3: ReserveRoom(); break;
                        //case 4: ViewAllReservations(); break;
                        //case 5: SearchReservationByGuestName(); break;
                        //case 6: highestPayingGuest(); break;
                        //case 7: CancelReservation(); break;
                        //case 0: return;
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

        static void ExitApplication()
        {
            // Implementation
        }

        public static void AddFlight(string flightCode, string fromCity1, string toCity1, DateTime departureTime, int duration)
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
                    $"Duration: {duration} minutes ({duration / 60}h {duration % 60}m)";

                Console.WriteLine("\n=== FLIGHT DETAILS ===");

                Console.WriteLine(flightDetails);
                if (ConfirmAction("add this flight"))
                {
                    // Add the flight
                    flightCodes[flightCount] = flightCode;
                    fromCity[flightCount] = fromCity1;
                    toCity[flightCount] = toCity1;
                    departureTimes[flightCount] = departureTime;
                    durations[flightCount] = duration;
                    flightCount++;

                    Console.WriteLine($"\n✓ Flight {flightCode} added successfully!");
                    Console.WriteLine($"Total flights: {flightCount}/{MAX_FLIGHTS}");
                }
                else
                {
                    Console.WriteLine("\n✗ Flight addition cancelled");
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
        static void DisplayAllFlights()
        {
            // Implementation
        }

        static bool FindFlightByCode(string code)
        {
            // Implementation
            return false; // placeholder
        }

        static void UpdateFlightDeparture(ref DateTime departure)
        {
            // Implementation
        }

        static void CancelFlightBooking(out string passengerName)
        {
            // Implementation
            passengerName = ""; // placeholder
        }

        /* -------------------------- Passenger Booking Functions -------------------------- */
        static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            // Implementation with optional parameter
        }

        static bool ValidateFlightCode(string flightCode)
        {
            // Implementation
            return false; // placeholder
        }

        static string GenerateBookingID(string passengerName)
        {
            // Implementation
            return ""; // placeholder
        }

        static void DisplayFlightDetails(string code)
        {
            // Implementation
        }

        static void SearchBookingsByDestination(string toCity)
        {
            // Implementation
        }

        /* -------------------------- Overloaded Functions -------------------------- */
        static int CalculateFare(int basePrice, int numTickets)
        {
            // Implementation
            return 0; // placeholder
        }

        static double CalculateFare(double basePrice, int numTickets)
        {
            // Implementation
            return 0.0; // placeholder
        }

        static int CalculateFare(int basePrice, int numTickets, int discount)
        {
            // Implementation
            return 0; // placeholder
        }

        /* -------------------------- System Utilities -------------------------- */
        static bool ConfirmAction(string action)
        {
            Console.Clear();
            Console.WriteLine($"Are you sure you want to {action}? (Y/N)");
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