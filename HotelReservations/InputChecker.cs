using System;

namespace HotelReservations
{
    public class InputChecker
    {
        //maximal number of rooms in hotel
        private const int maxNumberOfRooms = 1000;
        //minimal number of rooms in hotel
        private const int minNumberOfRooms = 1;

        /// <summary>
        /// Checks if number of rooms input is correct
        /// </summary>
        /// <param name="number"></param>
        internal bool CheckHotelSizeInput(string number)
        {
            return Int32.TryParse(number, out int value) && value < maxNumberOfRooms && value >= minNumberOfRooms;
        }

        /// <summary>
        /// Checks if date input is correct
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        internal bool CheckDateInput(string start, string end)
        {
            return Int32.TryParse(start, out _) && Int32.TryParse(end, out _);
        }
    }
}
