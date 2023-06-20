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

namespace CoolParking.BL.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingService _parkingService;

        public ParkingService()
        {
            Parking = Parking.GetInstance();
            Parking.Vehicles = new List<Vehicle>(Settings.parkingCapacity);
        }

        private Parking _parking;
        public Parking Parking
        {
            get { return _parking; }
            set { _parking = value; }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new System.NotImplementedException();
        }

        public int GetCapacity()
        {
            throw new System.NotImplementedException();
        }

        public int GetFreePlaces()
        {
            throw new System.NotImplementedException();
        }

        public TransactionInfo[] GetLastParkingTransactions()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Vehicle> GetVehicles()
        {
            throw new System.NotImplementedException();
        }

        public string ReadFromLog()
        {
            throw new System.NotImplementedException();
        }

        //Pick up car from parking
        public void RemoveVehicle(string vehicleId)
        {
            var foundVehicle = Parking.Vehicles.Find(tr=>tr.Id == vehicleId && tr.Balance >= 0);

            if (foundVehicle != null)
            {
                Parking.Vehicles.Remove(foundVehicle);  
            }
            else 
            {
                throw new InvalidOperationException();
            }
        }

        public void TopUpVehicle(string vehicleId, decimal sum)
        {
            throw new System.NotImplementedException();
        }
    }
}