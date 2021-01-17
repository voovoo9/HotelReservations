using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservations;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1a()
        {
            string expected = "Decline";
            int order = 1;
            Hotel hotel = new Hotel(1);
            Tuple<int, int> reservation = Tuple.Create(-4, 2);
            string result = hotel.MakeReservation(reservation) ? "Accept" : "Decline";
            Console.WriteLine($"Booking {order} StartDate: {reservation.Item1} EndDate: {reservation.Item2} Result: {result}");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCase1b()
        {
            string expected = "Decline";
            int order = 1;
            Hotel hotel = new Hotel(1);
            Tuple<int, int> reservation = Tuple.Create(200, 400);
            string result = hotel.MakeReservation(reservation) ? "Accept" : "Decline";
            Console.WriteLine($"Booking {order} StartDate: {reservation.Item1} EndDate: {reservation.Item2} Result: {result}");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCase2()
        {
            string[] expected = { "Accept", "Accept", "Accept", "Accept", "Accept", "Accept" };
            string[] results = new string[6];
            int order = 1;
            Hotel hotel = new Hotel(3);
            Tuple<int, int>[] reservations = { Tuple.Create(0, 5), Tuple.Create(7, 13), Tuple.Create(3, 9), Tuple.Create(5, 7), Tuple.Create(6, 6), Tuple.Create(0, 4) };
            for (int i = 0; i < 6; i++)
            {
                string result = hotel.MakeReservation(reservations[i]) ? "Accept" : "Decline";
                results[i] = result;
                Console.WriteLine($"Booking {order} StartDate: {reservations[i].Item1} EndDate: {reservations[i].Item2} Result: {result}");
                order++;
            }
            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TestCase3()
        {
            string[] expected = { "Accept", "Accept", "Accept", "Decline" };
            string[] results = new string[4];
            int order = 1;
            Hotel hotel = new Hotel(3);
            Tuple<int, int>[] reservations = { Tuple.Create(1, 3), Tuple.Create(2, 5), Tuple.Create(1, 9), Tuple.Create(0, 15) };
            for (int i = 0; i < 4; i++)
            {
                string result = hotel.MakeReservation(reservations[i]) ? "Accept" : "Decline";
                results[i] = result;
                Console.WriteLine($"Booking {order} StartDate: {reservations[i].Item1} EndDate: {reservations[i].Item2} Result: {result}");
                order++;
            }
            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TestCase4()
        {
            string[] expected = { "Accept", "Accept", "Accept", "Decline", "Accept" };
            string[] results = new string[5];
            int order = 1;
            Hotel hotel = new Hotel(3);
            Tuple<int, int>[] reservations = { Tuple.Create(1, 3), Tuple.Create(0, 15), Tuple.Create(1, 9), Tuple.Create(2, 5), Tuple.Create(4, 9) };
            for (int i = 0; i < 5; i++)
            {
                string result = hotel.MakeReservation(reservations[i]) ? "Accept" : "Decline";
                results[i] = result;
                Console.WriteLine($"Booking {order} StartDate: {reservations[i].Item1} EndDate: {reservations[i].Item2} Result: {result}");
                order++;
            }
            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TestCase5()
        {
            string[] expected = { "Accept", "Accept", "Decline", "Accept", "Accept", "Accept", "Accept", "Decline", "Accept" };
            string[] results = new string[9];
            int order = 1;
            Hotel hotel = new Hotel(2);
            Tuple<int, int>[] reservations = { Tuple.Create(1, 3), Tuple.Create(0, 4), Tuple.Create(2, 3), Tuple.Create(5, 5), Tuple.Create(4, 10),
               Tuple.Create(10, 10), Tuple.Create(6, 7), Tuple.Create(8, 10), Tuple.Create(8, 9) };
            for (int i = 0; i < 9; i++)
            {
                string result = hotel.MakeReservation(reservations[i]) ? "Accept" : "Decline";
                results[i] = result;
                Console.WriteLine($"Booking {order} StartDate: {reservations[i].Item1} EndDate: {reservations[i].Item2} Result: {result}");
                order++;
            }
            CollectionAssert.AreEqual(expected, results);
        }
    }
}
