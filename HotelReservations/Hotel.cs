using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservations
{
    public class Hotel
    {
        internal const int numberOfDays = 365;
        public int NumberOfRooms { get; set; }
        public List<Room> Rooms { get; set; }

        public Hotel(int numberOfRooms)
        {
            NumberOfRooms = numberOfRooms;
            Rooms = new List<Room>();
            CreateHotel();
        }

        private void CreateHotel()
        {
            for (int i = 0; i < this.NumberOfRooms; i++)
            {
                Rooms.Add(new Room());
            }
        }

        /// <summary>
        /// Checks if hotel has any available date
        /// </summary>
        /// <returns></returns>
        internal bool HasRoomsAvailable()
        {
            return Rooms.Any(room => room.Available.Any(c => c));
        }

        /// <summary>
        /// Checks if hotel has room for inserted date period
        /// </summary>
        /// <param name="reservation"></param>
        public bool MakeReservation(Tuple<int, int> reservation)
        {
            bool isReseved = false;

            if (!ValidateReservation(reservation))
                return isReseved;

            List<Room> availableRooms = new List<Room>();
            foreach (Room room in Rooms)
            {
                if (room.IsAvailableForPeriod(reservation))
                {
                    availableRooms.Add(room);
                }
            }

            if (availableRooms.Any())
            {
                Room room = GetMostSuitableRoom(reservation, availableRooms);
                room.ConfirmReservation(reservation);
                isReseved = true;
            }

            return isReseved;
        }

        /// <summary>
        /// Checks if reservation data is correct
        /// </summary>
        /// <param name="reservation"></param>
        private bool ValidateReservation(Tuple<int, int> reservation)
        {
            return reservation.Item1 <= reservation.Item2 && reservation.Item1 < numberOfDays && reservation.Item2 < numberOfDays &&
                   reservation.Item1 >= 0 && reservation.Item2 >= 0;
        }

        /// <summary>
        /// Returns best suitable room
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="availableRooms"></param>
        private Room GetMostSuitableRoom(Tuple<int, int> reservation, List<Room> availableRooms)
        {
            if (reservation.Item1 != 0)
            {
                Room room = availableRooms.Where(c => !c.Available[reservation.Item1 - 1]).FirstOrDefault();
                if (room != null)
                {
                    return room;
                }
            }
            return availableRooms.FirstOrDefault();
        }
    }
}
