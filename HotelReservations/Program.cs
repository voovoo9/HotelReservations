using System;

namespace HotelReservations
{
    class Program
    {
        static void Main(string[] args)
        {
            InputChecker inputChecker = new InputChecker();
            Console.WriteLine("Insert a number of rooms: ");
            string number = Console.ReadLine();

            while (!inputChecker.CheckHotelSizeInput(number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please insert a number between 1 and 1000: ");
                number = Console.ReadLine();
            }
            int numberOfRooms = Int32.Parse(number);
            Hotel hotel = new Hotel(numberOfRooms);

            int order = 1;

            while (hotel.HasRoomsAvailable())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Insert check in date: ");
                string start = Console.ReadLine();

                Console.WriteLine("Insert check out date: ");
                string end = Console.ReadLine();

                while (!inputChecker.CheckDateInput(start, end))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not correct.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Insert check in date: ");
                    start = Console.ReadLine();
                    Console.WriteLine("Insert check out date: ");
                    end = Console.ReadLine();
                }
                int startDay = Int32.Parse(start);
                int endDay = Int32.Parse(end);

                var reservation = Tuple.Create(startDay, endDay);

                string result = hotel.MakeReservation(reservation) ? "Accept" : "Decline";
                Console.WriteLine($"Booking {order}: {result}");
                order++;
            }

            Console.WriteLine("Sorry, we have no rooms available.");
            Console.ReadKey();
        }
    }
}
