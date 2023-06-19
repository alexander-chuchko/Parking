// TODO: implement class Parking.
//       Implementation details are up to you, they just have to meet the requirements 
//       of the home task and be consistent with other classes and tests.
// TODO: реалізувати клас Parking.
// Деталі впровадження вирішувати вам, вони просто мають відповідати вимогам
// домашнього завдання та узгоджуватися з іншими класами та тестами.

using System;
using System.Collections.Generic;

namespace CoolParking.BL.Models
{
    public class Parking
    {
        public List<Vehicle> Vehicles { get; set; }
        public decimal Balance { get; set; }
        public DateTime? StartTime { get; set; }

        private static Parking? instance;

        public Parking()
        {
        }
    }
}