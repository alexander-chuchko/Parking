// TODO: implement the ParkingService class from the IParkingService interface.
//       For try to add a vehicle on full parking InvalidOperationException should be thrown.
//       For try to remove vehicle with a negative balance (debt) InvalidOperationException should be thrown.
//       Other validation rules and constructor format went from tests.
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in ParkingServiceTests you can find the necessary constructor format and validation rules.

/*
 // TODO: реализовать класс ParkingService из интерфейса IParkingService.
// При попытке добавить машину на полную парковку должно быть выброшено исключение InvalidOperationException.
// При попытке удаления автомобиля с отрицательным балансом (долгом) должно быть выброшено InvalidOperationException.
// Другие правила проверки и формат конструктора пошли из тестов.
// Другие детали реализации на ваше усмотрение, они просто должны соответствовать требованиям интерфейса
// и тесты, например, в ParkingServiceTests можно найти нужный формат конструктора и правила проверки.
 */

using CoolParking.BL.Interfaces;
using CoolParking.BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace CoolParking.BL.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingService _parkingService;
        private readonly ITimerService _withdrawTimer;
        private readonly ITimerService _logTimer;
        private readonly ILogService _logService;

        public ParkingService(ITimerService withdrawTimer, ITimerService logTimer, ILogService logService)
        {
            Parking = Parking.GetInstance();
            Parking.Vehicles = new List<Vehicle>(Settings.parkingCapacity);
            _logService = logService;
            _logTimer = logTimer;
            _withdrawTimer = withdrawTimer;
            this._logTimer.Elapsed += OnLogRecord;

        }

        private Parking _parking;
        public Parking Parking
        {
            get { return _parking; }
            set { _parking = value; }
        }

        private TransactionInfo[] _transactionInfo;
        public TransactionInfo[] TransactionInfo
        {
            get { return _transactionInfo; }
            set { _transactionInfo = value; }
        }

        #region  ---  Interface IParkingService implementation   ---

        //Method for adding vichel to the parking
        public void AddVehicle(Vehicle vehicle)
        {
            if (Parking.Vehicles.Count < Settings.parkingCapacity)
            {
                Parking.Vehicles.Add(vehicle);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Dispose()
        {
            Parking.DisposeInstance();
        }

        //Method for geting balance of parking
        public decimal GetBalance()
        {
            return Parking.Balance;
        }

        //Method for geting capacity of parking
        public int GetCapacity()
        {
            return Parking.Vehicles.Capacity;
        }

        //Method for geting free places of parking
        public int GetFreePlaces()
        {
            return Parking.Vehicles.Capacity - Parking.Vehicles.Count;
        }

        public TransactionInfo[] GetLastParkingTransactions()
        {
            return TransactionInfo;
        }

        //Method for geting all vehicles of parking
        public ReadOnlyCollection<Vehicle> GetVehicles()
        {
            return Parking.Vehicles.AsReadOnly();
        }

        public string ReadFromLog()
        {
            return _logService.Read();
        }

        //Pick up car from parking
        public void RemoveVehicle(string vehicleId)
        {
            var foundVehicle = Parking.Vehicles.Find(tr => tr.Id == vehicleId && tr.Balance >= 0);

            if (foundVehicle != null)
            {
                Parking.Vehicles.Remove(foundVehicle);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        //Method for top up vehicle
        public void TopUpVehicle(string vehicleId, decimal sum)
        {
            var foundVehicle = Parking.Vehicles.Find(tr => tr.Id == vehicleId);

            if (foundVehicle != null && sum >= 0)
            {
                foundVehicle.Balance += sum;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        #endregion

        private void OnLogRecord(object sender, ElapsedEventArgs e)
        {
            string transactions = string.Join("\r", TransactionInfo?.Where(transaction => transaction != null)
                .Select(transaction => $"Id:{transaction.VehicleId} Date:{transaction.TransactionTime} Sum:{transaction.Sum}"));

            _logService.Write(transactions);

            TransactionInfo = null;
        }

        private void OnWithdrawFunds(object sender, ElapsedEventArgs e)
        {
            if (Parking.Vehicles.Count != 0)
            {
                int count = 0;

                //When the first object is added
                if (TransactionInfo == null)
                {
                    TransactionInfo = new TransactionInfo[Parking.Vehicles.Count];
                }
                else
                {
                    ResizeArray(TransactionInfo.Length + Parking.Vehicles.Count);
                    count = TransactionInfo.Length - Parking.Vehicles.Count;
                }

                foreach (var vehicles in Parking.Vehicles)
                {
                    decimal sumFine = 0;
                    decimal tariff = Settings.tariffs[(int)vehicles.VehicleType];

                    if (vehicles.Balance < 0)
                    {
                        sumFine = tariff * Settings.penaltyCoefficient;
                    }
                    else if (vehicles.Balance < tariff)
                    {
                        sumFine = vehicles.Balance + ((tariff - vehicles.Balance) * Settings.penaltyCoefficient);
                    }
                    else if (vehicles.Balance >= tariff)
                    {
                        sumFine = tariff;
                    }

                    vehicles.Balance -= sumFine;
                    Parking.Balance += sumFine;

                    TransactionInfo[count] = CreateTransactionInfo(vehicles, sumFine);

                    count++;
                }
            }
        }
    }
}