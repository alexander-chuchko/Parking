using CoolParking.BL.Interfaces;
using CoolParking.BL.Models;
using System;
using System.Linq;


namespace CoolParking.BL
{
    public class ParkingManagementInterface
    {
        private readonly IParkingService _parkingService;
        private readonly int numberMenuItems = 8;
        private string key;

        public ParkingManagementInterface(IParkingService parkingService)
        {
            this._parkingService = parkingService;
        }

        #region ---helpers---

        //Вивести на екран поточний баланс Паркінгу;
        private void DisplayCurrentBalance()
        {
            Console.WriteLine($"\tParking balance: {_parkingService.GetBalance()}");
        }

        //Вивести на екран кількість вільних місць на Паркінгу (вільно X з Y);
        private void DisplayNumberFreeSeats()
        {
            Console.WriteLine($"\tNumber of free - " +
                $"{_parkingService.GetFreePlaces()} / employed -" +
                $" {_parkingService.GetCapacity() - _parkingService.GetFreePlaces()}");
        }

        //Вивести на екран суму зароблених коштів за поточний період(до запису у лог);
        private void DisplayEarnings()
        {
            var transactionsLog = _parkingService.GetLastParkingTransactions();

            if (transactionsLog != null)
            {
                Console.WriteLine($"\tAmount for the current period: {transactionsLog.Sum(tr => tr.Sum)}");
            }
            else
            {
                Console.WriteLine($"\tAmount for the current period: 0");
            }
        }

        private void ShowListTrFundsLocated()
        {
            if (_parkingService.GetFreePlaces() < Settings.parkingCapacity)
            {
                int count = default(int);
                Console.WriteLine($"\tVehicle list:\n");

                foreach (var item in _parkingService.GetVehicles())
                {
                    Console.WriteLine($"\t{++count} - Id:{item.Id} VehicleType:{item.VehicleType} Balance:{item.Balance}");
                }
            }
            else
            {
                Console.WriteLine("\tThere are no cars in the parking lot");
            }
        }
        //DisplayAllParkingTrCurrentPeriod

        private void PutTrAidForParking()
        {
            var vehicle = new Vehicle(Vehicle.GenerateRandomRegistrationPlateNumber(), VehicleType.Truck, 100);
            _parkingService.AddVehicle(vehicle);
            Console.WriteLine($"\tAdded to the parking car - Id:{vehicle.Id} VehicleType:{vehicle.VehicleType} Balance:{vehicle.Balance}");
        }

        #endregion
    }
}
