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
using System.Text;
using System.Text.RegularExpressions;

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
            return new Regex(@"^[A-Z]{2}-[0-9]{4}-[A-Z]{2}$").IsMatch(id);
        }

        private static string GenerateRandomRegistrationPlateNumber()
        {
            //Example ХХ-YYYY-XX
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            GetTwoLetters(stringBuilder, random);
            stringBuilder.Append('-').Append(random.Next(1000, 10000)).Append('-');
            GetTwoLetters(stringBuilder, random);

            return stringBuilder.ToString();

        }

        private static void GetTwoLetters(StringBuilder stringBuilder, Random random)
        {
            for (int i = 0; i < 2; i++)
            {
                stringBuilder.Append((char)random.Next('A', 'Z' + 1));
            }
        }
    }
}