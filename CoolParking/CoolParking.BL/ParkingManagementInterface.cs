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
        //Вивести на екран усі Транзакції Паркінгу за поточний період (до запису у лог);

        //Забрати Транспортний засіб з Паркінгу;

        private void PickUpVehicle()
        {
            Console.WriteLine("\tSpecify the index of the vehicle");
            ShowListTrFundsLocated();
            string? id = Console.ReadLine();

            var vehicleses = _parkingService.GetVehicles();

            if (id != null && int.TryParse(id, out int convertId) && convertId > 0 && convertId <= vehicleses.Count)
            {
                _parkingService.RemoveVehicle(vehicleses[convertId - 1].Id);
            }

        }

        //Поповнити баланс конкретного Тр. засобу.
        private void TopUpBalanceCar()
        {
            Console.WriteLine("\tSpecify the index of the vehicle");
            ShowListTrFundsLocated();
            string? id = Console.ReadLine();
            Console.WriteLine("\tEnter replenishment amount");
            string? topUpAmount = Console.ReadLine();
            var vehicles = _parkingService.GetVehicles();

            if (IsValidInput(id, topUpAmount, vehicles.Count, out int convertIndex, out int convertTopUpAmount))
            {
                _parkingService.TopUpVehicle(vehicles[convertIndex - 1].Id, convertTopUpAmount);
            }
        }

        private bool IsValidInput(string? id, string? topUpAmount, int maxIndex, out int convertIndex, out int convertTopUpAmount)
        {
            convertIndex = 0;
            convertTopUpAmount = 0;

            if (id != null && int.TryParse(id, out convertIndex) && int.TryParse(topUpAmount, out convertTopUpAmount) && convertIndex > 0 && convertIndex <= maxIndex)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please enter valid indices and amounts.");
                return false;
            }
        }

        #endregion
    }
}
