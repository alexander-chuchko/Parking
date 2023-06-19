// TODO: implement class Settings.
//       Implementation details are up to you, they just have to meet the requirements of the home task.
// TODO: реалізувати налаштування класу.
// Деталі реалізації залежать від вас, вони лише мають відповідати вимогам домашнього завдання.
using System.IO;
using System.Reflection;

namespace CoolParking.BL.Models
{
    public class Settings
    {
        public static string logFilePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\transactions.log";
        public static decimal initialBalanceParking = 0;
        public static int parkingCapacity = 10;
        public static int paymentWriteOffPeriod = 5;
        public static int loggingPeriod = 60;
        public static int coefficient = 1000;
        public static decimal penaltyCoefficient = 2.5m;

    }
}