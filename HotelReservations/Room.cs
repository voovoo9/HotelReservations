using System;

namespace HotelReservations
{
    public class Room
    {
        public bool[] Available { get; set; }

        public Room()
        {
            Available = new bool[Hotel.numberOfDays];
            for (int i = 0; i < Hotel.numberOfDays; i++)
            {
                Available[i] = true;
            }
        }

        /// <summary>
        /// Checks if room is available inserted date period
        /// </summary>
        /// <param name="reservation"></param>
        internal bool IsAvailableForPeriod(Tuple<int, int> reservation)
        {
            bool isAvailable = true;

            for (int i = reservation.Item1; i <= reservation.Item2; i++)
            {
                if (!Available[i])
                {
                    isAvailable = false;
                    break;
                }
            }

            return isAvailable;
        }

        /// <summary>
        /// Books room for inserted date period
        /// </summary>
        /// <param name="reservation"></param>
        internal void ConfirmReservation(Tuple<int, int> reservation)
        {
            for (int i = reservation.Item1; i <= reservation.Item2; i++)
            {
                Available[i] = false;
            }
        }
    }
}
