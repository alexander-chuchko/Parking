// TODO: implement struct TransactionInfo.
//       Necessarily implement the Sum property (decimal) - is used in tests.
//       Other implementation details are up to you, they just have to meet the requirements of the homework.

// TODO: реалізувати структуру TransactionInfo.
// Обов'язково реалізуємо властивість Sum (decimal) - використовується в тестах.
// Інші деталі впровадження вирішувати вам, вони просто мають відповідати вимогам домашнього завдання.

namespace CoolParking.BL.Models
{
    public class TransactionInfo 
    {
        public decimal Sum { get; set; }
        public string VehicleId { get; set; }
        public string TransactionTime { get; set; }
    }
}
