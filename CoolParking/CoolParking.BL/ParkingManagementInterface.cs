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

       
    }
}
