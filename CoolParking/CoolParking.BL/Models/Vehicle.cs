// TODO: implement class Vehicle.
//       Properties: Id (string), VehicleType (VehicleType), Balance (decimal).
//       The format of the identifier is explained in the description of the home task.
//       Id and VehicleType should not be able for changing.
//       The Balance should be able to change only in the CoolParking.BL project.
//       The type of constructor is shown in the tests and the constructor should have a validation, which also is clear from the tests.
//       Static method GenerateRandomRegistrationPlateNumber should return a randomly generated unique identifier.
// TODO: реализовать класс Vehicle.
// Свойства: Id (строка), VehicleType (ТипТранспорта), Balance (десятичный).
// Формат идентификатора поясняется в описании домашнего задания.
// Id и VehicleType не должны изменяться.
// Баланс должен иметь возможность изменяться только в проекте CoolParking.BL.
// Тип конструктора показывается в тестах и конструктор должен иметь валидацию, что тоже видно из тестов.
// Статический метод GenerateRandomRegistrationPlateNumber должен возвращать случайно сгенерированный уникальный идентификатор.

using System;

namespace CoolParking.BL.Models
{
    public class Vehicle 
    {
        public string Id { get; }
        public VehicleType VehicleType { get; }
        public decimal Balance { get; internal set; }

        public Vehicle(string id, VehicleType vehicleType, decimal balance)
        {
            if (true)
            {

            }
            else
            {
                throw new ArgumentException("Invalid identifier entered");
            }
        }

        private bool IsValidId(string id)
        {
            throw new NotImplementedException();
        }
    }
}